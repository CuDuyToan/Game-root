using CoreSystem.Data;
using CoreSystem.MainMenu;
using CoreSystem.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.UIPersistent
{
    public class MainMenuUIService: MonoBehaviour
    {
        public static MainMenuUIService Instance { get; private set; }

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Awake()
        {
            setSingleton();
        }

        private void OnEnable()
        {
            RefreshSlotData();
            NewGameButtonActive();
        }

        public void Exit()
        {
            GameRoot.Instance.Exit();
        }

        #region Load game menu
        [Header("Load Game")]
        private int selectSlot = -1;
        /// <summary>
        /// Added to the button to select the slot to be mounted.
        /// </summary>
        /// <param name="slot"></param>
        public void SelectSlot(int slot = -1)
        {
            selectSlot = slot;
            NewGameSetup.Instance.slot = slot;
        }

        public void DeselectSlot()
        {
            selectSlot = -1;
        }

        #region preview map
        [SerializeField] private Slider previewMap;
        [SerializeField] private float speedSlider = 5f;
        private Coroutine currentRoutine;
        /// <summary>
        /// When selecting a slot, also preview the map image of
        /// </summary>
        /// <param name="active"></param>
        public void PreviewMap(bool active)
        {
            if (currentRoutine != null) return;

            currentRoutine = StartCoroutine(SmoothMove(active ? 1 : 0));
        }

        private IEnumerator SmoothMove(float target = 1)
        {
            while (true)
            {
                previewMap.value = Mathf.MoveTowards(previewMap.value, target, speedSlider * Time.deltaTime);

                if (Mathf.Abs(previewMap.value - target) < 0.01f)
                {
                    previewMap.value = target;
                    currentRoutine = null;
                    yield break;
                }

                yield return null;
            }
        }
        #endregion preview map

        #region refresh slots
        [SerializeField] private List<SlotUI> slotsUI;
        /// <summary>
        /// Reload the button slots, used to download or update save slots.
        /// </summary>
        public void RefreshSlotData()
        {
            int slot = 0;
            foreach (var item in slotsUI)
            {
                slot++;
                MetaData data = GameDataService.Instance.getSaveSlot(slot);
                if (data == null)
                {
                    item.gameObject.SetActive(false);
                    item.hasData = false;
                    continue;
                }
                item.Setup(data);
            }
        }

        #endregion refresh slots

        #region new game

        public void SetCharacterName(string name)
        {
            if (name.Length < 4)
            {
                Debug.Log("Character name must be at least 4 characters long.");
                return;
            }

            NewGameSetup.Instance.SetCharacterName(name);
        }

        public void Create()
        {
            NewGameSetup.Instance.Create();
        }
        #endregion new game

        #region active buttons
        [SerializeField] private List<GameObject> newGameButtons;
        /// <summary>
        /// If there are no more available slots to add, the button will not be displayed.
        /// </summary>
        public void NewGameButtonActive()
        {
            bool active = false;
            if (GameDataService.Instance.getSlotEmpty() != -1)
            {
                active = true;
            }
            foreach (var item in newGameButtons)
            {
                item.SetActive(active);
            }
        }
        #endregion active buttons

        #region delete game
        public void DeleteSaveGame()
        {
            GameDataService.Instance.DeleteSaveGame(selectSlot);
            RefreshSlotData();
            NewGameButtonActive();
        }
        #endregion delete game

        #endregion Load game menu
    }
}
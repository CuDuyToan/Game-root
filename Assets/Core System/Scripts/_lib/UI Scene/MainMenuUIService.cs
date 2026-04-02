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

        private GameDataService dataService;

        private void Awake()
        {
            setSingleton();
        }

        private void OnEnable()
        {
            dataService = GameDataService.Instance;
            LoadSlotData();
        }
        public void Exit()
        {
            dataService.SaveConfigData();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #region Load game menu
        [Header("Load Game")]
        private int selectSlot = -1;
        public void SelectSlot(SlotUI slot)
        {
            selectSlot = slot.SlotIndex;
        }

        public void DeselectSlot()
        {
            selectSlot = -1;
        }


        #region preview map
        [SerializeField] private Slider prreviewMap;
        [SerializeField] private float speedSlider = 5f;
        private Coroutine currentRoutine;
        public void PreviewMap(bool active)
        {
            if (currentRoutine != null) return;

            currentRoutine = StartCoroutine(SmoothMove(active ? 1 : 0));
        }

        private IEnumerator SmoothMove(float target)
        {
            while (true)
            {
                prreviewMap.value = Mathf.MoveTowards(prreviewMap.value, target, speedSlider * Time.deltaTime);

                if (Mathf.Abs(prreviewMap.value - target) < 0.01f)
                {
                    prreviewMap.value = target;
                    currentRoutine = null;
                    yield break;
                }

                yield return null;
            }
        }
        #endregion preview map

        #region load slots
        [SerializeField] private List<SlotUI> slotsUI;
        public void LoadSlotData()
        {
            int slot = 0;
            foreach (var item in slotsUI)
            {
                slot++;
                MetaData data = dataService.getSaveSlot(slot);
                if (data == null)
                {
                    item.gameObject.SetActive(false);
                    item.hasData = false;
                    continue;
                }
                item.Setup(data);
            }
        }

        #endregion load slots

        #region save game

        public void SaveGame()
        {
            dataService.SaveGame(selectSlot);
        }

        #endregion save game

        #region new game
        [Header("New game")]
        [SerializeField] private string newCharacterName;

        public void SetCharacterName(string name)
        {
            newCharacterName = name;
        }

        public void NewGame()
        {
            if(newCharacterName.Length < 4)
            {
                Debug.LogWarning("Character name must be at least 4 characters long.");
                return;
            }

            selectSlot = dataService.addSaveSlot(new MetaData()
            {
                characterName = this.newCharacterName,
            });
        }
        #endregion new game

        #region active buttons
        [SerializeField] private List<GameObject> newGameButtons;
        public void NewGameButtonActive()
        {
            bool active = false;
            if (dataService.getSlotEmpty() != -1)
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
            dataService.DeleteSaveGame(selectSlot);
            LoadSlotData();
        }
        #endregion delete game

        #endregion Load game menu
    }
}
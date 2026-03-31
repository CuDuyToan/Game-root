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
            if (dataService) dataService.SaveSlotData();
        }
        public void Exit()
        {
            if (dataService) dataService.SaveSlotData();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #region Load game menu
        [Header("Load Game")]
        private SlotUI selectSlot;
        public void SelectSlot(SlotUI slot)
        {
            selectSlot = slot;
        }

        public void DeselectSlot()
        {
            selectSlot = null;
        }


        #region preview map
        [SerializeField] private Slider reviewMap;
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
                reviewMap.value = Mathf.MoveTowards(reviewMap.value, target, speedSlider * Time.deltaTime);

                if (Mathf.Abs(reviewMap.value - target) < 0.01f)
                {
                    reviewMap.value = target;
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
            if (dataService == null) return;
            int slot = 0;
            foreach (var item in slotsUI)
            {
                slot++;
                MetaData data = dataService.GetSlotWorld(slot);
                if (data == null)
                {
                    item.gameObject.SetActive(false);
                    item.hasData = false;
                    continue;
                }
                item.Setup(data);
            }

            if(slot > 3)
            {
                activeNewGame(false);
            }
        }

        #endregion load slots

        #region new game
        [Header("New game")]
        [SerializeField] private string characterName;

        public void SetCharacterName(string name)
        {
            characterName = name;
        }

        public void NewGame()
        {
            if(characterName.Length < 4)
            {
                Debug.LogWarning("Character name must be at least 4 characters long.");
                return;
            }

            dataService.NewGame(new MetaData()
            {
                characterName = this.characterName,
            });

            dataService.SaveSlotData();
        }
        #endregion new game

        #region active buttons
        [SerializeField] private List<GameObject> newGameButtons;
        private void activeNewGame(bool active)
        {
            foreach (var item in newGameButtons)
            {
                item.SetActive(active);
            }
        }
        #endregion active buttons

        #region delete game
        public void DeleteSlot()
        {
            int index = selectSlot.SlotIndex;

            dataService.DeleteGame(index);
            LoadSlotData();
        }
        #endregion delete game

        #endregion Load game menu
    }
}
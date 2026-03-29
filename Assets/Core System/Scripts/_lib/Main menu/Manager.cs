using CoreSystem.Data;
using CoreSystem.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.MainMenu
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance { get; private set; }

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private DataManager dataManager;

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            dataManager = DataManager.Instance;
            LoadSlotData();
            dataManager.SaveSlotData();
        }

        public void Exit()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        #region Load game menu
        [Header("Load Game")]
        [SerializeField] private Slider reviewMap;
        [SerializeField] private float targetValue = 1f;
        [SerializeField] private float speed = 1f;
        [SerializeField] private List<GameObject> slots;
        private Coroutine currentRoutine;
        #region preview map
        public void ReviewMap(GameObject obj)
        {
            if (currentRoutine != null) return;

            currentRoutine = StartCoroutine(SmoothMove(reviewMap.value == 0 ? targetValue : 0));
            SetActiveButton(obj);
        }

        private void SetActiveButton(GameObject obj)
        {
            foreach (var item in slots)
            {
                if (obj == item) continue;
                bool active = !item.activeInHierarchy;
                item.SetActive(active);
            }
        }

        private IEnumerator SmoothMove(float target)
        {
            while (true)
            {
                reviewMap.value = Mathf.MoveTowards(reviewMap.value, target, speed * Time.deltaTime);

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
        [SerializeField] private List<SlotSetup> slotSetups;
        public void LoadSlotData()
        {
            if (dataManager == null) return;
            int slot = 1;
            foreach (var item in slotSetups)
            {
                MetaData data = dataManager.GetSlotWorld(slot);
                if (data == null) continue;
                item.Setup(data);
            }
        }


        #endregion load slots

        #endregion Load game menu
    }
}
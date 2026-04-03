using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoreSystem.Persistent
{
    public class GameRoot : MonoBehaviour
    {
        public static GameRoot Instance;
        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        [Header("Scene")]
        [SerializeField] private string UIScene = "UI";
        [SerializeField] private string mainMenuScene = "Main Menu";

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            //SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Additive);
            LoadUIScene();
            LoadMainMenu();
        }

        #region UI
        private void LoadUIScene()
        {
            StartCoroutine(LoadUISceneAsync());
        }

        private IEnumerator LoadUISceneAsync()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(UIScene, LoadSceneMode.Additive);
            while (!op.isDone)
                yield return null;
            Scene scene = SceneManager.GetSceneByName(UIScene);
            SceneManager.SetActiveScene(scene);
        }


        #endregion UI

        #region Main Menu

        public void LoadMainMenu()
        {
            StartCoroutine(LoadMainMenuAsync());
        }

        private IEnumerator LoadMainMenuAsync()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(mainMenuScene, LoadSceneMode.Additive);

            while (!op.isDone)
                yield return null;

            Scene scene = SceneManager.GetSceneByName(mainMenuScene);
            SceneManager.SetActiveScene(scene);
        }

        #endregion Main Menu

        public void Exit()
        {
            GameDataService.Instance.SaveConfigData();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoreSystem
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
        [SerializeField] private string mainMenuScene = "Main Menu";

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            //SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Additive);
            LoadMainMenu();
        }

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
    }

}
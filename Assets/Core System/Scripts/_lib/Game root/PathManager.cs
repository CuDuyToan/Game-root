using System.IO;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public class PathManager : MonoBehaviour
    {
        public static PathManager Instance { get; private set; }

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
            rootPath = Application.persistentDataPath;
        }

        [Header("Root")]
        [SerializeField] private string rootPath;
        [Header("Config")]
        [SerializeField] private string configDataPath = "Configuration";
        public string ConfigDataPath => Path.Combine(rootPath, configDataPath);
        [Header("Save Game")]
        [SerializeField] private string saveGameDataPath = "Save Game";
        public string SaveGameDataPath => Path.Combine(rootPath, saveGameDataPath);
    }

}


using CoreSystem.Data;
using System.IO;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public class SaveSystem : MonoBehaviour
    {
        public static SaveSystem Instance;
        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private string savePath = string.Empty;

        private void Awake()
        {
            setSingleton();
            savePath = Application.persistentDataPath;
        }

        #region init

        private void initFolder(string folder)
        {
            string path = Path.Combine(savePath, folder);
            if (!Directory.Exists(path))
            {
                Debug.Log($"[{folder}] folder not found, creating default.");
                Directory.CreateDirectory(path);
            }
        }

        private void initFile(string folder, string file)
        {
            string path = Path.Combine(savePath, folder, file);
            initFolder(folder);
            if (!File.Exists(path))
            {
                Debug.Log($"[{file}] file not found, creating default.");
                File.WriteAllText(path, string.Empty);
            }
        }

        #endregion init

        public string LoadData(string folder, string file)
        {
            string path = Path.Combine(savePath, folder, file);

            initFile(folder, file);

            return File.ReadAllText(path);
        }

        public void SaveData(string json, string path)
        {
            File.WriteAllText(path, json);
        }

        #region config
        [Header("Config")]
        [SerializeField] private string configFolder = "Configuration";

        [Space(5)]

        [SerializeField] private string soundFile = "Sound";
        [SerializeField] private string layoutFile = "Layout";

        public void SaveSoundConfig(SoundData data)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(savePath, configFolder, soundFile);

            SaveData(json, path);
        }
        public void SaveLayoutConfig(LayoutData data)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(savePath, configFolder, layoutFile);

            SaveData(json, path);
        }

        public string LoadSoundData()
        {
            return LoadData(configFolder, soundFile);
        }

        public string LoadLayoutData()
        {
            return LoadData(configFolder, layoutFile);
        }
        #endregion config

        #region slot world
        [Header("Slot World")]
        [SerializeField] private string WorldFolder = "World";


        #endregion slot world
    }
}


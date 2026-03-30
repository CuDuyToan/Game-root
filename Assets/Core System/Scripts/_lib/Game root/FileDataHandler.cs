using CoreSystem.Data;
using System.IO;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public class FileDataHandler: MonoBehaviour
    {
        public static FileDataHandler Instance;
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
        [SerializeField] private string configFile = "config";

        public void SaveConfig(ConfigData data)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(savePath, configFolder, configFile);
            SaveData(json, path);
        }

        public ConfigData LoadConfig()
        {
            string json = LoadData(configFolder, configFile);
            ConfigData data;
            if (string.IsNullOrEmpty(json))
            {
                data = new ConfigData();
            }
            else
            {
                data = JsonUtility.FromJson<ConfigData>(json);
                if (data == null)
                {
                    data = new ConfigData();
                }
            }
            return data;
        }
        #endregion config

        #region slot world
        [Header("Slot World")]
        [SerializeField] private string worldFolder = "World";
        [Space(5)]
        [SerializeField] private string slotsFile = "slots";

        public SlotsData LoadSlotsData()
        {
            string json = LoadData(worldFolder, slotsFile);

            SlotsData data;

            if (string.IsNullOrEmpty(json))
            {
                data = new SlotsData();
            }
            else
            {
                data = JsonUtility.FromJson<SlotsData>(json);

                if (data == null)
                {
                    data = new SlotsData();
                }
            }

            return data;
        }

        public void SaveSlotWorld(SlotsData data)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(savePath, worldFolder, slotsFile);

            SaveData(json, path);
        }
        #endregion slot world
    }
}


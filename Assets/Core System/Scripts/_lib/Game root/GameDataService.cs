using CoreSystem.Configuration;
using CoreSystem.Data;
using CoreSystem.MainMenu;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public class GameDataService : MonoBehaviour
    {
        public static GameDataService Instance;
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

        private void Start()
        {
            LoadConfigData();
            LoadMetaData();
        }


        #region config
        private ConfigData configData;
        public ConfigData ConfigData => configData;

        /// <summary>
        /// Read config data from the file and save it in cache
        /// </summary>
        private void LoadConfigData()
        {
            string path = Path.Combine(PathManager.Instance.ConfigDataPath, "Config.json");
            configData = FileService.LoadOrCreate<ConfigData>(path);
        }
        /// <summary>
        /// save config data using cache data
        /// </summary>
        public void SaveConfigData()
        {
            if (configData == null) LoadConfigData();
            string path = PathManager.Instance.ConfigDataPath;
            FileService.SaveJsonFile(Path.Combine(path, "Config.json"), configData);
        }
        #endregion config

        #region slot world
        private Dictionary<int, MetaData> metaDatas = new Dictionary<int, MetaData>();
        public Dictionary<int, MetaData> MetaDatas => metaDatas;
        /// <summary>
        /// Read meta files from the folders (save slots). If no save slot is found, skip; if found, read the metadata.json file and save the data into the cache.
        /// if it's first time using default
        /// </summary>
        private void LoadMetaData()
        {
            string saveGamePath = PathManager.Instance.SaveGameDataPath;
            var result = new Dictionary<int, MetaData>();

            if (!Directory.Exists(saveGamePath))
            {
                metaDatas = result;
                return;
            }

            var saveGameFolder = Directory.GetDirectories(saveGamePath);

            foreach (var saveSlot in saveGameFolder)
            {
                string folderName = Path.GetFileName(saveSlot);

                var match = Regex.Match(folderName, @"\d+");

                if (!match.Success)
                    continue;

                int slot = int.Parse(match.Value);

                string path = Path.Combine(saveSlot, "metadata.json");

                if (!File.Exists(path))
                    continue;

                var data = FileService.Load<MetaData>(path);

                if (data != null)
                    result[slot] = data;
            }

            metaDatas = result;
        }

        public MetaData getSaveSlot(int slot)
        {
            if (metaDatas.TryGetValue(slot, out MetaData metaData))
            {
                return metaData;
            }
            return null;
        }

        public int addSlotSave(MetaData meta)
        {
            if(metaDatas.Count < 3)
            {
                int slot = getSlotEmpty();
                if (metaDatas.TryAdd(slot, meta))
                {
                    string path = Path.Combine(PathManager.Instance.SaveGameDataPath, $"Save{slot}", "metadata.json");
                    FileService.SaveJsonFile<MetaData>(path, getSaveSlot(slot));
                    return slot;
                }
            }
            return -1;
        }

        public int getSlotEmpty()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (!metaDatas.ContainsKey(i))
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// delete saveslot in cache and delete save slot in save game folder
        /// </summary>
        /// <param name="slot"></param>
        public void DeleteSaveGame(int slot)
        {
            if (metaDatas.TryGetValue(slot, out MetaData metaData))
            {
                string path = Path.Combine(PathManager.Instance.SaveGameDataPath, $"Save{slot}");
                metaDatas.Remove(slot);
                FileService.DeleteFolder(path);
            }
        }

        public void SaveGame(int slot)
        {
            string path = Path.Combine(PathManager.Instance.SaveGameDataPath, $"Save{slot}", "metadata.json");
            FileService.SaveJsonFile<MetaData>(path, getSaveSlot(slot));
        }
        #endregion slot world

    }
}
using CoreSystem.Configuration;
using CoreSystem.Data;
using CoreSystem.MainMenu;
using System.Collections.Generic;
using System.IO;
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

        private FileService fileService;

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            fileService = FileService.Instance;
            LoadConfigData();
            LoadSlotData();
        }


        #region config
        private ConfigData configData;

        private void LoadConfigData()
        {
            configData = fileService.LoadConfig();
            if(configData == null) configData = new ConfigData();
        }

        public void SaveConfigData()
        {
            if (configData == null) LoadConfigData();
            fileService.SaveConfig(configData);
        }
        public ConfigData GetConfigData()
        {
            if (configData == null) LoadConfigData();
            return configData;
        }


        public SoundData getSound()
        {
            if (configData == null) LoadConfigData();
            return configData.soundData;
        }

        public LayoutData getLayout()
        {
            if (configData == null) LoadConfigData();
            return configData.layoutData;
        }
        #endregion config

        #region slot world
        private SlotsData slotData;
        private readonly Dictionary<int, MetaData> slotWorlds = new Dictionary<int, MetaData>();
        private void LoadSlotData()
        {
            slotData = fileService.LoadSlotsData();

            if (slotData == null)
            {
                slotData = new SlotsData();
                slotData.slots = new List<MetaData>();
            }
            int slotIndex = 0;
            foreach (var item in slotData.slots)
            {
                if (item == null) continue;
                slotIndex++;
                slotWorlds.TryAdd(slotIndex, item);
            }
        }

        public MetaData GetSlotWorld(int slot)
        {
            if (slotWorlds.TryGetValue(slot, out MetaData metaData))
            {
                return metaData;
            }
            return null;
        }

        public void NewGame(MetaData meta)
        {
            if(slotData.slots.Count < 3)
            {
                meta.slot = slotData.slots.Count + 1;
                slotData.slots.Add(meta);
                slotWorlds.TryAdd(meta.slot, meta);
            }
        }

        public void DeleteGame(int slot)
        {
            if (slotWorlds.TryGetValue(slot, out MetaData metaData))
            {
                slotData.slots.Remove(metaData);
                slotWorlds.Remove(slot);
                fileService.DeleteSlot(slot-1);
            }
        }

        public void SaveSlotData()
        {
            if (slotData == null) return;
            fileService.SaveSlotWorld(slotData);
        }
        #endregion slot world

    }
}
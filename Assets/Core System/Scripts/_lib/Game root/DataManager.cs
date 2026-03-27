using CoreSystem.Configuration;
using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private SaveSystem saveSystem;

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            saveSystem = SaveSystem.Instance;
            InitConfig();
        }


        #region config
        private readonly Dictionary<ConfigOptions, Config> configurations = new Dictionary<ConfigOptions, Config>();

        private void InitConfig()
        {
            LayoutData layoutData = JsonUtility.FromJson<LayoutData>(saveSystem.LoadLayoutData());
            SoundData soundData = JsonUtility.FromJson<SoundData>(saveSystem.LoadSoundData());

            LayoutConfig layoutConfig = new LayoutConfig(layoutData);
            SoundConfig soundConfig = new SoundConfig(soundData);

            configurations.TryAdd(ConfigOptions.Layout, layoutConfig);
            configurations.TryAdd(ConfigOptions.Sound, soundConfig);
        }

        public void SaveConfig()
        {
            if(getSound() != null)
            {
                saveSystem.SaveSoundConfig(getSound().getData());
            }

            if(getLayout() != null)
            {
                saveSystem.SaveLayoutConfig(getLayout().getData());
            }
        }

        public SoundConfig getSound()
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                if (!(config is SoundConfig)) return null;

                return config as SoundConfig;
            }
            return null;
        }

        public LayoutConfig getLayout()
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                if (!(config is LayoutConfig)) return null;
                return config as LayoutConfig;
            }

            return null;
        }
        #endregion config

        #region slot world
        private readonly Dictionary<int, MetaData> slotWorlds;



        #endregion slot world

    }
}
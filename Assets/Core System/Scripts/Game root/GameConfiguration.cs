using CoreSystem.Configuration;
using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.Configuration
{
	public class GameConfiguration : MonoBehaviour
	{
        public static GameConfiguration Instance { get; private set; }

        public readonly Dictionary<ConfigOptions, Config> configurations = new Dictionary<ConfigOptions, Config>();

        private string dataPath = string.Empty;

        private string layoutPath;
        private string soundPath;

        private void setPath()
        {
            dataPath = Application.persistentDataPath + "/setting";

            layoutPath = dataPath + "/layout_settings";
            soundPath = dataPath + "/sound_settings";
        }

        private void Awake()
        {
            setSingleton();
            setPath();
        }

        private void Start()
        {
            Init();
        }

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }


        #region public
        public void Save()
        {
            SaveLayout();
            SaveSound();
        }

        #region sound
        public void setMasterVolume(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMasterVolume(value);
            }
        }

        public void setMuteMaster(bool value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMuteMaster(value);
            }
        }

        public void setMusicVolume(float value)
        {
            if(configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMusicVolume(value);
            }
        }
        public void setMuteMusic(bool value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMuteMusic(value);
            }
        }

        public void setSFXVolume(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setSFXVolume(value);
            }
        }
        public void setMuteSFX(bool value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMuteSFX(value);
            }
        }

        public void setUIVolume(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setUIVolume(value);
            }
        }
        public void setMuteUI(bool value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMuteUI(value);
            }
        }

        public void setAmbientVolume(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setAmbientVolume(value);
            }
        }

        public void setMuteAmbient(bool value)
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config config))
            {
                SoundConfig setup = config as SoundConfig;
                setup.setMuteAmbient(value);
            }
        }

        #endregion sound

        #region layout
        public void setJoystickType(JoystickType value)
        {
            if(configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                LayoutConfig setup = config as LayoutConfig;
                setup.setJoystickType(value);
            }
        }

        public void setJoystickPos(Vector2Data value)
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                LayoutConfig setup = config as LayoutConfig;
                setup.setJoystickPos(value);
            }
        }

        public void setActiveZone(Vector2Data value)
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                LayoutConfig setup = config as LayoutConfig;
                setup.setActiveZone(value);
            }
        }

        public void setJoystickSize(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                LayoutConfig setup = config as LayoutConfig;
                setup.setJoystickSize(value);
            }
        }

        public void setTransparencyUI(float value)
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config config))
            {
                LayoutConfig setup = config as LayoutConfig;
                setup.setTransparencyUI(value);
            }
        }


        #endregion layout


        #endregion public

        #region private

        #region load
        private string LoadData(string path)
        {
            if (!File.Exists(path))
            {
                Debug.Log("Settings file not found, creating default.");
                //Directory.CreateDirectory(path);
                return string.Empty;
            }

            return File.ReadAllText(path);
        }
        #endregion load

        #region save
        private void SaveData(string json, string path)
        {
            File.WriteAllText(path, json);
        }
        private void SaveLayout()
        {
            if (configurations.TryGetValue(ConfigOptions.Layout, out Config value))
            {
                var data = value as LayoutConfig;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, layoutPath);
            }
        }

        private void SaveSound()
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Config value))
            {
                var data = value as SoundConfig;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, soundPath);
            }
        }
        #endregion save

        #region init
        private void Init()
        {
            InitFolder();

            LayoutConfig layoutSetup = new LayoutConfig();
            SoundConfig soundSetup = new SoundConfig();

            string layout = JsonUtility.ToJson(layoutSetup.getData(), true);
            InitFile(layoutPath, layout);

            string sound = JsonUtility.ToJson(soundSetup.getData(), true);
            InitFile(soundPath, sound);

            InitConfig();
        }

        private void InitConfig()
        {

            LayoutData layoutData = JsonUtility.FromJson<LayoutData>(LoadData(layoutPath));
            SoundData soundData = JsonUtility.FromJson<SoundData>(LoadData(soundPath));

            LayoutConfig layoutSetup = new LayoutConfig(layoutPath, layoutData);
            SoundConfig soundSetup = new SoundConfig(soundPath, soundData);

            configurations.TryAdd(ConfigOptions.Layout, layoutSetup);
            configurations.TryAdd(ConfigOptions.Sound, soundSetup);
        }

        private void InitFolder()
        {
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
        }

        private void InitFile(string path, string json)
        {
            if (!File.Exists(path))
            {
                SaveData(json, path);
            }
        }
        #endregion init

        #endregion private


    }
}
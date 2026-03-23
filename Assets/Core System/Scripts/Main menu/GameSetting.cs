using CoreSystem.Configuration;
using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CoreSystem.Configuration
{
	public class GameSetting: MonoBehaviour
	{
        public static GameSetting Instance { get; private set; }

        public readonly Dictionary<ConfigOptions, Setting> configurations = new Dictionary<ConfigOptions, Setting>();

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

        public void SaveSetting()
        {
            SaveLayout();
            SaveSound();
        }

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
            if (configurations.TryGetValue(ConfigOptions.Layout, out Setting value))
            {
                var data = value as LayoutSetup;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, layoutPath);
            }
        }

        private void SaveSound()
        {
            if (configurations.TryGetValue(ConfigOptions.Sound, out Setting value))
            {
                var data = value as SoundSetup;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, soundPath);
            }
        }
        #endregion save

        #region init
        private void Init()
        {
            InitFolder();

            LayoutSetup layoutSetup = new LayoutSetup();
            SoundSetup soundSetup = new SoundSetup();

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

            LayoutSetup layoutSetup = new LayoutSetup(layoutPath, layoutData);
            SoundSetup soundSetup = new SoundSetup(soundPath, soundData);

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
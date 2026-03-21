using CoreSystem.Configuration;
using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CoreSystem
{
    public class GameRoot : MonoBehaviour
    {
        public static GameRoot Instance;

        public readonly Dictionary<GameSetting, Setting> configurations = new Dictionary<GameSetting, Setting>();

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

        private void SaveData(string json, string path)
        {
            File.WriteAllText(path, json);
        }

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

        public void SaveSetting()
        {
            SaveLayout();
            SaveSound();
        }

        private void SaveLayout()
        {
            if(configurations.TryGetValue(GameSetting.Layout, out Setting value))
            {
                var data = value as LayoutSetup;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, layoutPath);
            }
        }

        private void SaveSound()
        {
            if(configurations.TryGetValue(GameSetting.Sound, out Setting value))
            {
                var data = value as SoundSetup;
                string json = JsonUtility.ToJson(data.getData());
                SaveData(json, soundPath);
            }
        }

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

            configurations.TryAdd(GameSetting.Layout, layoutSetup);
            configurations.TryAdd(GameSetting.Sound, soundSetup);
        }

        private void InitFolder()
        {
            if(!Directory.Exists(dataPath))
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
    }

}
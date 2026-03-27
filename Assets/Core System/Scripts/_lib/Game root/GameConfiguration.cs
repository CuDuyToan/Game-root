using CoreSystem.Data;
using CoreSystem.Persistent;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Audio.GeneratorInstance;

namespace CoreSystem.Configuration
{
	public class GameConfiguration : MonoBehaviour
	{
        public static GameConfiguration Instance { get; private set; }

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private DataManager dataManager;

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
            dataManager = DataManager.Instance;
        }

        #region sound
        public void setMasterVolume(float value)
        {
            SoundConfig config = dataManager.getSound();
            if(config != null)
            {
                config.masterVolume = value;
            }
        }

        public void setMuteMaster(bool value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.muteMaster = value;
            }
        }

        public void setMusicVolume(float value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.musicVolume = value;
            }
        }
        public void setMuteMusic(bool value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.muteMusic = value;
            }
        }

        public void setSFXVolume(float value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.SFXVolume = value;
            }
        }
        public void setMuteSFX(bool value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.muteSFX = value;
            }
        }

        public void setUIVolume(float value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.UIVolume = value;
            }
        }
        public void setMuteUI(bool value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.muteUI = value;
            }
        }

        public void setAmbientVolume(float value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.ambientVolume = value;
            }
        }

        public void setMuteAmbient(bool value)
        {
            SoundConfig config = dataManager.getSound();
            if (config != null)
            {
                config.muteAmbient = value;
            }
        }

        #endregion sound

        #region layout
        public void setJoystickType(JoystickType value)
        {
            LayoutConfig config = dataManager.getLayout();
            if (config != null)
            {
                config.joystickType = value;
            }
        }

        public void setJoystickPos(Vector2Data value)
        {
            LayoutConfig config = dataManager.getLayout();
            if (config != null)
            {
                config.joystickPos = value;
            }
        }

        public void setActiveZone(Vector2Data value)
        {
            LayoutConfig config = dataManager.getLayout();
            if (config != null)
            {
                config.activeZone = value;
            }
        }

        public void setJoystickSize(float value)
        {
            LayoutConfig config = dataManager.getLayout();
            if (config != null)
            {
                config.joystickSize = value;
            }
        }

        public void setTransparencyUI(float value)
        {
            LayoutConfig config = dataManager.getLayout();
            if (config != null)
            {
                config.transparencyUI = value;
            }
        }
        #endregion layout
    }
}
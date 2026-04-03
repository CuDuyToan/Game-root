using CoreSystem.Data;
using CoreSystem.Persistent;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.UIPersistent
{
    public class Setting : MonoBehaviour
    {
        public static Setting Instance { get; private set; }

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

        private ConfigData configData => GameDataService.Instance.ConfigData;

        private void Start()
        {
            loadSetting();
        }

        public void saveSetting()
        {
            GameDataService.Instance.SaveConfigData();
        }

        private void loadSetting()
        {
            if (!GameDataService.Instance) return;
            loadConfigData();
        }

        private void loadConfigData()
        {
            SoundData soundConfig = configData.soundData;


            loadMasterValue(soundConfig.masterVolume, soundConfig.muteMaster);
            loadMusicValue(soundConfig.musicVolume, soundConfig.muteMusic);
            loadSFXValue(soundConfig.SFXVolume, soundConfig.muteSFX);
            loadUIValue(soundConfig.UIVolume, soundConfig.muteUI);
            loadAmbientValue(soundConfig.ambientVolume, soundConfig.muteAmbient);
        }

        #region set value

        #region sound
        public void setMasterVolume(Slider slider)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.masterVolume = slider.value;
            }
        }

        public void setMuteMaster(Toggle toggle)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.muteMaster = toggle.isOn;
            }
        }

        public void setMusicVolume(Slider slider)
        {
            SoundData data = configData.soundData;
            if(data != null)
            {
                data.musicVolume = slider.value;
            }
        }
        public void setMuteMusic(Toggle toggle)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.muteMusic = toggle.isOn;
            }
        }

        public void setSFXVolume(Slider slider)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.SFXVolume = slider.value;
            }
        }
        public void setMuteSFX(Toggle toggle)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.muteSFX = toggle.isOn;
            }
        }

        public void setUIVolume(Slider slider)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.UIVolume = slider.value;
            }
        }
        public void setMuteUI(Toggle toggle)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.muteUI = toggle.isOn;
            }
        }

        public void setAmbientVolume(Slider slider)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.ambientVolume = slider.value;
            }
        }

        public void setMuteAmbient(Toggle toggle)
        {
            SoundData data = configData.soundData;
            if (data != null)
            {
                data.muteAmbient = toggle.isOn;
            }
        }
        #endregion sound

        #endregion set value

        #region load

        #region sound
        [Header("Sound")]
        [SerializeField] private Slider masterValue;
        [SerializeField] private Toggle masterMute;

        [Space(5)]

        [SerializeField] private Slider musicValue;
        [SerializeField] private Toggle musicMute;

        [Space(5)]

        [SerializeField] private Slider SFXValue;
        [SerializeField] private Toggle SFXMute;

        [Space(5)]

        [SerializeField] private Slider UIValue;
        [SerializeField] private Toggle UIMute;

        [Space(5)]

        [SerializeField] private Slider ambientValue;
        [SerializeField] private Toggle ambientMute;

        public void loadMasterValue(float value, bool mute)
        {
            masterValue.value = value;
            masterMute.isOn = mute;
        }

        public void loadMusicValue(float value, bool mute)
        {
            musicValue.value = value;
            musicMute.isOn = mute;
        }

        public void loadSFXValue(float value, bool mute)
        {
            SFXValue.value = value;
            SFXMute.isOn = mute;
        }

        public void loadUIValue(float value, bool mute)
        {
            UIValue.value = value;
            UIMute.isOn = mute;
        }

        public void loadAmbientValue(float value, bool mute)
        {
            ambientValue.value = value;
            ambientMute.isOn = mute;
        }
        #endregion sound

        #region layout

        // chưa có ý tưởng

        #endregion layout

        #endregion load
    }
}

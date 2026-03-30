using CoreSystem.Configuration;
using CoreSystem.Data;
using CoreSystem.Persistent;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.MainMenu
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

        private GameConfiguration configuration;
        private GameDataService dataService;

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            configuration = GameConfiguration.Instance;
            dataService = GameDataService.Instance;
            loadSetting();
        }

        public void saveSetting()
        {
            dataService.SaveConfigData();
        }

        private void loadSetting()
        {
            if (!dataService) return;
            loadConfigData(dataService.GetConfigData());
        }

        private void loadConfigData(ConfigData config)
        {
            SoundData soundConfig = config.soundData;


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
            configuration.setMasterVolume(slider.value);
        }

        public void setMuteMaster(Toggle toggle)
        {
            configuration.setMuteMaster(toggle.isOn);
        }

        public void setMusicVolume(Slider slider)
        {
            configuration.setMusicVolume(slider.value);
        }
        public void setMuteMusic(Toggle toggle)
        {
            configuration.setMuteMusic(toggle.isOn);
        }

        public void setSFXVolume(Slider slider)
        {
            configuration.setSFXVolume(slider.value);
        }
        public void setMuteSFX(Toggle toggle)
        {
            configuration.setMuteSFX(toggle.isOn);
        }

        public void setUIVolume(Slider slider)
        {
            configuration.setUIVolume(slider.value);
        }
        public void setMuteUI(Toggle toggle)
        {
            configuration.setMuteUI(toggle.isOn);
        }

        public void setAmbientVolume(Slider slider)
        {
            configuration.setAmbientVolume(slider.value);
        }

        public void setMuteAmbient(Toggle toggle)
        {
            configuration.setMuteAmbient(toggle.isOn);
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

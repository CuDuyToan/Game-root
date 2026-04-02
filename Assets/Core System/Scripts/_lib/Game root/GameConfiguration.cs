using CoreSystem.Data;
using CoreSystem.Configuration;
using UnityEngine;

namespace CoreSystem.Persistent
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

        private GameDataService dataService;

        private void Awake()
        {
            setSingleton();
        }

        private void Start()
        {
            dataService = GameDataService.Instance;
        }

        //#region sound
        //public void setMasterVolume(float value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.masterVolume = value;
        //    }
        //}

        //public void setMuteMaster(bool value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.muteMaster = value;
        //    }
        //}

        //public void setMusicVolume(float value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.musicVolume = value;
        //    }
        //}
        //public void setMuteMusic(bool value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.muteMusic = value;
        //    }
        //}

        //public void setSFXVolume(float value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.SFXVolume = value;
        //    }
        //}
        //public void setMuteSFX(bool value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.muteSFX = value;
        //    }
        //}

        //public void setUIVolume(float value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.UIVolume = value;
        //    }
        //}
        //public void setMuteUI(bool value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.muteUI = value;
        //    }
        //}

        //public void setAmbientVolume(float value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.ambientVolume = value;
        //    }
        //}

        //public void setMuteAmbient(bool value)
        //{
        //    SoundData config = dataService.getSound();
        //    if (config != null)
        //    {
        //        config.muteAmbient = value;
        //    }
        //}

        //#endregion sound

        //#region layout
        //public void setJoystickType(JoystickType value)
        //{
        //    LayoutData config = dataService.getLayout();
        //    if (config != null)
        //    {
        //        config.joystickType = value;
        //    }
        //}

        //public void setJoystickPos(Vector2Data value)
        //{
        //    LayoutData config = dataService.getLayout();
        //    if (config != null)
        //    {
        //        config.joystickPos = value;
        //    }
        //}

        //public void setActiveZone(Vector2Data value)
        //{
        //    LayoutData config = dataService.getLayout();
        //    if (config != null)
        //    {
        //        config.activeZone = value;
        //    }
        //}

        //public void setJoystickSize(float value)
        //{
        //    LayoutData config = dataService.getLayout();
        //    if (config != null)
        //    {
        //        config.joystickSize = value;
        //    }
        //}

        //public void setTransparencyUI(float value)
        //{
        //    LayoutData config = dataService.getLayout();
        //    if (config != null)
        //    {
        //        config.transparencyUI = value;
        //    }
        //}
        //#endregion layout
    }
}
using CoreSystem.Data;
using UnityEngine;

namespace CoreSystem.Configuration
{
    public class SoundSetup : Setting
    {
        private float masterVolume = 50f;
        private bool muteMaster = false;
        public float Master => muteMaster ? 0 : masterVolume;

        private float musicVolume = 50f;
        private bool muteMusic = false;
        public float Music => muteMusic ? 0 : musicVolume;

        private float SFXVolume = 50f;
        private bool muteSFX = false;
        public float SFX => muteSFX ? 0 : SFXVolume;

        private float UIVolume = 50f;
        private bool muteUI = false;
        public float UI => muteUI ? 0 : UIVolume;

        private float ambientVolume = 50f;
        private bool muteAmbient = false;
        public float Ambient => muteAmbient ? 0 : ambientVolume;

        #region set volume value

        public void setMasterVolume(float value)
        {
            masterVolume = value;
        }

        public void setMusicVolume(float value)
        {
            musicVolume = value;
        }

        public void setSFXVolume(float value)
        {
            SFXVolume = value;
        }

        public void setUIVolume(float value)
        {
            UIVolume = value;
        }

        public void setAmbientVolume(float value)
        {
            ambientVolume = value;
        }

        #endregion set volume value

        #region set mute volume

        public void setMuteMaster(bool value) { muteMaster = value; }
        public void setMuteMusic(bool value) { muteMusic = value; }
        public void setMuteSFX(bool value) { muteSFX = value; }
        public void setMuteUI(bool value) { muteUI = value; }
        public void setMuteAmbient(bool value) { muteAmbient = value; }

        #endregion set mute volume

        public SoundSetup()
        {

        }

        public SoundSetup(string path, SoundData data)
        {
            DataPath(path);
            if(data != null) LoadData(data);
        }

        private void LoadData(SoundData data)
        {
            masterVolume = data.masterVolume;
            musicVolume = data.musicVolume;
            SFXVolume = data.SFXVolume;
            UIVolume = data.UIVolume;
            ambientVolume = data.ambientVolume;

            muteMaster = data.muteMaster;
            muteMusic = data.muteMusic;
            muteSFX = data.muteSFX;
            muteUI = data.muteUI;
            muteAmbient = data.muteAmbient;
        }

        public SoundData getData()
        {
            SoundData data = new SoundData();
            data.masterVolume = masterVolume;
            data.musicVolume = musicVolume;
            data.SFXVolume = SFXVolume;
            data.UIVolume = UIVolume;
            data.ambientVolume = ambientVolume;
            return data;
        }

    }
}

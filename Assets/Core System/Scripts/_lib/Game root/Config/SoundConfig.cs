using CoreSystem.Data;
using UnityEngine;

namespace CoreSystem.Configuration
{
    public class SoundConfig: Config
    {
        public float masterVolume = 50f;
        public bool muteMaster = false;
        public float Master => muteMaster ? 0 : masterVolume;

        public float musicVolume = 50f;
        public bool muteMusic = false;
        public float Music => muteMusic ? 0 : musicVolume;

        public float SFXVolume = 50f;
        public bool muteSFX = false;
        public float SFX => muteSFX ? 0 : SFXVolume;

        public float UIVolume = 50f;
        public bool muteUI = false;
        public float UI => muteUI ? 0 : UIVolume;

        public float ambientVolume = 50f;
        public bool muteAmbient = false;
        public float Ambient => muteAmbient ? 0 : ambientVolume;

        public SoundConfig()
        {

        }

        public SoundConfig(SoundData data)
        {
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

            data.muteMaster = muteMaster;
            data.muteMusic = muteMusic;
            data.muteSFX = muteSFX;
            data.muteUI = muteUI;
            data.muteAmbient = muteAmbient;
            return data;
        }

    }
}

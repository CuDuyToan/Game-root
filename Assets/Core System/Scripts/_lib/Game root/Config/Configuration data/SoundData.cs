namespace CoreSystem.Data
{
    [System.Serializable]
    public class SoundData
    {
        public float masterVolume;
        public bool muteMaster;

        public float musicVolume;
        public bool muteMusic;

        public float SFXVolume;
        public bool muteSFX;

        public float UIVolume;
        public bool muteUI;

        public float ambientVolume;
        public bool muteAmbient;
    }
}


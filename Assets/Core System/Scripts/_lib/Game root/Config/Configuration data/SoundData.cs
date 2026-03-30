namespace CoreSystem.Data
{
    [System.Serializable]
    public class SoundData
    {
        public float masterVolume = 50f;
        public bool muteMaster = false;

        public float musicVolume = 50f;
        public bool muteMusic = false;

        public float SFXVolume = 50f;
        public bool muteSFX = false;

        public float UIVolume = 50f;
        public bool muteUI = false;

        public float ambientVolume = 50f;
        public bool muteAmbient = false;
    }
}


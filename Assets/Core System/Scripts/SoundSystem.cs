using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem Instance;

    private static float masterVolume = 50f;
    private static bool muteMaster = false;
    public static float Master => muteMaster ? 0 : masterVolume;

    private static float musicVolume = 50f;
    private static bool muteMusic = false;
    public static float Music => muteMusic ? 0 : musicVolume;

    private static float SFXVolume = 50f;
    private static bool muteSFX = false;
    public static float SFX => muteSFX ? 0 : SFXVolume;

    private static float UIVolume = 50f;
    private static bool muteUI = false;
    public static float UI => muteUI ? 0 : UIVolume;

    private static float ambientVolume = 50f;
    private static bool muteAmbient = false;
    public static float Ambient => muteAmbient ? 0 : ambientVolume;

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

}

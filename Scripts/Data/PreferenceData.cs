using UnityEngine;
using System.Collections;

public class PreferenceData  {

    private float soundEffectVolume;

    public float SoundEffectVolume
    {
        get { return soundEffectVolume; }
        set 
        {   
            soundEffectVolume = value;
            PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        
        }
    }
    private float backGroundMusicVolume;

    public float BackGroundMusicVolume
    {
        get { return backGroundMusicVolume; }
        set { backGroundMusicVolume = value;
        PlayerPrefs.SetFloat("backGroundMusicVolume", backGroundMusicVolume);
        }
    }

    private int isVolumeOn;

    public int IsVolumeOn
    {
        get { return isVolumeOn; }
        set {
            isVolumeOn = value;
            PlayerPrefs.SetInt("isVolumeOn", isVolumeOn);
        }
    }

    public void Init(){
        backGroundMusicVolume = PlayerPrefs.GetFloat("backGroundMusicVolume",1.0f);
        soundEffectVolume=PlayerPrefs.GetFloat("soundEffectVolume",1.0f);
        isVolumeOn = PlayerPrefs.GetInt("isVolumeOn", 1);
    }
}

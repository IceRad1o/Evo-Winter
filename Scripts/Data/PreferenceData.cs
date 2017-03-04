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
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        }
    }

    public void Init(){
        backGroundMusicVolume = PlayerPrefs.GetFloat("11");
    }
}

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

    private int[] advancedItem;

    public int[] AdvancedItem
    {
        get { return advancedItem; }
        set {
            advancedItem = value;
            PlayerPrefsX.SetIntArray("adItem", advancedItem);
            }
    }
    private int y;

    public int Y
    {
        get { return y; }
        set
        {
            y = value;
            PlayerPrefs.SetInt("y", y);
        }
    }

    public void Init(){
        backGroundMusicVolume = PlayerPrefs.GetFloat("backGroundMusicVolume",1.0f);
        soundEffectVolume=PlayerPrefs.GetFloat("soundEffectVolume",1.0f);
        isVolumeOn = PlayerPrefs.GetInt("isVolumeOn", 1);
        advancedItem = PlayerPrefsX.GetIntArray("adItem",0,100);
        //y = PlayerPrefs.GetInt("y", 0);
        //Debug.Log("safasasdasdas  " + Y);
        //for (int i = 0; i < 100; i++)
        //{
        //    Debug.Log("the advance : " + i + "    " + advancedItem[i]);
        //}
        Debug.Log("the advance : "  + "    " + advancedItem[2]);
    }
}

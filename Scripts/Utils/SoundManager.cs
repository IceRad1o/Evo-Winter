﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    /*GetInstance
     *@Brief 获取一个SoundManager实例 
     *@Return SoundManager
     */
    static public SoundManager GetInstance()
    {
        if (instance)
            return instance;
        else
        {
            Debug.Log("SoundManager is null !");
            return null;
        }
         
    }

    /*PlayBackGroundMusic
     *@Brief 播放背景音乐 
     *@Param clip 该播放的clip音频
     *@Param loop 是否循环,默认循环 
     */
    public void PlayBackGroundMusic(AudioClip clip,bool loop=true)
    {
        musicSource.loop = loop;
        musicSource.clip = clip;
        musicSource.Play();
    }

    /*PlaySoundEffect
    *@Brief 播放音效 
    *@Param clip 该播放的clip音频
    *@Param loop 是否循环,默认不循环 
    */
    public void PlaySoundEffect(AudioClip clip,bool loop=false)
    {
        efxSource.loop = loop;
        efxSource.clip = clip;
        efxSource.Play();
    }

    /*StopBackGroundMusic
     *@Brief 停止播放背景音乐 
     */
    public void StopBackGroundMusic()
    {
        musicSource.Stop();
    }

    /*StopBackGroundMusic
     *@Brief 停止播放音效 
     */
    public void StopSoundEffect()
    {
        efxSource.Stop();
    }


    /*SetBackGroundMusicVolume
     *@Brief 设置背景音乐音量 
     *@Param float volume 音量大小,范围0-1.0 
     */
    public void SetBackGroundMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    /*SetSoundEffectVolume
     *@Brief 设置背景音乐音量 
     *@Param float 音量大小,范围0-1.0 
     */
    public void SetSoundEffectVolume(float volume)
    {
        efxSource.volume = volume;
    }

    /*PauseBackGroundMusic
     *@Brief 停止播放音乐
     */
    public void PauseBackGroundMusic()
    {
        musicSource.Pause();
    }

    /*PauseSoundEffect
     *@Brief 停止播放音效 
     */
    public void PauseSoundEffect()
    {
        efxSource.Pause();
    }

    /*ResumeBackGroundMusic
     *@Brief 恢复播放音乐 
     */
    public void ResumeBackGroundMusic()
    {
        musicSource.UnPause();
    }

    /*ResumeSoundEffect
     *@Brief 恢复播放音效 
     */
    public void ResumeSoundEffect()
    {
        efxSource.UnPause();
    }

   

    private AudioSource efxSource;   //音效源

    private AudioSource musicSource;    //音乐源

    private static SoundManager instance = null;  //单例

    void Awake()
    {
        if(instance==null)
            instance=this;
        else if(instance!=this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        musicSource = GetComponents<AudioSource>()[0];
        efxSource = GetComponents<AudioSource>()[1];
    }
}

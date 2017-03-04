using UnityEngine;
using System.Collections;

public class SoundManagerTest : MonoBehaviour {

    public AudioClip test1;
    public AudioClip test2;
	// Use this for initialization
	void Start () {
        StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
   
        SoundManager.Instance.PlayBackGroundMusic(test1);
        yield return new WaitForSeconds(2.0f);
        SoundManager.Instance.StopBackGroundMusic();
        yield return new WaitForSeconds(2.0f);
        SoundManager.Instance.PlaySoundEffect(test1,true);
        yield return new WaitForSeconds(2.0f);
        SoundManager.Instance.SetSoundEffectVolume(0.0f);
        yield return new WaitForSeconds(2.0f);
        SoundManager.Instance.SetBackGroundMusicVolume(0.5F);
        yield return new WaitForSeconds(2.0f);
   

    }
	// Update is called once per frame
	void Update () {
	
	}
}

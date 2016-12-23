using UnityEngine;
using System.Collections;

public class SoundManagerTest : MonoBehaviour {

    public AudioClip test1;
    public AudioClip test2;
	// Use this for initialization
	void Start () {
        StartCoroutine(Test());
        SoundManager.GetInstance().PlayBackGroundMusic(test1);
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
   
        SoundManager.GetInstance().PlayBackGroundMusic(test1);
        yield return new WaitForSeconds(2.0f);
        SoundManager.GetInstance().StopBackGroundMusic();
        yield return new WaitForSeconds(2.0f);
        SoundManager.GetInstance().PlaySoundEffect(test1,true);
        yield return new WaitForSeconds(2.0f);
        SoundManager.GetInstance().SetSoundEffectVolume(0.0f);
        yield return new WaitForSeconds(2.0f);
   

    }
	// Update is called once per frame
	void Update () {
	
	}
}

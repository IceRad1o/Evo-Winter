using UnityEngine;
using System.Collections;
/// <summary>
/// FadeIn 淡入
/// 
/// </summary>
public class FadeIn : MonoBehaviour {


    float time;


	// Use this for initialization
	void Start () {
        StartCoroutine(IEumFadeIn());
	}

    IEnumerator IEumFadeIn()
    {
        float speed;
        int count = (int)time * 60 + 1;
        //speed=this.GetComponent<Spri>
        yield return null;
    }
	

}

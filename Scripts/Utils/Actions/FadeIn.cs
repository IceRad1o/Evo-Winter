using UnityEngine;
using System.Collections;
/// <summary>
/// FadeIn 淡入
/// 
/// </summary>
public class FadeIn : MonoBehaviour {


    public float time=1.0f;


	// Use this for initialization
	void Start () {
        StartCoroutine(IEumFadeIn());
	}

    IEnumerator IEumFadeIn()
    {
        float speed;
        int count = (int)time * 60 + 1;
        speed = 255.0f / count;

        while(count--!=0)
        {
            SpriteRenderer[] renders = this.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer r in renders)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);
            }
        }

        yield return null;
    }
	

}

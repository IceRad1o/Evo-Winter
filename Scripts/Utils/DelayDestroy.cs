using UnityEngine;
using System.Collections;

public class DelayDestroy : MonoBehaviour {

    public int  delayTime=1;

    void Start()
    {
        StartCoroutine(Test());
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(delayTime*1.0f);
        Destroy(this);
    }
}

using UnityEngine;
using System.Collections;

public class EsscenceTest : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Test());

    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        EsscenceManager.Instance.CreateEsscence(0);

    }
	

}

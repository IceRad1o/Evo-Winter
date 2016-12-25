using UnityEngine;
using System.Collections;

public class EffectManagerTest : MonoBehaviour {

	
	void Start () {
        StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("this is EffectManager test...");
        EffectManager.GetInstance().InstantiateEffect(0);
    }
}

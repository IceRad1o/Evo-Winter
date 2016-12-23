using UnityEngine;
using System.Collections;

public class AnimationManagerTest : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Test());
      
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("2");
        AnimationManager.GetInstance().PlayAnimation(0);
        yield return new WaitForSeconds(6.0f);
        Debug.Log("6");

        yield return new WaitForSeconds(6.0f);
        Debug.Log("6");
        yield return new WaitForSeconds(6.0f);
        Debug.Log("6");
        yield return new WaitForSeconds(4.0f);
        Debug.Log("4");
        AnimationManager.GetInstance().PlayAnimation(0);
        Debug.Log("0");
    }
	

}

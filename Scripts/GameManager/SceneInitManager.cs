using UnityEngine;
using System.Collections;

public class SceneInitManager : MonoBehaviour {

    public GameObject[] objs;

    public bool test;

	void Start () {
        if (!test)
        {
            foreach (GameObject obj in objs)
            {
                if (obj)
                    Instantiate(obj);
            }
            Destroy(gameObject);
        }
        else
            StartCoroutine(Test());
	
	}

    IEnumerator Test()
    {
        foreach (GameObject obj in objs)
        {
            if(obj)
            Instantiate(obj);
            yield return new WaitForSeconds(2f);
        }
        Destroy(gameObject);
    }
}

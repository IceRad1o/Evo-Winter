using UnityEngine;
using System.Collections;

public class SceneInitManager : MonoBehaviour {

    public GameObject[] objs;
	// Use this for initialization
	void Start () {
	    foreach (GameObject obj in objs)
        {
            Instantiate(obj);
        }
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

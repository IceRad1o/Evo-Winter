using UnityEngine;
using System.Collections;

public class PygmyTrapTrigger : MonoBehaviour {

    public GameObject[] traps;
	// Use this for initialization
	void Start () {
	
	}

    void UseTrap(int type)
    {

            Instantiate(traps[type], this.transform.position, Quaternion.identity);
 
    }
}

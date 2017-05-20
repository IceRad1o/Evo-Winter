using UnityEngine;
using System.Collections;

public class PygmyTrapTrigger : MonoBehaviour {

    public GameObject[] traps;
	// Use this for initialization
	void Start () {
	
	}

    void UseTrap(int type)
    {

            GameObject ins=Instantiate(traps[type], this.transform.position, Quaternion.identity) as GameObject;
            ins.GetComponent<RoomElement>().Master = gameObject;
 
    }
}

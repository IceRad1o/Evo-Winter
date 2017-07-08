using UnityEngine;
using System.Collections;

public class DartTrap : MonoBehaviour {

    public GameObject dart;
	// Use this for initialization
	void Start () {
	
	}

    private void OnTriggerEnter(Collider other)
    {

        if ( other.tag == "Monster")
        {
            int dir = other.GetComponent<Character>().FaceDirection;
            Vector3 pos = other.GetComponent<Character>().transform.position;
            GameObject d=Instantiate(dart, new Vector3(-dir*14, pos.y,pos.z ), Quaternion.identity) as GameObject;
            d.GetComponent<Missiles>().direction = dir;
            d.GetComponent<RoomElement>().Master = this.GetComponent<RoomElement>().Master;
            Destroy(this.gameObject);
        }

    }
}

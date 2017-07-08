using UnityEngine;
using System.Collections;

public class GetPuppet : MonoBehaviour {

    public GameObject puppet;

	// Use this for initialization
	void Start () {
        GameObject obj=Instantiate(puppet, this.transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<Puppet>().owner = this.gameObject;
        obj.GetComponent<RoomElement>().Master = this.GetComponent<RoomElement>();
        obj.GetComponent<Character>().IsInvincible = 1;
	}

}

using UnityEngine;
using System.Collections;

public class GetPuppet : MonoBehaviour {

    public GameObject puppet;

	// Use this for initialization
	void Start () {
        GameObject a=Instantiate(puppet, this.transform.position, Quaternion.identity) as GameObject;
        a.GetComponent<Puppet>().owner = this.gameObject;
	}

}

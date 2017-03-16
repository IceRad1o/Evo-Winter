using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {


	void FixedUpdate () {
        Vector3 temp = this.transform.position;
        temp.z = temp.y;
        this.transform.position = temp;

        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
}

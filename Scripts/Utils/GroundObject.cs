using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {


	void FixedUpdate () {
        Vector3 temp = this.transform.position;
        float a = (temp.y+temp.z)/2;
        temp.y = a;
        temp.z = a;
        this.transform.position = temp;

        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
}

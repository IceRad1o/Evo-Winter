using UnityEngine;
using System.Collections;

public class MisTest : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Missile missile = new Missile();
        missile.SetFlyDistance(5.0f);
        missile.SetFlySpeed(1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

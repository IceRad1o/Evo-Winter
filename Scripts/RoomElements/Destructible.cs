using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Missile" || (other.tag == "Weapon" && Input.GetKeyDown(KeyCode.J)))
        {
            if (this.transform.position.x - other.transform.position.x > 0)
            {

            }
        }
    }
}

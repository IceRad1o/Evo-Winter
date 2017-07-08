using UnityEngine;
using System.Collections;

public class Fire : ExSubject {

    GameObject fatherOb;

    public void Create(GameObject ob) 
    {
        fatherOb = ob;
    }

	// Use this for initialization
	void Start () {
	
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {
            fatherOb.GetComponent<Firewall>().JudgeDamage(other);           
        }

    }
}

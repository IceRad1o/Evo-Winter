using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Firewall : MonoBehaviour {

    public List<GameObject> listEnemy = new List<GameObject>();
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Trigger");
        listEnemy.RemoveAt(0);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {
            foreach (GameObject t in listEnemy) 
            {
                if (t == other.gameObject)
                    return;
            }
            listEnemy.Add(other.gameObject);
            other.gameObject.GetComponent<Character>().Health--;

            StartCoroutine(delay());
        }

    }

}

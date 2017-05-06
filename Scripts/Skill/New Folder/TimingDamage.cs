using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimingDamage : MonoBehaviour {


    public string[] damageTag;

    public float interval=3;

    public List<GameObject> listEnemy = new List<GameObject>();




    private void OnTriggerStay(Collider other)
    {
        foreach (var item in damageTag)
        {
            if (other.tag == item)
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

    IEnumerator delay()
    {
        yield return new WaitForSeconds(interval);
        listEnemy.RemoveAt(0);
    }
}

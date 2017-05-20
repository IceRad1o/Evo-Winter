using UnityEngine;
using System.Collections;

public class Bullet_Blast : MonoBehaviour {

    public GameObject explosion;
    string[] targetTags;

    void Start()
    {
       targetTags = AutoTag.GetTargetTags(this.GetComponent<RoomElement>().Master.tag);
    }


    private void OnTriggerEnter(Collider other)
    {
           for (int i = 0; i < targetTags.Length;i++ )
           {
             if (other.CompareTag(targetTags[i]))
             {
                 UtilManager.Instantiate(explosion, transform.position).GetComponent<RoomElement>().Master = this.GetComponent<RoomElement>().Master;
             }
          }

    }
}

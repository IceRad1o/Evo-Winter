using UnityEngine;
using System.Collections;

public class PTrap_Explosion : MonoBehaviour
{

    public GameObject explosion;
    string masterTag;
    // Use this for initialization
    void Start()
    {
        masterTag = GetComponent<RoomElement>().Master.tag;
    }

    private void OnTriggerEnter(Collider other)
    {



        if (AutoTag.IsEnemyTag(masterTag, other.tag))
        {
            UtilManager.Instantiate(explosion, transform.position).GetComponent<RoomElement>().Master = this.GetComponent<RoomElement>().Master;
            GetComponent<RoomElement>().Destroy();
        }


    }
}

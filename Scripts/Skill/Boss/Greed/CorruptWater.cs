using UnityEngine;
using System.Collections;

public class CorruptWater : MonoBehaviour {


    GameObject boss;

    public GameObject Boss
    {
        get { return boss; }
        set { boss = value; }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            int dmg=1;
            if (Boss != null)
                dmg=Boss.GetComponent<GreedValue>().DmgBuff;
           // Debug.Log(Boss.GetComponent<GreedValue>().Value);
            Player.Instance.Character.Health -= dmg;

            Destroy(gameObject);
        }
        if (other.tag == "Monster")
        {
            if (other.GetComponent<Character>().RoomElementID < 2010)
            {
                other.GetComponent<Character>().Health = 0;

                Destroy(gameObject);
            }
        }
    }
}

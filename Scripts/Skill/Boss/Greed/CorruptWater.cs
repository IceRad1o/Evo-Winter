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
            Debug.Log("dmg"+dmg);
            Player.Instance.Character.Hp -= dmg;

            Destroy(gameObject);
        }
        if (other.tag == "Monster")
        {
            if ((int)other.GetComponent<Character>().RoomElementID < 2010)
            {
                other.GetComponent<Character>().Hp = 0;

                Destroy(gameObject);
            }
        }
    }
}

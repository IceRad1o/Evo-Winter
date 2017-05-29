using UnityEngine;
using System.Collections;

public class PTrap_Frozen : MonoBehaviour {

    
    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            other.GetComponent<Character>().IsFrozen = 1;


            //303111
            //other.GetComponent<BuffManager>().CreateDifferenceBuff(303111);

            //GameObject pfb = Resources.Load("Buffs/Frozen") as GameObject; 
            //Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            //GameObject pfb1 = Instantiate(pfb);
            //pfb1.transform.position = s;



            GetComponent<RoomElement>().Destroy();
        }

    }
}

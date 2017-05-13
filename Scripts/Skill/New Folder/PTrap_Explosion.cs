using UnityEngine;
using System.Collections;

public class PTrap_Explosion : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            int dir = other.GetComponent<Character>().FaceDirection;

            GameObject pfb = Resources.Load("Buffs/Sputtering") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            GameObject pfb1 = Instantiate(pfb);
            pfb1.transform.position = s;


            Debug.Log("Enemy Number:    " + EnemyManager.Instance.EnemyList.Count);
            foreach (var item in EnemyManager.Instance.EnemyList)
            {
                
                if (item != null && item.tag == "Monster")
                {
                    var i = (item.transform.position.x - other.transform.position.x) * (item.transform.position.x - other.transform.position.x) + (item.transform.position.y - other.transform.position.y) * (item.transform.position.y - other.transform.position.y);
                    Debug.Log("dir   " + i);
                    
                    if (i <= 16)
                        item.GetComponent<Character>().Hp--;
                }

            }

            other.GetComponent<Character>().Hp--;

            Destroy(this.gameObject);
        }

    }
}

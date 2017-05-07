using UnityEngine;
using System.Collections;

public class Bullet_Blast : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            int dir = other.GetComponent<Character>().FaceDirection;

            GameObject pfb = Resources.Load("Buffs/Sputtering") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            GameObject pfb1 = Instantiate(pfb);
            pfb1.transform.position = s;

            foreach (var item in EnemyManager.Instance.EnemyList)
            {
                if (item != null && item.tag == "Monster")
                {
                    var i = (item.transform.position.x - other.transform.position.x) * (item.transform.position.x - other.transform.position.x) + (item.transform.position.y - other.transform.position.y) * (item.transform.position.y - other.transform.position.y);
                    if (i <= 16)
                        item.GetComponent<Character>().Health--;
                }

            }

            //other.GetComponent<Character>().Health--;

            Destroy(this.gameObject);
        }

    }
}

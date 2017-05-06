using UnityEngine;
using System.Collections;

public class Bullet_SpeedDown : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            foreach (var item in other.gameObject.GetComponents<BuffChangeAttributeTemp>())
            {
                if (item != null && item.SpecialTag == "Bullet")
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
            
            other.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502111, "Bullet");
            Destroy(this.gameObject);
        }

    }


}

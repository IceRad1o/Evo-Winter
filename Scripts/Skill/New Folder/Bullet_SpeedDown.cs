using UnityEngine;
using System.Collections;

public class Bullet_SpeedDown : MonoBehaviour {
    string[] targetTags;

    void Start()
    {
        targetTags = AutoTag.GetTargetTags(this.GetComponent<RoomElement>().Master.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < targetTags.Length; i++)
        {
            if (other.CompareTag(targetTags[i]))
            {
                foreach (var item in other.gameObject.GetComponents<BuffChangeAttributeTemp>())
                {
                    if (item != null && item.SpecialTag == "Bullet")
                    {
                        this.GetComponent<RoomElement>().Destroy();
                        return;
                    }
                }
                if(other.GetComponent<BuffManager>())
                    other.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502111, "Bullet");
                // Destroy(this.gameObject);
            }
        }

    }


}

using UnityEngine;
using System.Collections;

public class FogChangeAttribute : MonoBehaviour {

    public int buffID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Fag Trigger");
            other.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(buffID, "Fag");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((buffID / 10) % 100 == 11)
            {
                Debug.Log("Fag Leave");
                foreach (var item in other.gameObject.GetComponents<BuffChangeAttributeTemp>())
                {
                    Debug.Log("Fag Judge "+item.SpecialTag);
                    if (item.SpecialTag == "Fag")
                    {
                        Debug.Log("Fag Dess");
                        item.DestroyBuff();
                    }
                }
            }
        }

    }

}

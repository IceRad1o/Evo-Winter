using UnityEngine;
using System.Collections;

public class FogChangeAttribute : MonoBehaviour {

    public int buffID;
    public string triggerTag="Monster";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter    :" + other.tag);
        if (other.tag == triggerTag)
        {
            other.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(buffID, "Fag");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggerTag)
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

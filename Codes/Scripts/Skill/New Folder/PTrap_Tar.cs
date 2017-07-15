using UnityEngine;
using System.Collections;

public class PTrap_Tar : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            var pfb= UtilManager.Instance.CreateEffcet("Prefabs/Skill/Skill4", this.transform.position);
            pfb.GetComponent<FogChangeAttribute>().triggerTag = "Monster";
            GetComponent<RoomElement>().Destroy();
            
        }

    }
}

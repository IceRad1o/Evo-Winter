using UnityEngine;
using System.Collections;

public class PTrap_Tar : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            UtilManager.Instance.CreateEffcet("Skill/Skill4",this.transform.position);            
        }

    }
}

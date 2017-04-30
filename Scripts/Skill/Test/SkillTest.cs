using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

    public GameObject pfb;

	void Start () {
        if(this.tag=="Player")
            StartCoroutine(Test());
        
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        //this.gameObject.GetComponent<SkillManager>().CreateSkill(4);
        //this.gameObject.GetComponent<SkillManager>().CreateSkill(3);

        UtilManager.Instance.CreateEffcet(pfb);
    }
	
}

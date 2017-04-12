using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

	void Start () {
        if(this.tag=="Player")
            StartCoroutine(Test());
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.0f);
        this.gameObject.GetComponent<SkillManager>().CreateSkill(402);
        //this.gameObject.GetComponent<SkillManager>().CreateSkill(3);


    }
	
}

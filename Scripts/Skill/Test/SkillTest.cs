using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

    System.DateTime oldTime;

	void Start () {
        if(this.tag=="Player")
            StartCoroutine(Test());

        oldTime = System.DateTime.Now;

        
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        //this.gameObject.GetComponent<SkillManager>().CreateSkill(402);
        //this.gameObject.GetComponent<SkillManager>().CreateSkill(3);
        System.DateTime nowTime=System.DateTime.Now;
        Debug.Log("sub     :" + ((oldTime.Minute - nowTime.Minute)*60+oldTime.Second-nowTime.Second));
    }
	
}

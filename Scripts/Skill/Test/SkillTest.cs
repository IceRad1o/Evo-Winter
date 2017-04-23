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
        EsscenceManager.Instance.CreateEsscence(3);
        EsscenceManager.Instance.CreateEsscence(3);
        EsscenceManager.Instance.CreateEsscence(3);
        EsscenceManager.Instance.CreateEsscence(3);
    }
	
}

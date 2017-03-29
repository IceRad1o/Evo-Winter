using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

	void Start () {
        StartCoroutine(Test());
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.0f);
        this.gameObject.GetComponent<SkillManager>().CreateSkill(4);


    }
	
}

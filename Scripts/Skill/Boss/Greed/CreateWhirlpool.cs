using UnityEngine;
using System.Collections;

public class CreateWhirlpool : Skill{

    public GameObject whirlpool;

    public override void Trigger()
    {
        Cd = 100;
        base.Trigger();
        StartCoroutine(SkillTrigger());
    }

    private IEnumerator SkillTrigger()
    {

        yield return new WaitForSeconds(0.3f);
        Instantiate(whirlpool,gameObject.transform.position,Quaternion.identity);
    }
	

}

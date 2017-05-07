using UnityEngine;
using System.Collections;

public class CreateWhirlpool : Skill{

    public GameObject whirlpool;

    public override void Trigger()
    {
        Cd = Random.Range(25,35);
        base.Trigger();
        StartCoroutine(SkillTrigger());
    }

    private IEnumerator SkillTrigger()
    {

        yield return new WaitForSeconds(0.3f);
        GameObject ins= Instantiate(whirlpool,gameObject.transform.position,Quaternion.identity) as GameObject;
        ins.GetComponent<TimingDamage>().owner = gameObject;
    }
	

}

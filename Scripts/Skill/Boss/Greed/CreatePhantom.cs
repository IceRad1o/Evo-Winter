using UnityEngine;
using System.Collections;
/// <summary>
/// 创建幻象
/// </summary>
public class CreatePhantom : Skill {


    public GameObject faker;

    public override void Trigger()
    {
        Cd = 100;
        base.Trigger();
        StartCoroutine(SkillTrigger());
    }

    private IEnumerator SkillTrigger()
    {

        yield return new WaitForSeconds(0.3f);
        GameObject a=Instantiate(faker,this.transform.position,Quaternion.identity) as GameObject;
        a.GetComponent<Character>().Health=10 ;

        GameObject b = Instantiate(faker, this.transform.position,Quaternion.identity) as GameObject;
        b.GetComponent<Character>().Health = 10;

        a.AddComponent<MoveBy>().deltaPosition = new Vector3(5, 2, 0);

        b.AddComponent<MoveBy>().deltaPosition = new Vector3(-5, -2, 0);
    }
	
}

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
        a.GetComponent<RoomElement>().Master = GetComponent<RoomElement>();
       // a.GetComponent<RoomElement>().trueBoss = gameObject;
        GameObject b = Instantiate(faker, this.transform.position,Quaternion.identity) as GameObject;
        b.GetComponent<RoomElement>().Master = GetComponent<RoomElement>();
       // b.GetComponent<RoomElement>().trueBoss = gameObject;

        a.AddComponent<MoveBy>().deltaPosition = new Vector3(5, 2, 0);

        b.AddComponent<MoveBy>().deltaPosition = new Vector3(-5, -2, 0);
    }
	
}

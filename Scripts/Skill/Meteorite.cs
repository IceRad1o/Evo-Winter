using UnityEngine;
using System.Collections;

public class Meteorite : Skill {

    public override void Create(int ID)
    {
        base.Create(ID);
        SkillID = ID;
        LeadingTime = 0.0f;
        Cd = 10.0f;

        StartCoroutine(delay(2.0f));
    }

    public override void Trigger()
    {
        base.Trigger();





        StartCoroutine(delay(Cd));
    }

    private IEnumerator SkillTrigger(float time)
    {

        yield return new WaitForSeconds(time);

        GameObject pfb = Resources.Load("Skill/Stone") as GameObject;
        GameObject prefabInstance = Instantiate(pfb, new Vector3(1, 1, 1), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;
        
    
    }
}

using UnityEngine;
using System.Collections;

public class Meteorite : Skill {

    public override void Create(int ID)
    {
        SkillID = ID;
        LeadingTime = 0.0f;
        Cd = 10.0f;

        StartCoroutine(delay(1.0f));
    }

    public override void Trigger()
    {
        base.Trigger();
        System.Random random = new System.Random();
        StartCoroutine(SkillTrigger(random.Next(3) * 1.0f));
        StartCoroutine(SkillTrigger(random.Next(3) * 1.0f));
        StartCoroutine(SkillTrigger(random.Next(3) * 1.0f));



        StartCoroutine(delay(Cd));
    }
    /// <summary>
    /// 触发生成陨石
    /// </summary>
    /// <param name="time">延迟出现的时间</param>
    /// <returns></returns>
    private IEnumerator SkillTrigger(float time)
    {

        yield return new WaitForSeconds(time);

        System.Random random = new System.Random();
        GameObject pfb = Resources.Load("Skill/Stone") as GameObject;
        GameObject prefabInstance = Instantiate(pfb, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;
        
    
    }
}

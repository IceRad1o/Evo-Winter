using UnityEngine;
using System.Collections;

public class Meteorite : Skill {
    
    
    public override void Create(int ID)
    {
        SkillID = ID;
        LeadingTime = 0.0f;
        Cd = 10.0f;
        StartCoroutine(DelayTrigger(1.0f));
    }

    public override void Trigger()
    {
        base.Trigger();
        System.Random random = new System.Random();
        StartCoroutine(SkillTrigger(random.Next(50) * 0.1f));
        StartCoroutine(SkillTrigger(random.Next(50) * 0.1f));
        StartCoroutine(SkillTrigger(random.Next(50) * 0.1f));



        StartCoroutine(DelayTrigger(Cd));

    }
    /// <summary>
    /// 触发生成陨石
    /// </summary>
    /// <param name="time">延迟出现的时间</param>
    /// <returns></returns>
    private IEnumerator SkillTrigger(float time)
    {
        Vector3 s = new Vector3(Random.value * 12 - 6, 30, (float)(Random.value*(-40))*0.1f);

        yield return new WaitForSeconds(time - 1.0f);
        GameObject pfb = Resources.Load("Prefabs/Skill/Aim") as GameObject;
        pfb.AddComponent<ChangeScale>();
        GameObject prefabInstance = Instantiate(pfb, new Vector3(s.x, s.z, s.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;


        yield return new WaitForSeconds(0.0f);


        pfb = Resources.Load("Prefabs/Skill/Stone") as GameObject;
        prefabInstance = Instantiate(pfb, s, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;
        
    
    }

    
}

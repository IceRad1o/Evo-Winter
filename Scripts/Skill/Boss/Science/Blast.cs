using UnityEngine;
using System.Collections;

public class Blast : Skill {

    public GameObject blast_Effect;

    public override void Trigger()
    {
        base.Trigger();

        StartCoroutine(SkillTrigger());
    }


    /// <summary>
    /// 延迟触发
    /// </summary>
    /// <param name="time">延迟出现的时间</param>
    /// <returns></returns>
    private IEnumerator SkillTrigger()
    {
        yield return new WaitForSeconds(0.0f);
        GameObject pfb = UtilManager.Instance.CreateEffcet("Skill/Aim", this.gameObject.transform.position);  
        pfb.AddComponent<ChangeScale>();
        pfb.GetComponent<ChangeScale>().duration = 0.4f;
        pfb.GetComponent<ChangeScale>().proportion = 1.0f;
        pfb.GetComponent<ChangeScale>().intervalTime = 0.1f;
        pfb.GetComponent<ChangeScale>().stopTime = 1.0f;





        yield return new WaitForSeconds(1.0f);

        this.gameObject.GetComponent<Character>().Health = 0;

        if (blast_Effect != null)
            UtilManager.Instance.CreateEffcet(blast_Effect, this.gameObject.transform.position);

        ////判断人物与Boss的距离
        //Vector3 pos = this.gameObject.transform.position;
        //Vector3 posJudge = Player.Instance.gameObject.transform.position;
        //var i = (pos.x - posJudge.x) * (pos.x - posJudge.x) + (pos.y - posJudge.y) * (pos.y - posJudge.y);

        //if (i < 16)
        //    Player.Instance.GetComponent<Character>().Health--;
    }




    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

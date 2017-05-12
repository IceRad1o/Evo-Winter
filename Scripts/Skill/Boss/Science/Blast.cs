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
   
        GameObject pfb = UtilManager.Instance.CreateEffcet("Skill/Boss/Science/ExplosionCircle", this.gameObject.transform.position);  






        yield return new WaitForSeconds(2.0f);

        this.gameObject.GetComponent<Character>().Hp = 0;

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

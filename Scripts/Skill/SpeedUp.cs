using UnityEngine;
using System.Collections;

public class SpeedUp : Skill {

    public override void Create(int ID)
    {
        base.Create(ID);
        State = 0;
        Player.Instance.Character.AddObserver(this);
    }

    public override void Trigger()
    {
        base.Trigger();
        this.gameObject.GetComponent<BuffManager>().CreateBuff(1020701110);
        State = 1;
        StartCoroutine(SkillCD(5 * 1.0f));
    }

    private IEnumerator SkillCD(float time)
    {

        yield return new WaitForSeconds(time);

        State = 0;
    }
	// Use this for initialization
	void Start () {
	
	}
    /// <summary>
    /// L键的属性攻击消息获取
    /// </summary>
    /// <param name="msg"></param>
    public override void OnNotify(string msg)
    {
        //if (UtilManager.Instance.GetFieldFormMsg(msg, 0) == "AttackStart" && UtilManager.Instance.GetFieldFormMsg(msg, 1) == "L")
        if (UtilManager.Instance.MatchFiledFormMsg("AttackStart",msg,0)=="L")
        {
            if (State==0)
                Trigger();
        }

    }

}

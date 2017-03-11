using UnityEngine;
using System.Collections;

public class SpeedUp : Skill {

    public override void Create(int ID)
    {
        base.Create(ID);
        State = 0;
    }

    public override void Trigger()
    {
        base.Trigger();


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
        if (UtilManager.Instance.GetFieldFormMsg(msg, 0) == "AttackStart" && UtilManager.Instance.GetFieldFormMsg(msg, 1) == "L")
        {
            if (State==0)
                Trigger();
        }

    }

}

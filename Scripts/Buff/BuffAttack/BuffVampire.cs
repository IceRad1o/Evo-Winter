using UnityEngine;
using System.Collections;

public class BuffVampire : BuffAttack
{

    protected override void Trigger()
    {
        if (!JudgeTrigger())
            return;
        this.gameObject.GetComponent<Character>().Health++;
    }


	
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

	}

    protected override void Create(int ID)
    {
        base.Create(ID);
    } 


    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.MatchFiledFormMsg("Attck", msg, 0) != "Fail")
            Trigger();
        //test
        //if (msg == "AttackHit")
        if (msg == "AttackStart")
        {
            Debug.Log("Get msg");
            Trigger();
        }
        //need 房间结束消息
        if (UtilManager.Instance.MatchFiledFormMsg("。。。。", msg, 0) != "Fail")
        {
            buffDuration--;
            if (buffDuration <= 0 && effectDuration == 0)
                DestroyBuff();
        }
    }
	
}

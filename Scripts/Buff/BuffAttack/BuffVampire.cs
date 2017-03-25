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

        //添加特效
        GameObject pfb = Resources.Load("Buffs/Attack/BuffVampire") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.GetComponent<CharacterSkin>().Weapon.transform;
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

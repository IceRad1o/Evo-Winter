using UnityEngine;
using System.Collections;

public class AttackFrozen : BuffAttack {

    int enemyID;
    

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            if (CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffFrozen>() != null)
                CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffFrozen>().Trigger();
            else
                CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(303111);
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);

        //添加特效
        UtilManager.Instance.CreateEffcet("Buffs/Attack/AttackFrozen",this.gameObject.GetComponent<CharacterSkin>().weapons[0]);

    }

    // Use this for initialization
    void Start()
    {

    }

    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (judgeTag(bID))
        {
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            enemyID = int.Parse(bID);
            Trigger();
        }
    }
}

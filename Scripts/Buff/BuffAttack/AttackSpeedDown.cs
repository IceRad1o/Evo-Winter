using UnityEngine;
using System.Collections;

public class AttackSpeedDown : BuffAttack {

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            EnemyManager.Instance.EnemyList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(1020702111);
            EnemyManager.Instance.EnemyList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(1030702111);
        }

    }
    protected override void Create(int ID)
    {
        Probability = 50;
        BuffID = ID;
    }

	// Use this for initialization
	void Start () {
	
	}

    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("Enemy Hit", msg, 0);
        if (bID!="Fail")
        {
            enemyID = int.Parse(bID);
            Trigger();
        }
    }
	
}

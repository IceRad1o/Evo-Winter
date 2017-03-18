using UnityEngine;
using System.Collections;

public class AttackSpeedDown : BuffAttack {

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            Debug.Log("gggg");
            if (CharacterManager.Instance.CharacterList.Count <= enemyID)
                Debug.Log("Error");
            CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(1020702111);
            CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(1030702111);
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);
        Probability = 100;
    }

	// Use this for initialization
	void Start () {
	
	}

    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (bID=="Enemy")
        {
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            enemyID = int.Parse(bID);
            Trigger();
        }
    }
	
}

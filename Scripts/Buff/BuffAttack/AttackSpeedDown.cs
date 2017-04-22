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
        Probability = 10;
        
        //添加特效
        GameObject pfb = Resources.Load("Buffs/Attack/AttackSpeedDown") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.GetComponent<CharacterSkin>().Weapon.transform;
        prefabInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

	// Use this for initialization
	void Start () {
	
	}

    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (bID == "Monster")
        {
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            enemyID = int.Parse(bID);
            Trigger();
        }
    }
	
}

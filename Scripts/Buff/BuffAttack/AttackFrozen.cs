using UnityEngine;
using System.Collections;

public class AttackFrozen : BuffAttack {

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(303111);
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);
        Probability = 10;

        //添加特效
        GameObject pfb = Resources.Load("Buffs/Attack/AttackFrozen") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.GetComponent<CharacterSkin>().weapons[0].transform;
        prefabInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    // Use this for initialization
    void Start()
    {

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

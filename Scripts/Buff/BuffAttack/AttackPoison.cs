using UnityEngine;
using System.Collections;

public class AttackPoison : BuffAttack
{

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            CharacterManager.Instance.CharacterList[enemyID].GetComponent<BuffManager>().CreateDifferenceBuff(605111);
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);
        Probability = 10;
        GameObject []weapons=this.gameObject.GetComponent<CharacterSkin>().weapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            //添加特效
            GameObject pfb = Resources.Load("Buffs/Attack/AttackStatic") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            prefabInstance = Instantiate(pfb);
            prefabInstance.transform.position = s;
            prefabInstance.transform.parent = weapons[i].transform;
            prefabInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

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

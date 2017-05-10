using UnityEngine;
using System.Collections;

public class AttackSputtering : BuffAttack {

    GameObject pfb1;

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            GameObject pfb = Resources.Load("Buffs/Sputtering") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            pfb1 = Instantiate(pfb);
            pfb1.transform.position = s;
            pfb1.transform.parent = CharacterManager.Instance.CharacterList[enemyID].gameObject.transform;
            pfb1.transform.localScale = new Vector3(1, 1, 1);

            foreach (var item in CharacterManager.Instance.CharacterList)
            {
                if (item != null && item != CharacterManager.Instance.CharacterList[enemyID] && item.tag == "Monster")
                {
                    var i = (item.transform.position.x - CharacterManager.Instance.CharacterList[enemyID].gameObject.transform.position.x) * (item.transform.position.x - CharacterManager.Instance.CharacterList[enemyID].gameObject.transform.position.x) + (item.transform.position.y - CharacterManager.Instance.CharacterList[enemyID].gameObject.transform.position.y) * (item.transform.position.y - CharacterManager.Instance.CharacterList[enemyID].gameObject.transform.position.y);
                    if (i <= 16)
                        item.GetComponent<Character>().Hp-=this.GetComponent<Character>().Atk;
                    //item.GetComponent<Character>().Health -= 10;
                }
            }
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);
        Probability = 10;

        //添加特效
        GameObject pfb = Resources.Load("Buffs/Attack/AttackStatic") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.GetComponent<CharacterSkin>().Weapon.transform;
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

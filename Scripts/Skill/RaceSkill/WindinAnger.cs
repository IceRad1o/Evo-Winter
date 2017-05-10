using UnityEngine;
using System.Collections;

public class WindinAnger : Skill {

    int enemyID;

    public override void Trigger()
    {
        if (JudgeTrigger())
        {
            CharacterManager.Instance.CharacterList[enemyID].GetComponent<Character>().Hp--;
        }

    }
    public override void Create(int ID)
    {
        base.Create(ID);
        Probability = 100;

        Debug.Log("WindinAnger Create");
        //添加特效
        GameObject pfb = Resources.Load("Buffs/Attack/AttackStatic") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.GetComponent<CharacterSkin>().Weapon.transform;
        prefabInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    public override void skillDestory()
    {
        Destroy(prefabInstance);
        Destroy(gameObject);
        //base.skillDestory();
    }

    void Start()
    {
        Player.Instance.Character.AddObserver(this);
 
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

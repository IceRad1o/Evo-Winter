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
        prefabInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    } 


    public override void OnNotify(string msg)
    {

        string bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);

        if (bID == "Enemy") 
        {
            Trigger();       
        }        
    }
	
}

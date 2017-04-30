using UnityEngine;
using System.Collections;

public class AttributeRandom : BuffTiming {

    /// <summary>
    /// 保存原有属性，MoveSpeed ， AttackRange ， AttackSpeed ，HitRecover ， Luck
    /// </summary>
    int[] attribute_old=new int[5];

    public override void Trigger()
    {
        int sum = 0;
        attribute_old[0] = Player.Instance.GetComponent<Character>().MoveSpeed;
        attribute_old[1] = Player.Instance.GetComponent<Character>().AttackRange;
        attribute_old[2] = Player.Instance.GetComponent<Character>().AttackSpeed;
        attribute_old[3] = Player.Instance.GetComponent<Character>().HitRecover;
        attribute_old[4] = Player.Instance.GetComponent<Character>().Luck;





        for (int i = 0; i <= 4; i++)
            sum += attribute_old[i];



    }


    public override void DestroyBuff()
    {
        Player.Instance.GetComponent<Character>().RemoveObserver(this);
        
        base.DestroyBuff();
    }
    
    
    public override void Create(int ID, string spTag = "")
    {
        SpecialTag = spTag;
        BuffID = ID;
        Player.Instance.GetComponent<Character>().AddObserver(this);
        Trigger();
    }


    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "Die" && UtilManager.Instance.GetFieldFormMsg(msg, 0) == "Boss")
        {
            this.DestroyBuff();        
        }
    }

}

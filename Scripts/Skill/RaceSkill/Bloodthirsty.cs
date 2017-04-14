using UnityEngine;
using System.Collections;

public class Bloodthirsty : Skill {
    int damage = 0;
    public int damageMax = 10;



    public override void Trigger()
    {
        if (damage < damageMax)
            damage++;
        else
        {
            damage = 0;
            this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1030702110);            
        }
                
    }


    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (bID == "Enemy")
        {
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            Trigger();
        }

        bID = UtilManager.Instance.MatchFiledFormMsg("LeaveRoom", msg, 0);
        if (bID != "Fail")
        {
            damage = 0;        
        }
    }



    void Start()
    {
        Player.Instance.Character.AddObserver(this);
    }

}

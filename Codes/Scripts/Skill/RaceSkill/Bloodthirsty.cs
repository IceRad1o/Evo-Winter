using UnityEngine;
using System.Collections;

public class Bloodthirsty : Skill {
    int damage = 0;
    public int damageMax = 10;
    int addNumber = 0;
    public int addNumberMax = 2;



    public override void Trigger()
    {
        if (damage < damageMax)
            damage++;
        else
        {
            Debug.Log("Seccess!");
            damage = 0;
            if (addNumber < addNumberMax)
            {
                this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1030701110);
                addNumber++;
            }      
        }
                
    }


    public override void OnNotify(string msg)
    {
        string bID = "";
        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (bID == "Monster")
        {
            Debug.Log("Hit");
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            Trigger();
        }

        bID = UtilManager.Instance.MatchFiledFormMsg("LeaveRoom", msg, 0);
        if (bID != "Fail")
        {
            damage = 0;
            addNumber = 0;
        }
    }



    void Start()
    {
        Player.Instance.Character.AddObserver(this);
        RoomManager.Instance.AddObserver(this);
    }

}

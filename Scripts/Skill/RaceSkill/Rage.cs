using UnityEngine;
using System.Collections;

public class Rage : Skill {

    bool isTrigger=false;


    public override void Trigger()
    {
        Debug.Log("Rage Trigger");
        if (this.GetComponent<Character>().Health <= 3 && !isTrigger)
        {
            isTrigger = !isTrigger;
            this.GetComponent<BuffManager>().CreateDifferenceBuff(1050001110, "Rage");
        }
        if (this.GetComponent<Character>().Health >= 4 && isTrigger)
        {
            isTrigger = !isTrigger;
            foreach (var item in this.GetComponents<BuffChangeAttributeTemp>())
            {
                if (item.SpecialTag == "Rage")
                    item.DestroyBuff();
            }
        
        }
    
    }

    public override void skillDestory()
    {
        foreach (var item in this.GetComponents<BuffChangeAttributeTemp>())
        {
            if (item.SpecialTag == "Rage")
                item.DestroyBuff();
        }

        Destroy(this);
    }



    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }

    void Start()
    {
        Player.Instance.Character.AddObserver(this);
    }

    public override void OnNotify(string msg)
    {
        //Debug.Log(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "HealthChanged"  && UtilManager.Instance.GetFieldFormMsg(msg, 2) == "Player")
        {
            Trigger();
        }
    }


    

}

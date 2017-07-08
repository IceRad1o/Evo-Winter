using UnityEngine;
using System.Collections;

public class Greedy : Skill {

    int itemUsingNumber = 0, itemUsingNumber_Max = 3;
    int addLuck = 0;


    public override void Create(int ID)
    {
        base.Create(ID);
        ItemManager.Instance.AddObserver(this);
    }

    public override void Trigger()
    {
        if (itemUsingNumber < itemUsingNumber_Max)
            itemUsingNumber++;
        else
        {
            addLuck++;
            itemUsingNumber = 0;
            this.GetComponent<Character>().Luk++;
        }
    }

    public override void skillDestory()
    {
        itemUsingNumber = 0;
        this.GetComponent<Character>().Luk -= addLuck;

        ItemManager.Instance.RemoveObserver(this);
        base.skillDestory();
    }

    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "UseItem_Skill_ID")
        {
            Trigger();
        }
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "UseItem_Buff_ID")
        {
            Trigger();
        }

    }
}

using UnityEngine;
using System.Collections;

public class AllSleep : Skill {


    public override void Create(int ID)
    {
        base.Create(ID);
        RoomManager.Instance.AddObserver(this);
    }


    public override void skillDestory()
    {
        RoomManager.Instance.RemoveObserver(this);
        base.skillDestory();
    }

    public override void Trigger()
    {
        //全体减速
        foreach (var item in CharacterManager.Instance.CharacterList.ToArray())
        {
            if (item != null && item.tag == "Monster" && (int)(Random.value*100)>50)
            {
                item.GetComponent<BuffManager>().CreateDifferenceBuff(1031002111);
            }
        }
    }

    public override void OnNotify(string msg)
    {

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "EnterRoom")
            Trigger();

    }
}

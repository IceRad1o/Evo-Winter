using UnityEngine;
using System.Collections;

public class Sleep : Skill {

    int killMonster = 0;

    public override void Create(int ID)
    {
        base.Create(ID);
        Player.Instance.Character.AddObserver(this);
        RoomManager.Instance.AddObserver(this);
    }


    public override void skillDestory()
    {
        Player.Instance.Character.RemoveObserver(this);
        RoomManager.Instance.RemoveObserver(this);
        base.skillDestory();
    }

    public override void Trigger()
    {
        if (killMonster >= 3)
            this.GetComponent<Character>().Hp++;
        killMonster = 0;
    }

    public override void OnNotify(string msg)
    {
        string bID = "";


        bID = UtilManager.Instance.MatchFiledFormMsg("die", msg, 0);
        if (bID != "Monster")
            killMonster++;

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "LeaveRoom")
            Trigger();
            
    }
}

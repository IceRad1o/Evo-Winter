using UnityEngine;
using System.Collections;

public class EnergyIncrease : Skill {

    public override void Trigger()
    {
        ItemManager.Instance.IncreaseEnegy(1);
    }

    public override void Create(int ID)
    {
        base.Create(ID);
    }

    void Start() 
    {
        RoomManager.Instance.AddObserver(this);    
    }


    public override void OnNotify(string msg)
    {
        Debug.Log(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "LeaveRoom") 
        {
            Debug.Log("LeaveRoom");
            if ((int)Random.value * (100+this.GetComponent<Character>().Luck) < 50)
                Trigger();        
        }
    }

    protected override void skillDestory()
    {
        RoomManager.Instance.RemoveObserver(this);
        base.skillDestory();
    }
}

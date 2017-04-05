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
        RoomElementManager.Instance.AddObserver(this);    
    }


    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "LeaveRoom") 
        {
            if ((int)Random.value * 100 < 50)
                Trigger();        
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnergyIncrease : Skill {

    string s;

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
        s = this.tag;
    }


    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "LeaveRoom") 
        {
            int x = this.gameObject.GetComponent<Character>().Luck;
            float y = Random.value;
           // int x=(int)(Random.value * (100+this.gameObject.GetComponent<Character>().Luck));
           if ( (int )(x*y)< 50)
                Trigger();        
        }
    }

    protected override void skillDestory()
    {
        RoomManager.Instance.RemoveObserver(this);
        base.skillDestory();
    }
}

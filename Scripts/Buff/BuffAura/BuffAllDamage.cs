using UnityEngine;
using System.Collections;

public class BuffAllDamage : BuffAura
{


    public override void Trigger()
    {
        var list = EnemyManager.Instance.EnemyList.ToArray();
        if (list.Length == 0) return;
        foreach (Character t in list)
       {
           //表示这些buff只有enemy有效
           t.GetComponent<BuffManager>().CreateDifferenceBuff(AddBuffID*10+1);
       }
    }

    public override void Create(int ID)
    {
        int[] part = {2, 8};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        AddBuffID = idPart[1];

        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        RoomManager.Instance.AddObserver(this);
        Trigger();
    }

    // Use this for initialization
	void Start () {
	
	}

    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, 0) == "Enter Room")
        {
            Trigger();        
        }
    }
	
}

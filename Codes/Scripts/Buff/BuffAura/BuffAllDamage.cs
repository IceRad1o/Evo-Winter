using UnityEngine;
using System.Collections;

public class BuffAllDamage : BuffAura
{


    public override void Trigger()
    {
        var list = EnemyManager.Instance.EnemyList.ToArray();
        if (list.Length == 0) return;
        foreach (Character t in list)
        {   //表示这些buff只有enemy有效
            if (t != null)
                t.GetComponent<Character>().Hp -= 10;
        }
    }

    public override void Create(int ID, string spTag = "")
    {
        int[] part = {2, 8};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        AddBuffID = idPart[1];

        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        RoomManager.Instance.AddObserver(this);
        Trigger();
    }


    public override void DestroyBuff()
    {
        RoomManager.Instance.RemoveObserver(this);
        base.DestroyBuff();
    }

    public override void OnNotify(string msg)
    {
        Debug.Log("allDamage receive:   "+msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "EnterRoom")
        {
            Trigger();        
        }
    }
	
}

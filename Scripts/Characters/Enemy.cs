using UnityEngine;
using System.Collections;

public class Enemy : Character{

	public override void Awake () {
        base.Awake();
        this.tag = "Enemy";
        EnemyManager.Instance.EnemyList.Add(this);
	}

    public override void Destroy()
    {
        //Debug.Log("Count0" + RoomElementManager.Instance.RoomElementList.Count);
        EnemyManager.Instance.EnemyList.Remove(this);
        base.Destroy();
        if (EnemyManager.Instance.EnemyList.Count == 0)
        {
            EnemyManager.Instance.Notify("ClearRoom");
        }
    }

}

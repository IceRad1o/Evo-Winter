using UnityEngine;
using System.Collections;

public class Enemy : Character{

   


	public override void Start () {
        base.Start();
        this.tag = "Enemy";
        EnemyManager.Instance.EnemyList.Add(this);
	}

    public override void Die()
    {
        base.Die();
        EnemyManager.Instance.EnemyList.Remove(this);
      
        if (EnemyManager.Instance.EnemyList.Count == 0)
        {
            EnemyManager.Instance.Notify("ClearRoom");
        }
        
    }
}

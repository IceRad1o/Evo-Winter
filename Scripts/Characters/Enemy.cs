using UnityEngine;
using System.Collections;

public class Enemy : Character{

   


	public override void Start () {
        base.Start();
        this.tag = "Enemy";
       Camp = 1;
        EnemyManager.Instance.EnemyList.Add(this);
	}

    public override void Die()
    {
        
        EnemyManager.Instance.EnemyList.Remove(this);
      
        if (EnemyManager.Instance.EnemyList.Count == 0)
        {
            EnemyManager.Instance.Notify("ClearRoom");
        }
        base.Die();
    }
}

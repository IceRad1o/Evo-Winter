using UnityEngine;
using System.Collections;

public class Claw : RoomElement {

    public override void Awake()
    {
        base.Awake();
        RoomElementID = 5;
    }

	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		if (EnemyManager.Instance.EnemyList.Count == 0 && other.tag == "Player") 
		{
			Notify ("Claw");
		}
	}
}

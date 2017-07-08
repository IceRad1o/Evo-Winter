using UnityEngine;
using System.Collections;

public class Stair : RoomElement {

    public override void Awake()
    {
        base.Awake();
       // RoomElementID = 16;
	}
	
     //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("StairOnTiger" + other.tag + "    敌人数量：" + EnemyManager.Instance.EnemyList.Count);
		OnStair(other);
    }

	//楼梯调用函数
	private void OnStair(Collider other)
	{
		if (other.tag == "Player" && EnemyManager.Instance.EnemyList.Count == 0)
		{
				CheckpointManager.Instance.SetupCheckpoint();
		}
	}
}

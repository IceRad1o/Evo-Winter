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
		if (RoomElementState == 1)
			return;
		if (EnemyManager.Instance.EnemyList.Count == 0 && other.CompareTag("Player")) 
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify ("Claw");
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			RoomManager.Instance.Notify("LeaveClaw");
			Player.Instance.Character.RemoveObserver(this);
		}
	}
	//函数重载
	public override void Trriger()
	{
		if (RoomElementState == 1)
			return;
		base.Trriger();
		RoomElementState = 1;
		Notify("UseClaw");
	}
}

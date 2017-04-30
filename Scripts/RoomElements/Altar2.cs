using UnityEngine;
using System.Collections;

public class Altar2 : RoomElement {

	public override void Awake()
	{
		base.Awake();
		RoomElementID = 18;
	}
	
	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			RoomManager.Instance.Notify("CloseAltar");
		}

	}

	//调用函数
	public void AddBuff()
	{

	}
}

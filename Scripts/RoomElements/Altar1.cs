using UnityEngine;
using System.Collections;

public class Altar1 : RoomElement{
	public int attribute1,attribute2;
	public int change1,change2;
	public override void Awake()
	{
		base.Awake();
		RoomElementID = 17;
	}

	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			attribute1 = Random.Range (1,8);
			change1 = Random.Range (1,4);
			attribute2 = Random.Range (1,8);
			change2 = Random.Range (-1,-4);
			RoomManager.Instance.Notify("EnterAltar;1;"+attribute1+";"+change1+";"+attribute2+";"+change2);
		}
	}

	//调用函数
	public void AddBuff()
	{

	}

	//离开
	private void OnTriggerExit(Collider other)
	{
		RoomManager.Instance.Notify ("LeaveAltar");
	}
}

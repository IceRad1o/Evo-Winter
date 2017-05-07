using UnityEngine;
using System.Collections;

public class Altar2 : RoomElement {

	public int attribute;
	public int increase;
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
			RoomManager.Instance.Notify("CloseAltar;2");
			attribute = Random.Range (1,8);
			increase = Random.Range (1,4);
			RoomManager.Instance.Notify("EnterAltar;2;"+attribute+";"+increase);
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

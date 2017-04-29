using UnityEngine;
using System.Collections;

public class Shop : RoomElement {

	public override void Awake()
	{
		base.Awake();
		RoomElementID = 19;
	}

	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			RoomManager.Instance.Notify ("CloseShop");
		}
	}

	//出售商品
	public void SellItem()
	{
		
	}

}

using UnityEngine;
using System.Collections;

public class Plate : RoomElement {

	//价格图
	public GameObject[] prices;
	public override void Awake()
	{
		base.Awake();
		RoomElementID = 20;
	}

	public void SetPrice(int price)
	{
		bool zero = false;
		int a;
		int num = 100;
		Vector3 pricePosition;
		Vector3 platePosition = this.transform.position;
		float[] pos = { -0.4f, -0.2f, 0f};
		for (int i = 0; i < 3; i++) 
		{
			a = price / num;
			if (i == 0 && a == 0||(i == 1 && zero && a==0)) 
			{
				zero = true;
				price = price % num;
				num = num / 10;
				continue;
			}
			else 
			{
				zero = false;
				pricePosition = new Vector3 (platePosition.x+pos[i],(platePosition.y+1.0f)/2,-6f);
				GameObject itemPrice = Instantiate(prices[a], pricePosition, Quaternion.identity) as GameObject;
				itemPrice.transform.SetParent(GameObject.Find("GroundElements").transform);
			}
			price = price % num;
			num = num / 10;
			//Debug.Log ("PRICE:"+a);
		}
	}
}

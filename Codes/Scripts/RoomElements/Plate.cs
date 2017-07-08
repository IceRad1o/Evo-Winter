using UnityEngine;
using System.Collections;

public class Plate : RoomElement {

	//价格贴图
	public Sprite[] priceNums;

    public GameObject[] priceObjs;

	public override void Awake()
	{
		base.Awake();
		//RoomElementID = 20;
        //SetPrice(RoomElementState);
	}

    private void Start()
    {
        SetPrice((int)RoomElementState);
    }


    public void SetPrice(int price)
	{
        RoomElementState = (int)price;

        int priceHigh = price / 100;
        int priceMiddle = price%100 / 10;
        int priceLow = price % 10;

        priceObjs[0].GetComponent<SpriteRenderer>().sprite = priceNums[priceHigh];
        priceObjs[1].GetComponent<SpriteRenderer>().sprite = priceNums[priceMiddle];
        priceObjs[2].GetComponent<SpriteRenderer>().sprite = priceNums[priceLow];
    }
}

using UnityEngine;
using System.Collections;

public class Shop : RoomElement {

	public override void Awake()
	{
		base.Awake();
        //RoomElementID = 19;

    }

    private void Start()
    {
        if (RoomElementState == 1)
            return;
        ////道具
        Vector3 pricePosition;
        Vector3[] itemPosition = {
            new Vector3(-3f,-0.5f,0f),new Vector3(-3f,-4f,0f),new Vector3(-3f,-7.5f,0f),
            new Vector3( 3f,-0.5f,0f),new Vector3( 3f,-4f,0f),new Vector3( 3f,-7.5f,0f)};
        ItemManager.Instance.ItemsTransform = this.transform;

        for (int j = 0; j < 6; j++)
        {
            ItemManager.Instance.ItemsTransform.position = itemPosition[j];
            var shopItem = ItemManager.Instance.CreateItemDrop(false, false, true, itemPosition[j]);
            shopItem.NeedBuy = true;
            //牌子
            pricePosition = new Vector3(itemPosition[j].x, itemPosition[j].y + 0.5f, 0f);
            GameObject itemPlate = Instantiate(RETable.REDict[REID.Plate].gameObject, pricePosition, Quaternion.identity) as GameObject;
            Debug.Log("ground:" + RoomManager.Instance.ground);
            Debug.Log("ground:" + itemPlate);
            Debug.Log("item:" + shopItem.Price);
            itemPlate.transform.SetParent(RoomManager.Instance.ground);

       
            itemPlate.GetComponent<Plate>().SetPrice(shopItem.Price);

        }
        RoomElementState = 1;
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

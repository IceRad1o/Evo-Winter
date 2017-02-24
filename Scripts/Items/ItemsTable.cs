using UnityEngine;
using System.Collections;



public class ItemsTable : MonoBehaviour {

    

    struct ItemsData {
     public int ID;
     public int spriteArrayID;
     // 0 表示 ImmediatelyItem，1表示 DisposableItem，2表示 InitiativeItem
     public int type;
     // 0 表示 room掉落，1表示 boss掉落，2表示 box掉落
     public int droping;
    
    }

    private ItemsData[] itemsData;


    /*@GetSpriteID
     *@Brief 判断道具使用的UI图
     *@Return 道具使用的UI图在spriteItems中的位置
     */
    public int GetSpriteID(int ID) {
        if (ID == 1001)
            return 0;


        return 0;
    }
    /*CreateItem
     *@Brief 创建一个道具
     *Param  roomDroping 随机生成的道具中是否含房间掉落
     *Param  bossDroping 随机生成的道具中是否含boss掉落
     *Param  boxDroping 随机生成的道具中是否含宝箱掉落
    */
    public int[] GetItemsByType(bool includeingImm = false , bool includeingDis = false, bool includeingIni = false)
    {
        int[] itemsIDs=null;
        for (int i = 0; i < itemsData.Length; i++)
        {
            if (itemsData[i].type == 0 && includeingImm)
                itemsIDs[itemsIDs.Length] = itemsData[i].ID;
            if (itemsData[i].type == 1 && includeingDis)
                itemsIDs[itemsIDs.Length] = itemsData[i].ID;
            if (itemsData[i].type == 2 && includeingIni)
                itemsIDs[itemsIDs.Length] = itemsData[i].ID;
        }


        return itemsIDs;
    }
	
	void Awark () {
        ItemsData item;

        item.ID = 1003;
        item.spriteArrayID = 0;
        item.type = 0;
        item.droping = 1;
        itemsData[itemsData.Length] = item;

	}
	
	
}

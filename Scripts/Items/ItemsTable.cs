using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ItemsTable {

    

    struct ItemsData {
     public int ID;
     public int spriteArrayID; 
     /// <summary>
     /// 0 表示 ImmediatelyItem，1表示 DisposableItem，2表示 InitiativeItem
     /// </summary>
     public int type;
     /// <summary>
     ///  0表示 boss掉落，1表示 room掉落，2表示 box掉落，3为0+1，4为0+2，5为1+2，6为0+1+2
     /// </summary>
     public int droping;
     public int buffID;
     public int skillID;
     public int energy;       
    
    }
    
    //private ItemsData[] itemsData;
    private List<ItemsData> itemsData=new List<ItemsData>();

    /// <summary>
    /// 获得对应item的图片ID
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的图片ID</returns>
    public int GetSpriteID(int ID)
    {

        return FindItemsByID(ID).spriteArrayID;

    }
    /// <summary>
    /// 获得对应item的类型,0 表示 ImmediatelyItem，1表示 DisposableItem，2表示 InitiativeItem
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的类型</returns>
    public int GetItemType(int ID)
    {

        return FindItemsByID(ID).type;

    }
    /// <summary>
    /// 获得对应item的掉落
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的掉落， 0表示 boss掉落，1表示 room掉落，2表示 box掉落，3为0+1，4为0+2，5为1+2，6为0+1+2</returns>
    public int GetItemDroping(int ID)
    {

        return FindItemsByID(ID).droping;

    }
    /// <summary>
    /// 获得对应item的BuffID
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的BuffID</returns>
    public int GetItemBuffID(int ID)
    {

        return FindItemsByID(ID).buffID;
    }
    /// <summary>
    /// 获得对应item的SkillID
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的SkillID</returns>
    public int GetItemSkillID(int ID)
    {

        return FindItemsByID(ID).skillID;
    }

    /// <summary>
    /// 获得对应item的能量
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的能量</returns>
    public int GetItemEnergy(int ID)
    {

        return FindItemsByID(ID).energy;
    }
    /*CreateItem
     *@Brief 创建一个道具
     *Param  roomDroping 随机生成的道具中是否含房间掉落
     *Param  bossDroping 随机生成的道具中是否含boss掉落
     *Param  boxDroping 随机生成的道具中是否含宝箱掉落
    */
    public int[] GetItemsByType(bool includeingImm = false , bool includeingDis = false, bool includeingIni = false)
    {
       
        List<int> itemsIDs = new List<int>();
        for (int i = 0; i < itemsData.Count; i++)
        {
            if (itemsData[i].type == 0 && includeingImm)
                itemsIDs.Add(itemsData[i].ID);
            if (itemsData[i].type == 1 && includeingDis)
                itemsIDs.Add(itemsData[i].ID);
            if (itemsData[i].type == 2 && includeingIni)
                itemsIDs.Add(itemsData[i].ID);
        }



        return itemsIDs.ToArray();
    }
    /// <summary>
    /// 通过掉落类型查找所有的道具ID
    /// </summary>
    /// <param name="roomDroping"></param>
    /// <param name="boosDroping"></param>
    /// <param name="boxDroping"></param>
    /// <returns></returns>
    public int[] GetItemsByDoping(bool roomDroping = false, bool boosDroping = false, bool boxDroping = false)
    {

        List<int> itemsIDs = new List<int>();
        for (int i = 0; i < itemsData.Count; i++)
        {
            if ((itemsData[i].droping == 1 || itemsData[i].droping == 3 || itemsData[i].droping == 5 || itemsData[i].droping == 6) && roomDroping)
                itemsIDs.Add(itemsData[i].ID);
            if ((itemsData[i].droping == 0 || itemsData[i].droping == 3 || itemsData[i].droping == 4 || itemsData[i].droping == 6) && boosDroping)
                itemsIDs.Add(itemsData[i].ID);
            if ((itemsData[i].droping == 2 || itemsData[i].droping == 4 || itemsData[i].droping == 5 || itemsData[i].droping == 6) && boxDroping)
                itemsIDs.Add(itemsData[i].ID);
        }

        Debug.Log("itemsIDs Number:   " + itemsIDs.Count);

        return itemsIDs.ToArray();
    }



    /// <summary>
    /// 根据ID找到相关的item的数据类对象
    /// </summary>
    /// <param name="ID">item的ID</param>
    /// <returns>对应ID的item数据类ItemsData</returns>
    private ItemsData FindItemsByID(int ID)
    {
        ItemsData item = new ItemsData();
        for (int i = 0; i < itemsData.Count; i++)
            if (itemsData[i].ID == ID)
                item = itemsData[i];

        return item;
    }


    public ItemsTable()
    {
        ItemsData item=new ItemsData();

        
        item.ID = 1012;
        item.spriteArrayID = 11;
        item.type = 1;
        item.droping = 3;
        item.buffID = 101001;
        item.skillID = 0;
        itemsData.Add(item);

       
    }
	


    
}

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
     public string itemName;
     public string itemIntro;
    
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
    /// 获得对应item的Name
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的itemName</returns>
    public string GetItemName(int ID)
    {

        return FindItemsByID(ID).itemName;
    }
    /// <summary>
    /// 获得对应item的itemIntro
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的itemIntro</returns>
    public string GetItemIntro(int ID)
    {

        return FindItemsByID(ID).itemIntro;
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

        Debug.Log("itemsIDs Number:   " + itemsIDs.Count);

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
        ItemsData item = new ItemsData();

        /*********************/
        //一次性道具
        /*
        item.ID = 1012;
        item.spriteArrayID = 11;
        item.type = 1;
        item.droping = 6;
        item.buffID = 1000010;
        item.skillID = 0;
        item.itemName = "生命之精";
        item.itemIntro = "拥有浓郁的生命活力，使用后恢复一定体力";
        itemsData.Add(item);

        item.ID = 1001;
        item.spriteArrayID = 0;
        item.type = 1;
        item.droping = 2;
        item.buffID = 3010;
        item.skillID = 0;
        item.itemName = "命运硬币";
        item.itemIntro = "听取命运的安排吧，正面新生，反面地狱";
        itemsData.Add(item);
        */
        /*********************/
        //立即使用道具
        /*
        item.ID = 1002;
        item.spriteArrayID = 1;
        item.type = 0;
        item.droping = 2;
        item.buffID = 1001010;
        item.skillID = 0;
        item.itemName = "赌博骰子";
        item.itemIntro = "来试试人品吧，随机回复（扣去）生命";
        itemsData.Add(item);

        item.ID = 1013;
        item.spriteArrayID = 12;
        item.type = 0;
        item.droping = 2;
        item.buffID = 2010;
        item.skillID = 0;
        item.itemName = "贤者之石碎片";
        item.itemIntro = "“贤者之石”是所有元素的完美精华，据说拥有长生的能力";
        itemsData.Add(item);

        item.ID = 1008;
        item.spriteArrayID = 7;
        item.type = 0;
        item.droping = 2;
        item.buffID = 410001200;
        item.skillID = 0;
        item.itemName = "尼伯龙根的指环";
        item.itemIntro = "莱茵河的黄金所铸，据说拥有统治世界的能力，却也拥有无法消除的诅咒";
        itemsData.Add(item);
        
        item.ID = 1059;
        item.spriteArrayID = 17;
        item.type = 0;
        item.droping = 2;
        item.buffID = 2100;
        item.skillID = 0;
        item.itemName = "凛之刃";
        item.itemIntro = "";
        itemsData.Add(item);
        
        item.ID = 1062;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.buffID = 3100;
        item.skillID = 0;
        item.itemName = "幽之刃";
        item.itemIntro = "";
        itemsData.Add(item);
        */

        ///*********************/
        ////主动道具
        /*
        item.ID = 1028;
        item.spriteArrayID = 2;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1000010;
        item.buffID = 2010;
        item.skillID = 0;
        item.energy = 6;
        item.itemName = "生命之树的种子";
        item.itemIntro = "相传是精灵一族圣树的种子，拥有浓郁的生命力";
        itemsData.Add(item);

        item.ID = 1005;
        item.spriteArrayID = 4;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1020;
        item.skillID = 0;
        item.energy = 6;
        item.itemName = "冥王哈迪斯的金库钥匙";
        item.itemIntro = "地狱和死人的统治者----哈得斯同时是掌管财富的神，掌管地下埋藏的宝藏";
        itemsData.Add(item);
        */
        item.ID = 1062;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.buffID = 2100;
        item.skillID = 0;
        item.itemName = "幽之刃";
        item.itemIntro = "";
        itemsData.Add(item);
    }
	


    
}

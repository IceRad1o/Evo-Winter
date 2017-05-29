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
     public int buffID_advanced;
     public int skillID;
     public int skillID_advanced;
     public int energy;
     public string itemName;
     public string itemIntro;
     public string quality;
    
    }
    
    private List<ItemsData> itemsData=new List<ItemsData>();

    #region Function_Varible
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
    /// 获得对应item的buffID_advanced
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的buffID_advanced</returns>
    public int GetItemBuffID_Advance(int ID)
    {

        return FindItemsByID(ID).buffID_advanced;
    }
    /// <summary>
    /// 获得对应item的skillID_advanced
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的skillID_advanced</returns>
    public int GetItemSkillID_Advanced(int ID)
    {

        return FindItemsByID(ID).skillID_advanced;
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
    /// 获得对应item的SkillID
    /// </summary>
    /// <param name="ID">道具ID</param>
    /// <returns>item的SkillID</returns>
    public string GetItemQuality(int ID)
    {

        return FindItemsByID(ID).quality;
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
    #endregion


    #region Random_ID_List
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
    #endregion


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

        item.ID = 1012;
        item.spriteArrayID = 11;
        item.type = 1;
        item.droping = 6;
        item.buffID = 1000010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "生命之精";
        item.itemIntro = "拥有浓郁的生命活力，使用后恢复一定体力";
        itemsData.Add(item);

        item.ID = 1052;
        item.spriteArrayID = 11;
        item.type = 1;
        item.droping = 6;
        item.buffID = 4010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "时光回溯装置";
        item.itemIntro = "使自身的血量回复到进入所在房间时的血量";
        itemsData.Add(item);

        item.ID = 1016;
        item.spriteArrayID = 15;
        item.type = 1;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 3;
        item.quality = "A";
        item.itemName = "寒冰之障";
        item.itemIntro = "永恒的寒冰啊！请允许我呼唤你的气息，呼唤你的坚韧、你的寒冷、你的孤傲，化为万古寒冰之墙阻挡一切邪恶的攻击吧";
        itemsData.Add(item);

        item.ID = 1020;
        item.spriteArrayID = 19;
        item.type = 1;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 3;
        item.quality = "A";
        item.itemName = "火之炼狱";
        item.itemIntro = "永恒的寒冰啊！请允许我呼唤你的气息，呼唤你的坚韧、你的寒冷、你的孤傲，化为万古寒冰之墙阻挡一切邪恶的攻击吧";
        itemsData.Add(item);

        item.ID = 1019;
        item.spriteArrayID = 18;
        item.type = 1;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 3;
        item.quality = "A";
        item.itemName = "初秋的凝霜";
        item.itemIntro = "初秋的霜降使得敌人的移动变得迟缓";
        itemsData.Add(item);

        item.ID = 1001;
        item.spriteArrayID = 0;
        item.type = 1;
        item.droping = 2;
        item.buffID = 3010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "命运硬币";
        item.itemIntro = "听取命运的安排吧，正面新生，反面地狱";
        itemsData.Add(item);

        /*********************/
        //立即使用道具

        item.ID = 1002;
        item.spriteArrayID = 1;
        item.type = 0;
        item.droping = 2;
        item.buffID = 1001010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "赌博骰子";
        item.itemIntro = "来试试人品吧，随机回复（扣去）生命";
        itemsData.Add(item);

        item.ID = 1013;
        item.spriteArrayID = 12;
        item.type = 0;
        item.droping = 2;
        item.buffID = 2010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "贤者之石碎片";
        item.itemIntro = "“贤者之石”是所有元素的完美精华，据说拥有长生的能力";
        itemsData.Add(item);

        item.ID = 1008;
        item.spriteArrayID = 7;
        item.type = 0;
        item.droping = 2;
        item.buffID = 110001200;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "尼伯龙根的指环";
        item.itemIntro = "莱茵河的黄金所铸，据说拥有统治世界的能力，却也拥有无法消除的诅咒";
        itemsData.Add(item);

        item.ID = 1059;
        item.spriteArrayID = 17;
        item.type = 0;
        item.droping = 2;
        item.buffID = 2100;
        item.buffID_advanced = 152100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "凛之刃";
        item.itemIntro = "环绕着凛冽寒风的魔刃,攻击一定概率使敌人减速.";
        itemsData.Add(item);

        item.ID = 1061;
        item.spriteArrayID = 19;
        item.type = 0;
        item.droping = 2;
        item.buffID = 4100;
        item.buffID_advanced = 154100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "石之刃";
        item.itemIntro = "承载着重力的魔刃,攻击一定概率使敌人僵化";
        itemsData.Add(item);

        item.ID = 1060;
        item.spriteArrayID = 14;
        item.type = 0;
        item.droping = 2;
        item.buffID = 5100;
        item.buffID_advanced = 155100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "霜之刃";
        item.itemIntro = "覆盖着霜雪的魔刃，攻击一定概率使敌人冻结.";
        itemsData.Add(item);

        item.ID = 1064;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.buffID = 6100;
        item.buffID_advanced = 156100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "止之刃";
        item.itemIntro = "凝固着时光的魔刃,攻击一定概率束缚敌人";
        itemsData.Add(item);

        item.ID = 1062;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.buffID = 3100;
        item.buffID_advanced = 153100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "幽之刃";
        item.itemIntro = "散发着幽暗气息的魔刃,攻击一定概率使敌人即死.";
        itemsData.Add(item);


        ///*********************/
        ////主动道具

        item.ID = 1028;
        item.spriteArrayID = 2;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1000010;
        item.buffID = 2010;
        item.skillID = 0;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "生命之树的种子";
        item.itemIntro = "相传是精灵一族圣树的种子，拥有浓郁的生命力";
        itemsData.Add(item);

        item.ID = 1014;
        item.spriteArrayID = 13;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1052001110;
        item.skillID = 0;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "诸神的黄昏";
        item.itemIntro = "其中蕴藏着无穷的力量，拥有者可暂时的获得巨大神力";
        itemsData.Add(item);

        item.ID = 1004;
        item.spriteArrayID = 2;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1000010;
        item.buffID = 0;
        item.skillID = 5;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "魔法之源";
        item.itemIntro = "传说是一个神降师使用的魔法珠，可以释放不同的法术";
        itemsData.Add(item);

        item.ID = 1005;
        item.spriteArrayID = 4;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1020;
        item.skillID = 0;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "冥王哈迪斯的金库钥匙";
        item.itemIntro = "地狱和死人的统治者----哈得斯同时是掌管财富的神，掌管地下埋藏的宝藏";
        itemsData.Add(item);

        item.ID = 1047;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 8;
        item.energy = 0;
        item.quality = "A";
        item.itemName = "任意门";
        item.itemIntro = "向前闪现一段距离";
        itemsData.Add(item);

        item.ID = 1009;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 6;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "神降：毁灭之神";
        item.itemIntro = "一本记载着神降书的禁忌之书，能对所有人造成巨大的伤害";
        itemsData.Add(item);

        item.ID = 1054;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 150411200;
        item.skillID = 0;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "时光停止装置";
        item.itemIntro = "15s内除自身外所有物体停止移动攻击等行为";
        itemsData.Add(item);

        ////////////////////////////////////////////////////////////////////

        item.ID = 1003;
        item.spriteArrayID = 11;
        item.type = 1;
        item.droping = 6;
        item.buffID = 2020;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "罪恶之源";
        item.itemIntro = "一切罪恶的源头，获得一种罪恶精华";
        itemsData.Add(item);


        item.ID = 1004;
        item.spriteArrayID = 3;
        item.type = 2;
        item.droping = 6;
        item.buffID = 3020;
        item.skillID = 0;
        item.energy = 6;
        item.quality = "A";
        item.itemName = "神机百变的六芒";
        item.itemIntro = "刻画着六芒星的炼金阵，跃动着“平等转换”的法则,随机转换身上的一个精华的种类";
        itemsData.Add(item);


        item.ID = 1010;
        item.spriteArrayID = 9;
        item.type = 1;
        item.droping = 6;
        item.buffID = 0;
        item.buffID_advanced = 100110;
        item.skillID = 9;
        item.quality = "A";
        item.itemName = "禁：冰雪女神的叹息";
        item.itemIntro = "损失一格生命上限，冻结本房间所怪物（包括boss），时间（暂定）";
        itemsData.Add(item);

        item.ID = 1017;
        item.spriteArrayID = 16;
        item.type = 0;
        item.droping = 6;
        item.buffID = 8100;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "日冕石";
        item.itemIntro = "攻击时造成等量的溅射伤害";
        itemsData.Add(item);

        item.ID = 1022;
        item.spriteArrayID = 11;
        item.type = 0;
        item.droping = 6;
        item.buffID = 1030010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "雷之誓约";
        item.itemIntro = "攻击速度+1";
        itemsData.Add(item);

        item.ID = 1024;
        item.spriteArrayID = 13;
        item.type = 0;
        item.droping = 6;
        item.buffID = 1020010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "飓风精华";
        item.itemIntro = "移动速度+1";
        itemsData.Add(item);

        item.ID = 1025;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1020701110;
        item.skillID = 0;
        item.energy = 0;
        item.quality = "A";
        item.itemName = "自由之风的轻吟";
        item.itemIntro = "一段时间内移动速度+2";
        itemsData.Add(item);

        item.ID = 1025;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 1020701110;
        item.skillID = 0;
        item.energy = 0;
        item.quality = "A";
        item.itemName = "自由之风的轻吟";
        item.itemIntro = "一段时间内移动速度+2";
        itemsData.Add(item);

        item.ID = 1029;
        item.spriteArrayID = 9;
        item.type = 1;
        item.droping = 6;
        item.buffID = 2010;
        item.skillID = 0;
        item.quality = "A";
        item.itemName = "卷轴：天使之泪";
        item.itemIntro = "恢复所有体力";
        itemsData.Add(item);

        item.ID = 1026;
        item.spriteArrayID = 8;
        item.type = 2;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 10;
        item.energy = 0;
        item.quality = "A";
        item.itemName = "大地苏醒的旋律";
        item.itemIntro = "击退";
        itemsData.Add(item);


        item.ID = 1032;
        item.spriteArrayID = 9;
        item.type = 2;
        item.droping = 6;
        item.buffID = 10300;
        item.skillID = 0;
        item.energy = 0;
        item.quality = "A";
        item.itemName = "盾";
        item.itemIntro = "給盾";
        itemsData.Add(item);

        item.ID = 1030;
        item.spriteArrayID = 11;
        item.type = 0;
        item.droping = 6;
        item.buffID = 0;
        item.skillID = 11;
        item.quality = "A";
        item.itemName = "欲望之心";
        item.itemIntro = "精华一个相当于两个";
        itemsData.Add(item);


        //进阶道具
        item.ID = 1510;
        item.spriteArrayID = 9;
        item.type = 0;
        item.droping = 6;
        item.quality = "SS";
        item.itemName = "进阶！\n禁：冰雪女神的叹息";
        item.itemIntro = "将\"禁：冰雪女神的叹息\"进阶";
        itemsData.Add(item);

        item.ID = 1502;
        item.spriteArrayID = 1;
        item.type = 0;
        item.droping = 2;
        item.quality = "ss";
        item.itemName = "进阶！赌博骰子";
        item.itemIntro = "赌博骰子进阶：拥有连续回血（扣血）的概率";
        itemsData.Add(item);

        item.ID = 1562;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.quality = "SS";
        item.itemName = "进阶！幽之刃";
        item.itemIntro = "提高幽之刃的触发概率";
        itemsData.Add(item);


        item.ID = 1561;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.quality = "SS";
        item.itemName = "进阶！石之刃";
        item.itemIntro = "提高石之刃的触发概率";
        itemsData.Add(item);


        item.ID = 1560;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.quality = "SS";
        item.itemName = "进阶！霜之刃";
        item.itemIntro = "提高霜之刃的触发概率";
        itemsData.Add(item);


        item.ID = 1559;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.quality = "SS";
        item.itemName = "进阶！凛之刃";
        item.itemIntro = "提高凛之刃的触发概率";
        itemsData.Add(item);

        item.ID = 1564;
        item.spriteArrayID = 18;
        item.type = 0;
        item.droping = 2;
        item.quality = "SS";
        item.itemName = "进阶！止之刃";
        item.itemIntro = "提高止之刃的触发概率";
        itemsData.Add(item);
    }
	


    
}

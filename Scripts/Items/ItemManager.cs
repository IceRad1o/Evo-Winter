using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ItemManager : ExUnitySingleton<ItemManager>
{
    //用来确定道具生成时的道具位置
    public Transform itemsTransform;
    public Transform ItemsTransform
    {
        get { return itemsTransform; }
        set { itemsTransform = value; }
    }
    public DisposableItem itemsDisposable;
    public ImmediatelyItem itemImmediately;
    public InitiativeItem itemInitiative;
    public ItemSprite itemSprite;

    /// <summary>
    /// 一次性道具，玩家当前拥有的
    /// </summary>
    [HideInInspector]
    private DisposableItem disposableItem;
    /// <summary>
    /// 主动道具，玩家当前拥有的
    /// </summary>
    [HideInInspector]
    private InitiativeItem initiativeItem;

    //道具与人物接触，假设同时只能有一个
    [HideInInspector]
    public DisposableItem itemsDis;
    [HideInInspector]
    public ImmediatelyItem itemImm;
    [HideInInspector]
    public InitiativeItem itemIni;   

    //List，场景内所有的道具，不包括人物拥有的
    [HideInInspector] 
    public List<DisposableItem> listDisposableItem = new List<DisposableItem>();
    [HideInInspector]
    public List<ImmediatelyItem> listImmediatelyItem = new List<ImmediatelyItem>();
    [HideInInspector]
    public List<InitiativeItem> listInitiativeItem = new List<InitiativeItem>();


    //创建ItemsTable的实例
    public ItemsTable itemsTable = new ItemsTable();

    /*CreateItem
     *@Brief 创建一个道具
     *Param  includeingDis 随机生成的道具中是否含一次性道具
     *Param  includeingImm 随机生成的道具中是否含立即使用道具
     *Param  includeingIni 随机生成的道具中是否含主动道具
     */
    public Item CreateItemType(bool includeingDis = false, bool includeingImm = false, bool includeingIni = false,Vector3 pos=default(Vector3), bool trans = true)
    {
        Vector3 s = new Vector3(itemsTransform.position.x,itemsTransform.position.y+1,itemsTransform.position.z);

        int itemID = RandomItemID(itemsTable.GetItemsByType(includeingImm, includeingDis, includeingIni));
        return CreateItemID(itemID, pos);
    }

    /// <summary>
    /// 创建一个道具
    /// </summary>
    /// <param name="roomDroping">roomDroping 随机生成的道具中是否含房间掉落</param>
    /// <param name="boosDroping">bossDroping 随机生成的道具中是否含boss掉落</param>
    /// <param name="boxDroping">boxDroping 随机生成的道具中是否含宝箱掉落</param>
    /// <param name="trans">设定道具是否随机掉落，true用transform生成，false随机生成</param>
    public Item CreateItemDrop(bool roomDroping = false, bool boosDroping = false, bool boxDroping = false,Vector3 pos=default(Vector3), bool trans=true)
    {
        Vector3 s = new Vector3(itemsTransform.position.x, itemsTransform.position.y + 1, itemsTransform.position.z);

        int itemID = RandomItemID(itemsTable.GetItemsByDoping(roomDroping, boosDroping, boxDroping));
        return CreateItemID(itemID, pos);
    }

    /// <summary>
    /// 创建一个道具
    /// </summary>
    /// <param name="ID">要创建道具的ID</param>
    /// <param name="trans">设定道具是否随机掉落，true用transform生成，false随机生成</param>
    public Item CreateItemID(int ID,Vector3 pos=default(Vector3),bool trans = true)
    {
        int itemID = ID;
        if (itemsTable.GetItemType(itemID) == 1)
        {
            var itemInstance = Instantiate(itemsDisposable, pos, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(itemID);
            return itemInstance;

        }
        if (itemsTable.GetItemType(itemID) == 0)
        {
            var itemInstance = Instantiate(itemImmediately, pos, itemsTransform.rotation) as ImmediatelyItem;
            itemInstance.Create(itemID);
            return itemInstance;

        }
        if (itemsTable.GetItemType(itemID) == 2)
        {
            var itemInstance = Instantiate(itemInitiative, pos, itemsTransform.rotation) as InitiativeItem;
            itemInstance.Create(itemID);
            return itemInstance;
        }
        return null;
    }

    /****************************************************************************************/
    //一次性道具
    /// <summary>
    /// 设置当前拥有的一次性道具，如果已经有道具了，则创建已有道具的实例
    /// </summary>
    /// <param name="item">获得的一次性道具</param>
    public void AddDisposableItems( DisposableItem item) {
        if (disposableItem.ItemID != 0)
        {
            System.Random random = new System.Random();
            DisposableItem itemInstance = Instantiate(itemsDisposable, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as DisposableItem;

            itemInstance.Create(disposableItem.ItemID);
            itemInstance.UsingNumber = disposableItem.UsingNumber;
            listDisposableItem.Add(itemInstance);
        }
        disposableItem.CreateScript(item.ItemID);
        disposableItem.UsingNumber = item.UsingNumber;       
    }
    /// <summary>
    /// 获得当前拥有的一次性道具 
    /// </summary>
    /// <returns></returns>
    public DisposableItem GetDisposableItems() {

        return disposableItem;
    }
    /// <summary>
    /// 使用一次性道具
    /// </summary>
    public void UseDisposableItems() {

        if (disposableItem.ItemID != 0)
        { 
            Notify( disposableItem.Use());
        }
                
    }  
    /// <summary>
    /// 销毁当前拥有的一次性道具 
    /// </summary>
    public void DestoryDisposableItems() {
        if (disposableItem.ItemID != 0)
            disposableItem.DestroyScript();
    }

    public Sprite GetDisposableItemsSprite() {
        return disposableItem.GetSprite();
    }


    /*************************************************************************************/
    //主动道具
    /// <summary>
    /// 添加主动道具，如果已有则将已有道具掉落地上
    /// </summary>
    /// <param name="item"></param>
    public void AddInitiativeItems(InitiativeItem item)
    {
        if (initiativeItem.ItemID != 0)
        {
            System.Random random = new System.Random();
            InitiativeItem itemInstance = Instantiate(itemInitiative, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as InitiativeItem;

            itemInstance.Create(initiativeItem.ItemID);
            itemInstance.EnergyNow = initiativeItem.EnergyNow;
            listInitiativeItem.Add(itemInstance);

        }
        initiativeItem.CreateScript(item.ItemID);
        initiativeItem.EnergyNow = item.EnergyNow;

    }

   /// <summary>
   /// 获得主动道具
   /// </summary>
   /// <returns></returns>
    public InitiativeItem GetInitiativeItem()
    {

        return initiativeItem;
    }
   /// <summary>
   /// 销毁主动道具
   /// </summary>
    public void DestoryInitiativeItem()
    {
        if (initiativeItem.ItemID != 0)
            initiativeItem.Destroy();
    }
    /// <summary>
    /// 改变主动道具能量
    /// </summary>
    public void IncreaseEnegy(int number) {
        if (initiativeItem.ItemID != 0)
            initiativeItem.EnergyNow = initiativeItem.EnergyNow + number;        
    }
    /// <summary>
    /// 使用主动道具
    /// </summary>
    public void UseInitiativeItem()
    {
        initiativeItem.Use();
    }
    public Sprite GetInitiativeItemSprite()
    {
        return initiativeItem.GetSprite();
    }
    /**********************************************************************************/
    //立即使用道具




    
    //随机产生道具的ID
    private int RandomItemID(int[] itemsID) {

        return itemsID[Random.Range(0, itemsID.Length)];
    }





    public void SendMsg(string msg) {
        Notify(msg);
    }


    /**************************************************************/
    //消息接收

    public override void OnNotify(string msg)
    {
        /***************************/
        //Player的消息接收

        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "AttackStart")
        {
            //一次性道具的拾取                
            foreach (DisposableItem t in listDisposableItem)
            {
                if (itemsDis == t && t.playerIn && CoinManager.Instance.Buy(t.Value))             
                {
                    AddDisposableItems(t);
                    Notify("Get_DisposableItem;" + t.ItemID + ";" + t.gameObject.transform.position.x + ";" + t.gameObject.transform.position.y + ";" + t.gameObject.transform.position.z);
                    t.Destroy();
                    break;
                }
            }
            //主动道具的拾取                
            foreach (InitiativeItem t in listInitiativeItem)
            {
                if (itemIni == t && t.PlayerIn && CoinManager.Instance.Buy(t.Value))
                {
                    AddInitiativeItems(t);
                    Notify("Get_InitiativeItem;" + t.ItemID + ";" + t.gameObject.transform.position.x + ";" + t.gameObject.transform.position.y + ";" + t.gameObject.transform.position.z);
                    t.Destroy();
                    break;
                }
            }
            //立即使用道具的拾取                
            foreach (ImmediatelyItem t in listImmediatelyItem)
            {
                if (itemImm == t && t.playerIn && CoinManager.Instance.Buy(t.Value))
                {
                    //Debug.Log("Get_ImmediatelyItem");
                    Notify("Get_ImmediatelyItem;" + t.ItemID + ";" + t.gameObject.transform.position.x + ";" + t.gameObject.transform.position.y + ";" + t.gameObject.transform.position.z);
                    t.Use();
                    break;
                }
            }


        }

        /************************************/
        //Item的消息接收
        int _id = 0;
        //获得一次性道具的消息检测
        string m = "Player_Get_DisposableItem";

        if (UtilManager.Instance.GetFieldFormMsg(msg,-1)==m)
        {
            _id =int.Parse( UtilManager.Instance.GetFieldFormMsg(msg, 0));
            DisposableItem[] disItems;
            disItems = gameObject.GetComponents<DisposableItem>();

            foreach (DisposableItem t in listDisposableItem)
            {
                if (_id == t.GetID())
                {
                    itemsDis = t;
                }
            }
        }

        //获得立即使用道具的消息检测
        m = "Player_Get_ImmediatelyItem";
        
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == m)
        {
            _id = int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0));
            foreach (ImmediatelyItem t in listImmediatelyItem)
            {
               
                if (_id == t.GetID())
                {
                    itemImm = t;
                }
            }
        }

        //获得立即使用道具的消息检测
        m = "Player_Get_InitiativeItem";

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == m)
        {
            _id = int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0));
            foreach (InitiativeItem t in listInitiativeItem)
            {

                if (_id == t.GetID())
                {
                    itemIni = t;
                }
            }
        }


        /*******************************************************/
        //roomManager的消息
        if (msg == "LeaveRoom")
        {
            IncreaseEnegy(1);
            //DestoryAllItems();
        }
    }



    
    

    /// <summary>
    /// 清除房间所有未捡道具
    /// </summary>
    public void DestoryAllItems() {
        for (int i = 0; i < listDisposableItem.Count; i++)
            listDisposableItem[i].Destroy();
        for (int i = 0; i < listImmediatelyItem.Count; i++)
            listImmediatelyItem[i].Destroy();
        for (int i = 0; i < listInitiativeItem.Count; i++)
            listInitiativeItem[i].Destroy();
    
    
    }
    

   
    //初始化参数
    void Awake() {

        disposableItem = new DisposableItem();
        initiativeItem = new InitiativeItem();
    
    }




    void Start()
    {
        Player.Instance.Character.AddObserver(this);
        this.AddObserver(UIManager.Instance.ItemObserver);
        RoomManager.Instance.AddObserver(this);
        
    }


}


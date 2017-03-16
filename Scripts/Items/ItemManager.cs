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
    public void CreateItemType(bool includeingDis = false, bool includeingImm = false, bool includeingIni = false, bool trans = false)
    {
        int itemID = RandomItemID(itemsTable.GetItemsByType(includeingImm, includeingDis, includeingIni));
        System.Random random = new System.Random();
        if (itemsTable.GetItemType(itemID)==1)
        {
            DisposableItem itemInstance;
            if (trans)
                itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;
            else
                itemInstance = Instantiate(itemsDisposable, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as DisposableItem;

            itemInstance.Create(itemID);           
            
        }
        if (itemsTable.GetItemType(itemID) == 0)
        {
            ImmediatelyItem itemInstance;
            if (trans)
                itemInstance = Instantiate(itemImmediately, itemsTransform.position, itemsTransform.rotation) as ImmediatelyItem;
            else
                itemInstance = Instantiate(itemImmediately, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as ImmediatelyItem;
            itemInstance.Create(itemID);
            

        }
        if (itemsTable.GetItemType(itemID) == 2)
        {
            InitiativeItem itemInstance;
            if (trans)
                itemInstance = Instantiate(itemInitiative, itemsTransform.position, itemsTransform.rotation) as InitiativeItem;
            else
                itemInstance = Instantiate(itemInitiative, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as InitiativeItem;
            itemInstance.Create(itemID);
            

        }
    
    }

    /// <summary>
    /// 创建一个道具
    /// </summary>
    /// <param name="roomDroping">roomDroping 随机生成的道具中是否含房间掉落</param>
    /// <param name="boosDroping">bossDroping 随机生成的道具中是否含boss掉落</param>
    /// <param name="boxDroping">boxDroping 随机生成的道具中是否含宝箱掉落</param>
    /// <param name="trans">设定道具是否随机掉落，true用transform生成，false随机生成</param>
    public void CreateItemDrop(bool roomDroping = false, bool boosDroping = false, bool boxDroping = false, bool trans=false)
    {
        int itemID = RandomItemID(itemsTable.GetItemsByDoping(roomDroping, boosDroping, boxDroping));
        System.Random random = new System.Random();
        //int itemID = RandomItemID();
        if (itemsTable.GetItemType(itemID) == 1)
        {
            DisposableItem itemInstance;
            if (trans)
                itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;
            else
                itemInstance = Instantiate(itemsDisposable, new Vector3(random.Next(12) - 6, -1, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as DisposableItem;

            itemInstance.Create(itemID);
                        
        }
        if (itemsTable.GetItemType(itemID) == 0)
        {
            ImmediatelyItem itemInstance = Instantiate(itemImmediately, itemsTransform.position, itemsTransform.rotation) as ImmediatelyItem;

            itemInstance.Create(itemID);            

        }
        if (itemsTable.GetItemType(itemID) == 2)
        {
            InitiativeItem itemInstance = Instantiate(itemInitiative, itemsTransform.position, itemsTransform.rotation) as InitiativeItem;

            itemInstance.Create(itemID);            

        }

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
        //创建random的实例
        System.Random random = new System.Random();
        return itemsID[random.Next(itemsID.Length)];
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
                if (itemsDis == t && t.playerIn)
             
                {
                    AddDisposableItems(t);
                    Notify("Get_DisposableItem;" + t.ItemID);
                    t.DestroyDisposableItem();
                    break;
                }
            }
            //主动道具的拾取                
            foreach (InitiativeItem t in listInitiativeItem)
            {
                if (itemIni == t && t.PlayerIn)
                {
                    AddInitiativeItems(t);
                    Notify("Get_InitiativeItem;" + t.ItemID);
                    t.Destroy();
                    break;
                }
            }
            //立即使用道具的拾取                
            foreach (ImmediatelyItem t in listImmediatelyItem)
            {
                if (itemImm == t && t.playerIn)
                {
                    Debug.Log("Get_ImmediatelyItem");
                    Notify("Get_ImmediatelyItem;" + t.ItemID);
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
        _id = GetIDofMSG(m, msg);

        if (_id != -1)
        {
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
        _id = GetIDofMSG(m, msg);

        if (_id != -1)
        {
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
        _id = GetIDofMSG(m, msg);

        if (_id != -1)
        {
            foreach (InitiativeItem t in listInitiativeItem)
            {

                if (_id == t.GetID())
                {
                    itemIni = t;
                }
            }
        }
    }



    
    

    /// <summary>
    /// 清除房间所有未捡道具
    /// </summary>
    public void DestoryAllItems() {
        for (int i = 0; i < listDisposableItem.Count; i++)
            listDisposableItem[i].DestroyDisposableItem();
        for (int i = 0; i < listImmediatelyItem.Count; i++)
            listImmediatelyItem[i].DestoryItem();
        for (int i = 0; i < listInitiativeItem.Count; i++)
            listInitiativeItem[i].DestoryItem();
    
    
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

        
    }

    //private PlayerObserver playerObs = new PlayerObserver(); //Player的观察者
    //internal PlayerObserver PlayerObs
    //{
    //    get { return playerObs; }
    //    set { playerObs = value; }
    //}
    //private ItemObser itemObs = new ItemObser(); //Item的观察者
    //internal ItemObser ItemObs
    //{
    //    get { return itemObs; }
    //    set { itemObs = value; }
    //}


    /********************************************************************/
    //工具，暂时放在这
    /// <summary>
    /// 匹配消息，如果匹配返回ID
    /// </summary>
    /// <param name="msg">消息的格式，如"UseItem_Buff_ID="+itemBuffID</param>
    /// <param name="_msg">消息</param>
    /// <returns>ID,如果不是-1则消息匹配</returns>
    public int GetIDofMSG(string msg,string _msg){
        if (msg.Length>=_msg.Length)
            return -1;
        for (int i = 0; i < msg.Length; i++)
        {
            if (msg[i] != _msg[i])
                return -1;        
        }
        int _id = 0;
        for (int i = msg.Length+1; i < _msg.Length; i++)
            _id = _id * 10 + _msg[i]-48;


       return _id;
    }

    /// <summary>
    /// 解析消息
    /// </summary>
    /// <param name="_msg">要解析的消息</param>
    /// <param name="_number">需要返回的字段</param>
    /// <returns>返回的字段，string形式，找不到对应字段返回“Error”</returns>
    public string GetIDFormMsg(string _msg, int _number) {
        string _string="";
        int number=-1,i=0;
        for (i = 0; i < _msg.Length; i++)
        {
            if (number == _number)
            {
                if (_msg[i] != ';')
                    _string += _msg[i];
                else
                    return _string;
            }
            else {
                if (_msg[i] == ';')
                    number++;
            }
        }
        if (number == _number)
            return _string;
        else
            return "Error";

    }
    /// <summary>
    /// 判断消息的匹配，并解析
    /// </summary>
    /// <param name="msg">消息匹配段</param>
    /// <param name="_msg">要解析的消息</param>
    /// <param name="_number">消息的字段</param>
    /// <returns>获取的字段string，“Fail”表示不匹配，“Error”表示无该字段</returns>
    public string GetIDFormMsg(string msg,string _msg, int _number) {
        if (msg.Length > _msg.Length)
            return "Fail";
        for (int i = 0; i < msg.Length; i++)
        {
            if (msg[i] != _msg[i])
                return "Fail";
        }
        string _string = "";
        int number = -1;
        for (int i = 0; i < _msg.Length; i++)
        {
            if (number == _number)
            {
                if (_msg[i] != ';')
                    _string += _msg[i];
                else
                    return _string;
            }
            else
            {
                if (_msg[i] == ';')
                    number++;
            }
        }

        if (number == _number)
            return _string;
        else
            return "Error";

        
    }

}

//class PlayerObserver : ExSubject
//{
//    public override void OnNotify(string msg)
//    {
//        string[] str = UtilManager.Instance.GetMsgFields(msg);
//        if (str[0] == "AttackStart")
//        {
//            //Debug.Log("Get");
//            //一次性道具的拾取                
//            foreach (DisposableItem t in ItemManager.Instance.listDisposableItem)
//            {
//                Debug.Log("do");
//                if (ItemManager.Instance.itemsDis == t && t.playerIn)
//                {
//                    ItemManager.Instance.AddDisposableItems(t);
//                    Notify("Get_DisposableItem;" + t.ItemID);
//                    t.DestroyDisposableItem();
//                    break;
//                }
//            }
//            //主动道具的拾取                
//            foreach (InitiativeItem t in ItemManager.Instance.listInitiativeItem)
//            {
//                if (ItemManager.Instance.itemIni == t && t.PlayerIn)
//                {
//                    ItemManager.Instance.AddInitiativeItems(t);
//                    Notify("Get_DisposableItem;" + t.ItemID);
//                    t.Destroy();
//                    break;
//                }
//            }
//            //立即使用道具的拾取                
//            foreach (ImmediatelyItem t in ItemManager.Instance.listImmediatelyItem)
//            {
//                if (ItemManager.Instance.itemImm == t && t.playerIn)
//                {
//                    Notify("Get_ImmediatelyItem;" + t.ItemID);
//                    t.Use();
//                    break;
//                }
//            }
//        }
//    }
//}
//class ItemObser : ExSubject
//{
//    public override void OnNotify(string msg)
//    {
//        int _id = 0;
//        //获得一次性道具的消息检测
//        string m = "Player_Get_DisposableItem";
//        _id = ItemManager.Instance.GetIDofMSG(m, msg);
//        if (_id != -1)
//        {
//            DisposableItem[] disItems;
//            disItems = ItemManager.Instance.gameObject.GetComponents<DisposableItem>();
//            foreach (DisposableItem t in ItemManager.Instance.listDisposableItem)
//            {
//                if (_id == t.GetID())
//                {
//                    ItemManager.Instance.itemsDis = t;
//                }
//            }
//        }
//        //获得立即使用道具的消息检测
//        m = "Player_Leave_ImmediatelyItem";
//        _id = ItemManager.Instance.GetIDofMSG(m, msg);
//        if (_id != -1)
//        {
//            foreach (ImmediatelyItem t in ItemManager.Instance.listImmediatelyItem)
//            {
//                if (_id == t.GetID())
//                {
//                    ItemManager.Instance.itemImm = t;
//                }
//            }
//        }
//    }
//}
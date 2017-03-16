using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*UIManager
 *@Brief 负责管理游戏UI交互
 *@Author YYF
 *@Time 17.1.25 
 *@Update at 17.1.26
 */
/// <summary>
/// <para>Brief 负责管理游戏UI元素</para>
/// <para>Author YYF</para>
/// <para>Time 17.1.26</para>
/// </summary>
public class UIManager : ExUnitySingleton<UIManager>
{
    //8个子构件

    private LittleMap littleMap;    //小地图

    public LittleMap LittleMap
    {
        get { return littleMap; }
    }
    private PlayerInfo playerInfo;  //玩家信息

    public PlayerInfo PlayerInfo
    {
        get { return playerInfo; }
    }
    private PlayerHealth playerHealth;  //玩家血量

    public PlayerHealth PlayerHealth
    {
        get { return playerHealth; }
    }
    private Popup popup;    //弹窗

    public Popup Popup
    {
        get { return popup; }
    }
    private EsscencesDisplayer esscencesDisplayer;  //精华数目展示模块

    public EsscencesDisplayer EsscencesDisplayer
    {
        get { return esscencesDisplayer; }
    }
    private MoveBall moveBall;  //移动球

    public MoveBall MoveBall
    {
        get { return moveBall; }
    }
    private AttackButtonManager attackButtonManager;    //攻击按钮管理者

    public AttackButtonManager AttackButtonManager
    {
        get { return attackButtonManager; }
    }
    private ItemButtonManager itemButtonManager;    //道具按钮管理者

    public ItemButtonManager ItemButtonManager
    {
        get { return itemButtonManager; }
    }


    void Start()
    {
        littleMap = LittleMap.Instance;
        playerInfo = PlayerInfo.Instance;
        playerHealth = PlayerHealth.Instance;
        esscencesDisplayer = EsscencesDisplayer.Instance;
        popup = Popup.Instance;
        moveBall = MoveBall.Instance;
        attackButtonManager = AttackButtonManager.Instance;
        itemButtonManager = ItemButtonManager.Instance;

        Player.Instance.Character.AddObserver(playerObserver);
        RoomManager.Instance.AddObserver(this);
    }


    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "EnterRoom")
        {
            Debug.Log("EnterRoomUI");
            littleMap.UpdateLittleMap();
        }
        if (str[0] == "EnterRoom")
        {
            Debug.Log("EnterRoomUI");
            littleMap.UpdateLittleMap();
        }
           
    }



    PlayerObserver playerObserver=new PlayerObserver(); //Player的观察者
    class PlayerObserver:Observer
    {
       public override void OnNotify(string msg)
       {
           if (msg == "HealthChanged")
               UIManager.Instance.playerHealth.Health = (int)Player.Instance.Character.Health;

       }
    }

    ItemObserver itemObserver = new ItemObserver(); //Player的观察者

    internal ItemObserver ItemObserver
    {
        get { return itemObserver; }
        set { itemObserver = value; }
    }







}

class ItemObserver : ExSubject
{
    public override void OnNotify(string msg)
    {

        string content = UtilManager.Instance.GetMsgField(msg, 0);
        string para1 = UtilManager.Instance.GetMsgField(msg, 1);
        int para1int=0;
        if (para1 != null)
            para1int = int.Parse(para1);
       // Debug.Log("msg"+msg+ ";content "+ content+"para:"+para1int);
        if (content == "DisposableItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        if (content == "InitiativeItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyInitiativeItem();
        if (content == "Player_Get_DisposableItem" || content == "Player_Get_InitiativeItem")
        {

            //TODO 显示道具信息
        }
        if (content == "Player_Leave_DisposableItem" || content == "Player_Leave_InitiativeItem")
        {

            //TODO 取消显示道具信息
           
        }
        if (content == "Get_DisposableItem")//玩家拾取一次性道具
        {
            //Sprite sp=ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(para1int)];
            Sprite sp = ItemManager.Instance.GetDisposableItemsSprite();
            Debug.Log(sp);
            //PROBELM 显示不出来
            UIManager.Instance.ItemButtonManager.AddDisposableItem(sp);
        }
        if (content == "Get_InitiativeItem")//玩家拾取主动道具
        {
 
            UIManager.Instance.ItemButtonManager.AddInitiativeItem(ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(para1int)]);
        }
        if(content=="InitiativeItem_Energy_Number")
        {
            //TODO 改变主动道具的能量显示
        }
        


    }
}
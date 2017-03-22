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

        Player.Instance.Character.AddObserver(this);
        RoomManager.Instance.AddObserver(this);
        ItemManager.Instance.AddObserver(this);
    }


    public override void OnNotify(string msg)
    {
        //Debug.Log("UIManager recieved :"+msg);
        //RoomManager Msg
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "EnterRoom")
        {
            littleMap.UpdateLittleMap();
        }
        if (str[0] == "EnterRoom")
        {
            littleMap.UpdateLittleMap();
        }


        if (str[0] == "MapComplete")
            littleMap.InitLittleMap();


        //ItemManager Msg

        if (str[0] == "DisposableItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        if (str[0] == "InitiativeItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyInitiativeItem();
        if (str[0] == "Player_Get_DisposableItem" || str[0] == "Player_Get_InitiativeItem" || str[0] == "Player_Get_ImmediatelyItem")
        {
            //TODO 显示道具信息
          
            UIManager.Instance.popup.SetItemDetailPopup(ItemManager.Instance.itemsTable.GetItemName(int.Parse(str[1])),ItemManager.Instance.itemsTable.GetItemIntro(int.Parse(str[1])));
            UIManager.Instance.popup.itemDetailPopup.SetActive(true);
        }
        if (str[0] == "Player_Leave_DisposableItem" || str[0] == "Player_Leave_InitiativeItem" || str[0] == "Player_Leave_ImmediatelyItem")
        {

            //TODO 取消显示道具信息
            UIManager.Instance.popup.itemDetailPopup.SetActive(false);

        }
        if (str[0] == "Get_DisposableItem")//玩家拾取一次性道具
        {
            UIManager.Instance.popup.itemDetailPopup.SetActive(false);
            Sprite sp = ItemManager.Instance.GetDisposableItemsSprite();
            UIManager.Instance.ItemButtonManager.AddDisposableItem(sp);
        }
        if (str[0] == "Get_InitiativeItem")//玩家拾取主动道具
        {
            UIManager.Instance.popup.itemDetailPopup.SetActive(false);
            Sprite sp = ItemManager.Instance.GetInitiativeItemSprite();
            UIManager.Instance.ItemButtonManager.AddInitiativeItem(sp);
          
        }
        if (str[0] == "Get_ImmediatelyItem")//玩家拾取主动道具
        {
            UIManager.Instance.popup.itemDetailPopup.SetActive(false);
        }
        if (str[0] == "InitiativeItem_Energy_Number")
        {
            //TODO 改变主动道具的能量显示
            itemButtonManager.SetEnergy(float.Parse(str[1]));
        }

        //Player Msg

        if (str[0]== "HealthChanged")
            UIManager.Instance.playerHealth.Health = (int)Player.Instance.Character.Health;
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
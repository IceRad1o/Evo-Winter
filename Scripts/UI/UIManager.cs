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
public class UIManager : UnitySingleton<UIManager>
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

class ItemObserver : Observer
{
    public override void OnNotify(string msg)
    {
       // UtilManager.Instance.GetIDFormMsg(msg, 1);
        if (msg == "DisposableItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        if (msg == "InitiativeItem_Destroy")
            UIManager.Instance.ItemButtonManager.DestroyInitiativeItem();
        if (msg == "Player_Get_DisposableItem")
            UIManager.Instance.ItemButtonManager.AddDisposableItem(ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(1)]);

    }
}
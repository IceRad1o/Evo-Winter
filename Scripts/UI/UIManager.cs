using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*UIManager
 *@Brief 负责管理游戏UI交互
 *@Author YYF
 *@Time 17.1.25 
 *@Update at 17.1.26
 */
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
    }
}

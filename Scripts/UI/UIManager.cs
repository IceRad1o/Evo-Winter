using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*UIManager
 *@Brief 负责管理游戏UI交互
 *@Author YYF
 *@Time 17.1.25
 */
public class UIManager : MonoBehaviour {

    /*GetInstance
     *@Brief 获取一个UIManager实例 
     *@Return UIManager
     */
    static public UIManager GetInstance()
    {
        if (instance)
            return instance;
        else
        {
            instance = Instantiate(instance);
            return instance;
        }

    }

    /*OnDisplayPlayerAttributes
     *@Brief 显示玩家详细信息界面
     */
    public void OnDisplayPlayerAttributes()
    {
        Debug.Log("You have clicked the  phote!");
        playerInfo.SetActive(true);
    }

    /*OnNormalAttack
     *@Brief 触发普通攻击
     */
    void OnNormalAttack()
    {
        Debug.Log("You have clicked the  JButton!");
        //NEED Player.GetInstance().NormalAttack();
        //TODO 若有冷却倒计时,则显示
    }

    /*OnSpecialAttack
     *@Brief 触发特殊攻击
     */
    void OnSpecialAttack()
    {
        Debug.Log("You have clicked the  KButton!");
        //NEED Player.GetInstance().SpecialAttack();
        //TODO 若有冷却倒计时,则显示
    }

    /*OnRaceSkill
     *@Brief 触发种族技能
     */
    void OnRaceSkill()
    {
        Debug.Log("You have clicked the  LButton!");
        //NEED Player.GetInstance().UseRaceSkill();
        //TODO 若有冷却倒计时,则显示
    }


    /*OnInitiativeItem
     *@Brief 触发使用主动道具
     */
    void OnInitiativeItem()
    {
        Debug.Log("s使用主动道具");
        //NEED ItemManager.GetInstance().UseInitiativeItems();

    }

    /*OnDisposableItem
     *@Brief 触发使用一次性道具
     */
    void OnDisposableItem()
    {
        Debug.Log("s使用一次性道具");
        //NEED ItemManager.GetInstance().UseDisposableItem();

    }


    /*DestroyDisposableItem
     *@Brief 销毁UI上的一次性道具
     */
    public void DestroyDisposableItem()
    {
        disposableItemImg.GetComponent<Image>().sprite = defaultItem;
    }

    /*DestroyInitiativeItem
     *@Brief 销毁UI上的主动道具
     */
    public void DestroyInitiativeItem()
    {
        initiativeItemImg.GetComponent<Image>().sprite = defaultItem;
    }

    /*AddInitiativeItem
     *@Brief 增加主动道具到UI
     *@Param Sprite item 道具图片
     */

    public void AddInitiativeItem(Sprite item)
    {
        Debug.Log("AddInitiativeItem");
        initiativeItemImg.GetComponent<Image>().sprite = item;
    }

    /*AddDisposableItem
     *@Brief 增加一次性道具到UI
     *@Param Sprite item 道具图片
     */
    public void AddDisposableItem(Sprite item)
    {
        Debug.Log("AddDisposableItem");
        disposableItemImg.GetComponent<Image>().sprite = item;
    }

    /*SetEsscences
     *@Brief 设置某种精华的数目
     *@Param1 int type  需要设置数目的精华的种类
     *@Param2 int value 需要设置的数目值
     */
    public void SetEsscences(int type, int value)
    {
        esscencesTexts[type].text = "X " + value;
    }

    /*SetPhote
     *@Brief 设置头像类别
     *@Param int type 类别 0=地精 1=吸血鬼 2=狼人 3=矮人
     *@Remark 未实现
     */
    public void SetPhote(int type)
    {

    }
    /*SetTextTitleStyle
     *@Brief 将文本样式设置成标题样式
     *@Remark 未实现
     */
    public void SetTextTitleStyle()
    {

    }


    public Button jButton;  //种族技能按钮
    public Button kButton;  //特殊攻击按钮
    public Button lButton;  //普通攻击按钮
    public Button initiativeItemButton; //主动道具按钮
    public Button disposableItemButton; //一次性道具按钮
    public Button photeButton;  //头像按钮
    public Button mapButton;    //地图按钮

    public GameObject moveBall; //移动球
    public GameObject playerInfo; //玩家信息

    public Sprite defaultItem;  //缺省道具图片

    public Text[] esscencesTexts;
    private static UIManager instance = null;  //单例

    private GameObject initiativeItemImg;   //主动道具图片
    private GameObject disposableItemImg;   //一次性道具图片
    private GameObject idleImg;     //移动球静止图片
    private GameObject moveImg;     //移动球移动图片

    private Vector3 centerPosition; //移动球正中心坐标
    private Vector3 touchPoint; //触摸坐标
    private bool isPressed; //是否触摸


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

	void Start () {
        isPressed = false;   
        playerInfo.SetActive(false);

        initPhote();
        initMoveBall();
        initControlButton();
        initEsscences();
        initLittleMap();
	}

    void Update()
    {

        //当按下且移动时
        if (isPressed)
        {
            touchPoint = Input.mousePosition;
            Debug.Log("移动:" + touchPoint);
            Vector3 offset = touchPoint - centerPosition;
            float angle;
            Vector3 oVector = new Vector3(0, -1, 0);
            Vector3 v3 = Vector3.Cross(offset, oVector);
            if (v3.z > 0)
                angle = -Vector3.Angle(offset, oVector);
            else
                angle = -360 + Vector3.Angle(offset, oVector);
            moveImg.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle);
            //NEED Player.GetInstance().Move(offset.x,offset.y);

        }
    }

    //当触摸进入
    private void OnMoveEnter(GameObject obj)
    {

        touchPoint = Input.mousePosition;
        Debug.Log("OnMoveEnter" + touchPoint);
        isPressed = true;

        idleImg.SetActive(false);
        moveImg.SetActive(true);
    }

    //当鼠标点击
    private void OnMoveClick(GameObject obj)
    {
        Debug.Log("OnMoveClick" + Input.mousePosition);
    }


    //当触摸移出
    private void OnMoveExit(GameObject obj)
    {
        touchPoint = Input.mousePosition;
        Debug.Log("OnMoveExit" + touchPoint);
        isPressed = false;

        idleImg.SetActive(true);
        moveImg.SetActive(false);
    }


    //初始化头像
    void initPhote()
    {
        //TODO 根据种族数据初始化头像

        Button photeBtn = photeButton.GetComponent<Button>();
        photeBtn.onClick.AddListener(OnDisplayPlayerAttributes);
    }



    //初始化控制按钮
    void initControlButton()
    {
        //TODO 根据首选项初始化位置大小等

        Button jBtn = jButton.GetComponent<Button>();
        jBtn.onClick.AddListener(OnRaceSkill);

        Button kBtn = kButton.GetComponent<Button>();
        kBtn.onClick.AddListener(OnSpecialAttack);

        Button lBtn = lButton.GetComponent<Button>();
        lBtn.onClick.AddListener(OnNormalAttack);

        Button initiativeItemBtn = initiativeItemButton.GetComponent<Button>();
        initiativeItemBtn.onClick.AddListener(OnInitiativeItem);

        Button disposableItemBtn = disposableItemButton.GetComponent<Button>();
        disposableItemBtn.onClick.AddListener(OnDisposableItem);

        initiativeItemImg = initiativeItemButton.transform.FindChild("Image").gameObject;
        disposableItemImg = disposableItemButton.transform.FindChild("Image").gameObject;

    }



    void initMoveBall()
    {

        //TODO 根据首选项初始化位置大小等

        idleImg = moveBall.transform.FindChild("Idle").gameObject;
        moveImg = moveBall.transform.FindChild("Move").gameObject;

        EventTriggerListener.Get(moveBall).onEnter = OnMoveEnter;
        EventTriggerListener.Get(moveBall).onClick = OnMoveClick;
        EventTriggerListener.Get(moveBall).onExit = OnMoveExit;

        centerPosition = new Vector3(110, 115, 0);
        idleImg.SetActive(true);
        moveImg.SetActive(false);
    }

    //初始化精华
    void initEsscences()
    {
        for (int i = 0; i < esscencesTexts.Length;i++ )
            esscencesTexts[i].text= "X 0";
    }

    //初始化小地图
    void initLittleMap()
    {

    }
}

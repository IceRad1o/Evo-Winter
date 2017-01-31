using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackButtonManager : UnitySingleton<AttackButtonManager>
{

    public Button jButton;  //种族技能按钮

    public Button kButton;  //特殊攻击按钮

    public Button lButton;  //普通攻击按钮
    // Use this for initialization
    void Start()
    {
        initControlButton();
    }

    // Update is called once per frame
    void Update()
    {

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
}

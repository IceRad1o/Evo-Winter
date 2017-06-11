using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Author YYF
/// 负责3个攻击按钮的管理
/// 待改善处 应该按下触发而不是离开触发
/// </summary>
public class AttackButtonManager : UnitySingleton<AttackButtonManager>
{
    /*OnNormalAttack
     *@Brief 触发普通攻击
     */
    /// <summary>
    /// 触发普通攻击
    /// </summary>
    public void OnNormalAttack()
    {
        //Debug.Log("You have clicked the  JButton!");
        if (Player.Instance.Character)
              Player.Instance.Character.NormalAttack();
        //TODO 若有冷却倒计时,则显示
    }

    /*OnSpecialAttack
     *@Brief 触发特殊攻击
     */
    /// <summary>
    /// 触发特殊攻击
    /// </summary>
    public void OnSpecialAttack()
    {
        //Debug.Log("You have clicked the  KButton!");
        if (Player.Instance.Character)
             Player.Instance.Character.SpecialAttack();
        //TODO 若有冷却倒计时,则显示
    }

    /*OnRaceSkill
     *@Brief 触发种族技能
     */
    /// <summary>
    /// 触发种族技能
    /// </summary>
    public void OnRaceSkill()
    {
        //Debug.Log("You have clicked the  LButton!");
        if (Player.Instance.Character)
              Player.Instance.Character.UseRaceSkill();
        //TODO 若有冷却倒计时,则显示
    }

    public Button jButton;  //种族技能按钮

    public Button kButton;  //特殊攻击按钮

    public Button lButton;  //普通攻击按钮

    void Start()
    {
        InitControlButton();
        Display();
    }



    //初始化控制按钮
    void InitControlButton()
    {
        //TODO 根据首选项初始化位置大小等

        Button jBtn = jButton.GetComponent<Button>();
        jBtn.onClick.AddListener(OnRaceSkill);

        Button kBtn = kButton.GetComponent<Button>();
        kBtn.onClick.AddListener(OnSpecialAttack);

        Button lBtn = lButton.GetComponent<Button>();
        lBtn.onClick.AddListener(OnNormalAttack);


    }

    void Display()
    {
        StartCoroutine(IEumDisplay());
    }

    IEnumerator IEumDisplay()
    {
        ActionManager.DisplayUIObject(lButton.gameObject);
        yield return new WaitForSeconds(0.2f);
        ActionManager.DisplayUIObject(kButton.gameObject);
        yield return new WaitForSeconds(0.2f);
        ActionManager.DisplayUIObject(jButton.gameObject);
        yield return new WaitForSeconds(0.2f);
    }
}

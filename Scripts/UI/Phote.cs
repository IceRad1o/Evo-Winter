using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 头像模块
/// 点击可查看详细信息
/// </summary>
public class Phote : UnitySingleton<Phote>
{


    /*OnDisplayPlayerAttributes
     *@Brief 显示玩家详细信息界面
     */
    public void OnDisplayPlayerAttributes()
    {
        Debug.Log("You have clicked the  phote!");
        PlayerInfo.Instance.Display();
    }

    /*SetPhote
     *@Brief 设置头像类别
     *@Param int type 类别 0=地精 1=吸血鬼 2=狼人 3=矮人
     *@Remark 未实现
     */
    public void SetPhote(int type)
    {

    }

    public Button photeButton;  //头像按钮


    void Start()
    {
        initPhote();
    }


    void Update()
    {

    }


    //初始化头像
    void initPhote()
    {
        //TODO 根据种族数据初始化头像

        Button photeBtn = photeButton.GetComponent<Button>();
        photeBtn.onClick.AddListener(OnDisplayPlayerAttributes);
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 头像模块
/// 点击可查看详细信息
/// </summary>
public class Phote : UnitySingleton<Phote>
{

    public GameObject grid;
    public GameObject phote;


    public GameObject hardTag;
    public GameObject dangerTag;


    public Sprite[] gridSprite;
    public Sprite[] photeSprite;


    public AudioClip clickSound;
    /*OnDisplayPlayerAttributes
     *@Brief 显示玩家详细信息界面
     */
    public void OnDisplayPlayerAttributes()
    {
      //  Debug.Log("You have clicked the  phote!");
        SoundManager.Instance.PlaySoundEffect(clickSound);
        PlayerInfo.Instance.Display();
    }

    /*SetPhote
     *@Brief 设置头像类别
     *@Param int type 类别 0=地精 1=吸血鬼 2=狼人 3=矮人
     *@Remark 未实现
     */
    public void SetPhote(int type)
    {
       // Debug.Log("type:" + type);
        grid.GetComponent<Image>().sprite = gridSprite[type];
        phote.GetComponent<Image>().sprite = photeSprite[type];
    }

    /// <summary>
    /// 困难游戏模式
    /// </summary>
    /// <param name="isHard"></param>
    public void SetHardGameMode(bool isHard)
    {
        hardTag.SetActive(isHard);
    }

    /// <summary>
    /// Player血量很少
    /// </summary>
    /// <param name="isInDanger"></param>
    public void SetInDanger(bool isInDanger)
    {
        dangerTag.SetActive(isInDanger);
    }


    public Button photeButton;  //头像按钮


    void Start()
    {
        initPhote();
    }




    //初始化头像
    void initPhote()
    {
        //TODO 根据种族数据初始化头像

        Button photeBtn = photeButton.GetComponent<Button>();
        photeBtn.onClick.AddListener(OnDisplayPlayerAttributes);
        int type = Player.Instance.Character.Race;
        grid.GetComponent<Image>().sprite = gridSprite[type];
        phote.GetComponent<Image>().sprite = photeSprite[type];
    }

}

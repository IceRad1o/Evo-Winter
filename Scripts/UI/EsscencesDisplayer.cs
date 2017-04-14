using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Author YYF
/// 负责显示精华数量
/// </summary>
public class EsscencesDisplayer : UnitySingleton<EsscencesDisplayer> {


    public Text[] esscencesTexts;   //指示精华数量的文本控件

    public GameObject[] esscences;
    /*SetEsscences
     *@Brief 设置某种精华的数目
     *@Param1 int type  需要设置数目的精华的种类
     *@Param2 int value 需要设置的数目值
     */
    /// <summary>
    /// 设置指定类型的精华的数量
    /// </summary>
    /// <param name="type">需要设置数目的精华的种类</param>
    /// <param name="value">需要设置的数目值</param>
    public void SetEsscences(int type, int value)
    {
        esscencesTexts[type].text = "X " + value;
    }

    void Start()
    {
        initEsscences();
    }

    //初始化精华
    void initEsscences()
    {
        for (int i = 0; i < esscencesTexts.Length; i++)
            esscencesTexts[i].text = "X 0";


        Button btn0 = esscences[0].GetComponent<Button>();
        btn0.onClick.AddListener(OnEsscences0);

        Button btn1 = esscences[1].GetComponent<Button>();
        btn1.onClick.AddListener(OnEsscences1);

        Button btn2 = esscences[2].GetComponent<Button>();
        btn2.onClick.AddListener(OnEsscences2);

        Button btn3 = esscences[3].GetComponent<Button>();
        btn3.onClick.AddListener(OnEsscences3);
    }

    public void OnEsscences0()
    {
        PlayerManager.Instance.InitPlayer(0 + Player.Instance.Character.RoomElementID % 10);
    }

    public void OnEsscences1()
    {
        PlayerManager.Instance.InitPlayer(4 + Player.Instance.Character.RoomElementID % 10);
    }

    public void OnEsscences2()
    {
        PlayerManager.Instance.InitPlayer(8 + Player.Instance.Character.RoomElementID % 10);
    }
    public void OnEsscences3()
    {
        PlayerManager.Instance.InitPlayer(12 + Player.Instance.Character.RoomElementID % 10);
    }
}

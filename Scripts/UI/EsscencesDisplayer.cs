using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Author YYF
/// 负责显示精华数量
/// </summary>
public class EsscencesDisplayer : UnitySingleton<EsscencesDisplayer> {


    public Text[] esscencesTexts;   //指示精华数量的文本控件


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
    }

}

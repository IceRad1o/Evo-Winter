using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EsscencesDisplayer : UnitySingleton<EsscencesDisplayer> {


    public Text[] esscencesTexts;   //指示精华数量的文本控件


    /*SetEsscences
     *@Brief 设置某种精华的数目
     *@Param1 int type  需要设置数目的精华的种类
     *@Param2 int value 需要设置的数目值
     */
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

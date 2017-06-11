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

    public void TransEsscenceToDisplayer(int type,Vector3 position)
    {
        Vector3 pos = CameraController.Instance.GetComponent<Camera>().WorldToScreenPoint(position);
        GameObject ins=UtilManager.Instantiate(esscences[type], pos);
        ins.transform.SetParent(UIManager.Instance.transform);
        var dest = esscences[type].transform.position;
        iTween.MoveTo(ins, iTween.Hash("x", dest.x,"y",dest.y,"z",dest.z, "time", 0.5f, "easeType", iTween.EaseType.easeInQuad));
        ins.AddComponent<AutoDestoryedObject>().destroyTime = 0.5f;
        StartCoroutine(DelaySet(type));
    }

    IEnumerator DelaySet(int type)
    {
        yield return new WaitForSeconds(0.5f);
        esscences[type].AddComponent<ScaleTo>().Init(0.2f, new Vector4(0.6f, 0.6f, 0, 0), true, false, true);
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
        PlayerManager.Instance.SwitchPlayer(0 + Player.Instance.Character.RoomElementID % 10);
    }

    public void OnEsscences1()
    {
        PlayerManager.Instance.SwitchPlayer(4 + Player.Instance.Character.RoomElementID % 10);
    }

    public void OnEsscences2()
    {
        PlayerManager.Instance.SwitchPlayer(8 + Player.Instance.Character.RoomElementID % 10);
    }
    public void OnEsscences3()
    {
        PlayerManager.Instance.SwitchPlayer(12 + Player.Instance.Character.RoomElementID % 10);
    }
}

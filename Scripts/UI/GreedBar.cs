using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GreedBar : ExUnitySingleton<GreedBar>
{

    void Start()
    {
        gameObject.SetActive(false);
    }
    public GameObject bar;

    void SetGreed(float percent)
    {
          bar.GetComponent<Image>().fillAmount = percent;
    }


    void UnDisplay()
    {
        gameObject.SetActive(false);
    }

    void Display()
    {
        gameObject.SetActive(true);
        bar.GetComponent<Image>().fillAmount = 0f;
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        Debug.Log("msg:" + msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "ShowGreedBar" )
            Display();
        else if (str[0] == "GreedValueChanged")
        {
            SetGreed(float.Parse(str[1]));
        }



    }
}

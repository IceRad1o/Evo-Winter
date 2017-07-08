using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealthBar : ExUnitySingleton<BossHealthBar>
{

    void Start()
    {
        gameObject.SetActive(false);
    }
    public GameObject bloodBar;

    void SetBlood(float percent)
    {
        //Debug.Log("per:" + percent);
        if (percent > 0)
        {
            bloodBar.GetComponent<Image>().fillAmount = percent;
        }
        else
        {
            UnDisplay();
        }

    }


    void UnDisplay()
    {
        gameObject.SetActive(false);
    }

    void Display()
    {
        gameObject.SetActive(true);
        bloodBar.GetComponent<Image>().fillAmount = 1f;
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "BossAppear")
            Display();
        else if(str[0]=="HealthPercent")
        {
            SetBlood(float.Parse(str[1]));
        }



    }
}

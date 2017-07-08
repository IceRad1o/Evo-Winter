using UnityEngine;
using System.Collections;
/// <summary>
/// BloodBar
/// Brief:Show the health of roomElement;
/// Author:IfYan
/// Latest Update Time:2017.5.11
/// </summary>
public class BloodBar : ExSubject {

    static Vector4 startColor = new Vector4(17.0f, 255.0f, 107.0f,255)/255;
    static Vector4 endColor = new Vector4(225, 55, 25,255)/255;
    static Vector4 deltaColor = new Vector4(208, -200, -82,0)/255;
    void Start()
    {
        //gameObject.SetActive(false);
        GetComponentInParent<RoomElement>().AddObserver(this);
    }

    void SetBlood(float percent)
    {
        //Debug.Log("per:" + percent);
        if (percent > 0)
        {
            //控制血条的伸缩
            ScaleTo st = gameObject.AddComponent<ScaleTo>();
            st.destValue = new Vector4(2*percent, 1, 1, 0);
            Debug.Log("vaue:"+st.destValue);
            st.duration = 0.1f;
            //控制血条颜色的变化
            TintTo tt = gameObject.AddComponent<TintTo>();
            tt.destColor = endColor - percent * deltaColor;
            tt.duration = 0.1f;
        }
        else
        {
            UnDisplay();
        }

    }

    public void UnDisplay()
    {
        gameObject.SetActive(false);
    }

    public void Display()
    {
        if (gameObject.activeInHierarchy)
            return;
        gameObject.SetActive(true);
        ScaleTo st=gameObject.AddComponent<ScaleTo>();
        st.destValue = new Vector4(2, 1, 1, 0);
        st.duration = 0.3f;
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "ShowBloodBar")
            Display();
        else if (str[0] == "HealthPercent")
        {
            SetBlood(float.Parse(str[1]));
        }
    }


}

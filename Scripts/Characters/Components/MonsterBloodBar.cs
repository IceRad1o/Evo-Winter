using UnityEngine;
using System.Collections;

public class MonsterBloodBar : ExSubject {

    void Start()
    {
        gameObject.SetActive(false);
        GetComponentInParent<Enemy>().AddObserver(this);
    }

    void SetBlood(float percent)
    {
        //Debug.Log("per:" + percent);
        if (percent > 0)
        {
            ScaleTo st = gameObject.AddComponent<ScaleTo>();
            st.destValue = new Vector4(2*percent, 1, 1, 0);
            st.duration = 0.1f;
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

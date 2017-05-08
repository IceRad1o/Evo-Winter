using UnityEngine;
using System.Collections;
/// <summary>
/// 负重 生命越少,速度越快
/// </summary>
public class OveiWeight : ExSubject {
    bool[] times=new bool[4]{true,true,true,true};

    void Start()
    {
        GetComponent<Boss>().AddObserver(this);
    }

    /**/
    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if(msg=="HealthPercent")
        {
            float percent = float.Parse(str[1]);
            if (percent < 0.8 && times[0])
            {
                this.GetComponent<BuffManager>().CreateDifferenceBuff(120001112);
                times[0] = false;
            }
            else if (percent < 0.6 && times[1])
            {
                this.GetComponent<BuffManager>().CreateDifferenceBuff(120001112);
                times[1] = false;
            }
            else if (percent < 0.4 && times[2])
            {
                this.GetComponent<BuffManager>().CreateDifferenceBuff(120001112);
                times[2] = false;
            }
            else if (percent < 0.2 && times[3])
            {
                this.GetComponent<BuffManager>().CreateDifferenceBuff(120001112);
                times[3] = false;
            }

        }
    }




    
}

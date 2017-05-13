using UnityEngine;
using System.Collections;

public class GiveBuff : Buff {

    string specialTag;

    int giveBuffID;
    int Duration;

    void Trigger()
    {
        if (this == null)
            return;
        Debug.Log("ID:   " + (giveBuffID * 10 +((this.tag == "Player") ? 0 : 1)));
        this.GetComponent<BuffManager>().CreateDifferenceBuff(giveBuffID * 10 + ((this.tag == "Player") ? 0 : 1), specialTag);
        DestroyBuff();
    }
    
    public override void DestroyBuff()
    {
        base.DestroyBuff();
    }
    /// <summary>
    /// 设置初始参数
    /// </summary>
    /// <param name="buffID">要添加的buff</param>
    /// <param name="time">延迟时间*0.1f</param>
    /// <param name="timeType">延迟类型</param>
    public void Create(int buff_ID,int time,int timeType=0,string spTag="")
    {
        Debug.Log("Buff ID  : " + buff_ID);
        specialTag = spTag;
        giveBuffID = buff_ID;
        Duration = time;
        if(timeType==0)
            StartCoroutine(Delay(time));
        if (timeType == 1)
            RoomManager.Instance.AddObserver(this);
    }

    IEnumerator Delay(int time)
    {
        yield return new WaitForSeconds(time * 0.1f);
        Trigger();
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "LeaveRoom")
        {
            Duration--;
            if (Duration <= 0)
                Trigger();
        
        }        
    }
}

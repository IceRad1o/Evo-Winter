using UnityEngine;
using System.Collections;

public class GiveBuff : Buff {


    int giveBuffID;


    void Trigger()
    {
        Debug.Log("ID:   " + giveBuffID * 10 + ((this.tag == "Player") ? 0 : 1));
        this.GetComponent<BuffManager>().CreateDifferenceBuff(giveBuffID * 10 + ((this.tag == "Player") ? 0 : 1), "Skill_L");
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
    public void Create(int buff_ID,int time)
    {
        giveBuffID = buff_ID;
        StartCoroutine(Delay(time));
    }

    IEnumerator Delay(int time)
    {
        yield return new WaitForSeconds(time * 0.1f);
        Trigger();
    }
}

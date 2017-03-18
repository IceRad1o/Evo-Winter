using UnityEngine;
using System.Collections;

public class BuffTiming : Buff {

    
    protected int timingType;
    /// <summary>
    /// 计时方式，0时间制，1房间制，2状态类
    /// </summary>
    public int TimingType
    {
        get { return timingType; }
        set { timingType = value; }
    }
    
    protected int timing;
    /// <summary>
    /// 计时的循环时间
    /// </summary>
    public int Timing
    {
        get { return timing; }
        set { timing = value; }
    }
    
    protected int timingNow;
    /// <summary>
    /// 目前的计时情况，当数值为0时，buff再次触发
    /// </summary>
    public int TimingNow
    {
        get { return timingNow; }
        set { timingNow = value; }
    }
    /// <summary>
    /// ××(D)×（C）××(B)×(A)×× 11
    /// 计时，（A）为buff持续的类型,(B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="ob"></param>
    public void CreateBuff(int ID, GameObject ob)
    {
        int[] part = { 2, 2};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        switch (idPart[1])
        {
            case 1:
                BuffChangeAttributeTemp newBuff1 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff1.Create(ID);
                break;
            case 2:
                BuffChangeAttributeTemp newBuff2 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff2.Create(ID);
                break;
            case 0:
                BuffInvincible newBuff3 = ob.AddComponent<BuffInvincible>();
                newBuff3.Create(ID);
                break;

            default:
                break;
        }
    }




    public virtual void Create(int ID)  {

        
    }

    public virtual void Trigger() { }

    /// <summary>
    /// 延迟,用于buff的循环释放或销毁
    /// </summary>
    /// <param name="time">延迟的时间</param>
    /// <param name="type">1延迟释放，0延迟销毁</param>
    /// <returns></returns>    
    virtual protected IEnumerator delay(float time,int type,float baseNumber=1.0f)
    {
        yield return new WaitForSeconds(time*baseNumber);
        if (type == 1)
            Trigger();
        else
        {
            DestroyBuff();
        }
    } 

}

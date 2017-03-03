using UnityEngine;
using System.Collections;

public class BuffTiming : Buff {

    /// <summary>
    /// 计时方式，0时间制，1房间制，2状态类
    /// </summary>
    private int timingType;
    public int TimingType
    {
        get { return timingType; }
        set { timingType = value; }
    }
    /// <summary>
    /// 计时的循环时间
    /// </summary>
    int timing;
    public int Timing
    {
        get { return timing; }
        set { timing = value; }
    }
    /// <summary>
    /// 目前的计时情况，当数值为0时，buff再次触发
    /// </summary>
    int timingNow;
    public int TimingNow
    {
        get { return timingNow; }
        set { timingNow = value; }
    }

}

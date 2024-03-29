﻿using UnityEngine;
using System.Collections;

public class BuffTiming : Buff {

    
    protected int timingType=0;
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
    public void CreateBuff(int ID, GameObject ob, string spTag = "")
    {
        int[] part = { 2, 2};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        switch (idPart[1])
        {
            case 1:
                BuffChangeAttributeTemp newBuff1 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff1.Create(ID,spTag);
                break;
            case 2:
                BuffChangeAttributeTemp newBuff2 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff2.Create(ID, spTag);
                break;
            case 0:
                BuffInvincible newBuff3 = ob.AddComponent<BuffInvincible>();
                newBuff3.Create(ID);
                break;
            case 3:
                BuffFrozen newBuff4 = ob.AddComponent<BuffFrozen>();
                newBuff4.Create(ID);
                break;
            case 4:
                BuffStatic newBuff5 = ob.AddComponent<BuffStatic>();
                newBuff5.Create(ID, spTag);
                break;
            case 5:
                BuffPoison newBuff6 = ob.AddComponent<BuffPoison>();
                newBuff6.Create(ID);
                break;
            case 6:
                DamageUp newBuff7 = ob.AddComponent<DamageUp>();
                newBuff7.Create(ID);
                break;
            case 7:
                AttributeRandom newBuff8 = ob.AddComponent<AttributeRandom>();
                newBuff8.Create(ID);
                break;

            default:
                break;
        }
    }




    public virtual void Create(int ID, string spTag = "")
    {
        if (UtilManager.Instance.GetFieldFormMsg(spTag, -1) == "Room")
        {
            RoomManager.Instance.AddObserver(this);
            spTag = UtilManager.Instance.GetFieldFormMsg(spTag, 0);
            timingType = 1;

        }
    }

    public override void DestroyBuff()
    {
        base.DestroyBuff();     
          
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


    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        //Debug.Log(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "EnterRoom" && UtilManager.Instance.GetFieldFormMsg(msg, 0) == "Unknow")
        {
            //Debug.Log("this buff duration   " + buffDuration);
            buffDuration--;
            if (buffDuration == 0)
                DestroyBuff();
        }

    }


}

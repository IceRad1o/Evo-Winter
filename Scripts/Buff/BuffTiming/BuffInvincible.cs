using UnityEngine;
using System.Collections;

public class BuffInvincible : BuffTiming{
    

    /// <summary>
    /// ××（F）××(E)×××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID)
    {
        int[] part = { 2, 2, 3, 2, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        

    }


    public override void Trigger()
    {
       

    
    }

    public override void DestroyBuff()
    {
        //Player.Instance.Character
        base.DestroyBuff();
    }

    void Start()
    {
        Trigger();       
        StartCoroutine(delay(BuffDuration, 0));
    }
}

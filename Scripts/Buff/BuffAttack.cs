using UnityEngine;
using System.Collections;

public class BuffAttack : Buff {
    /// <summary>
    /// buff触发的概率
    /// </summary>
    int probability;
    public int Probability
    {
        get { return probability; }
        set { probability = value; }
    }

    bool JudgeTrigger(){
        //创建random的实例
        System.Random random = new System.Random();
        if (random.Next(100) <= probability)
            return true;
        else
            return false;
    }


}

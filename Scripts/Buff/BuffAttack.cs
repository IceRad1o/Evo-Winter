using UnityEngine;
using System.Collections;

public class BuffAttack : Buff {
    /// <summary>
    /// buff触发的概率
    /// </summary>
    protected int probability;
    public int Probability
    {
        get { return probability; }
        set { probability = value; }
    }

    protected bool JudgeTrigger(){
        //创建random的实例
        System.Random random = new System.Random();
        if (random.Next(100) <= probability)
            return true;
        else
            return false;
    }

    public void CreateBuff(int ID,GameObject ob)
    {
        int[] part = { 2,2, 3, 1,2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        switch (idPart[1])
        {
            case 1:
                BuffVampire newBuff = ob.AddComponent<BuffVampire>();
                newBuff.Create(ID);
                break;
            case 2:

                break;
            default:
                break;
        }
    }




    protected virtual void Create(int ID)
    {
        
        BuffID = ID;
        int[] part = { 1,2, 2, 3, 1, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        this.probability = idPart[3];
        this.effectDuration = idPart[4];        
        if (idPart[3] == 0)
            this.buffDuration = idPart[5];

        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        Player.Instance.Character.AddObserver(this);
    }

    protected virtual void Trigger() { }
}

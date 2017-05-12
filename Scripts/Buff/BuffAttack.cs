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
        if (random.Next(100) <= (int)(probability * 1.0f * (1.0f+Player.Instance.Character.LukValue)))
            return true;
        else
            return false;
    }

    public void CreateBuff(int ID,GameObject ob,string spTag="")
    {
        int[] part = { 2,2, 3, 1,2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        switch (idPart[1])
        {
            case 1:
                if (ob.GetComponent<BuffVampire>() == null)
                {
                    BuffVampire newBuff1 = ob.AddComponent<BuffVampire>();

                    newBuff1.Create(ID);
                }
                else
                    ob.GetComponent<BuffVampire>().Probability++;
                break;
            case 2:
                if (ob.GetComponent<AttackSpeedDown>() == null)
                {
                    AttackSpeedDown newBuff1 = ob.AddComponent<AttackSpeedDown>();

                    newBuff1.Create(ID);
                }
                else
                    ob.GetComponent<AttackSpeedDown>().Probability++;
                break;
            case 3:
                if (ob.GetComponent<Attacklethal>() == null)
                {
                    Attacklethal newBuff2 = ob.AddComponent<Attacklethal>();

                    newBuff2.Create(ID);
                }
                else
                    ob.GetComponent<Attacklethal>().Probability++;
                break;
            case 4:
                if (ob.GetComponent<AttackFrozen>() == null)
                {
                    AttackFrozen newBuff3 = ob.AddComponent<AttackFrozen>();

                    newBuff3.Create(ID);
                }
                else
                    ob.GetComponent<AttackFrozen>().Probability++;
                break;
            case 5:
                if (ob.GetComponent<AttackStatic>() == null)
                {
                    AttackStatic newBuff3 = ob.AddComponent<AttackStatic>();

                    newBuff3.Create(ID);
                }
                else
                    ob.GetComponent<AttackStatic>().Probability++;
                break;
            case 6:
                if (ob.GetComponent<AttackHitRecoverUp>() == null)
                {
                    AttackHitRecoverUp newBuff3 = ob.AddComponent<AttackHitRecoverUp>();

                    newBuff3.Create(ID);
                }
                else
                    ob.GetComponent<AttackHitRecoverUp>().Probability++;
                break;
            case 7:
                //Debug.Log("Test Race BuffAttack :" + ob.GetComponent<Character>().Race)
                if (ob.GetComponent<AttackPoison>() == null)
                {

                    AttackPoison newBuff3 = ob.AddComponent<AttackPoison>();

                    newBuff3.Create(ID);
                }
                else
                    ob.GetComponent<AttackPoison>().Probability++;
                break;
            case 8:
                if (ob.GetComponent<AttackSputtering>() == null)
                {
                    AttackSputtering newBuff3 = ob.AddComponent<AttackSputtering>();

                    newBuff3.Create(ID);
                }
                else
                    ob.GetComponent<AttackSputtering>().Probability++;
                break;
            default:
                break;
        }
    }




    protected virtual void Create(int ID)
    {
        
        BuffID = ID;
        int[] part = { 2, 2, 3, 1, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        this.probability = idPart[2];
        this.effectDuration = idPart[4];        
        if (idPart[3] == 0)
            this.buffDuration = idPart[4];

        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);

        Player.Instance.Character.AddObserver(this);
    }

    protected virtual void Trigger() { }
}

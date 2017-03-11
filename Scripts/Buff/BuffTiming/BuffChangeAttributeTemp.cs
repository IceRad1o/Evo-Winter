using UnityEngine;
using System.Collections;

public class BuffChangeAttributeTemp : BuffTiming {

    /// <summary>
    /// 改变的差值
    /// </summary>
    int dValue;
    public int DValue
    {
        get { return dValue; }
        set { dValue = value; }
    }
    /// <summary>
    /// 要改变的属性,0:当前生命 1:生命上限 2:移速 3:攻速 4:攻击范围 5:攻击伤害 6:硬直 7:僵直 8:视野 9:幸运
    /// </summary>
    int attribute;
    public int Attribute
    {
        get { return attribute; }
        set { attribute = value; }
    }

    /// <summary>
    /// ××（F）××(E)××(D)×（C）×××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID)
    {
        int[] part = { 2,2,3,1,2,2,2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        BuffDuration = idPart[2];
        TimingType = idPart[3];
        Timing = idPart[4];
        Attribute = idPart[5];
        if (idPart[1] == 1)
            DValue = idPart[6];
        else
            DValue = -idPart[6];

    }


    public override void Trigger()
    {
        switch (attribute)
        {
            case 0:
                this.gameObject.GetComponent<Character>().Health += dValue;
                break;
            case 2:
                this.gameObject.GetComponent<Character>().MoveSpeed += (int)dValue;
                break;
            case 3:
                this.gameObject.GetComponent<Character>().AttackSpeed += dValue;
                break;
            case 4:
                this.gameObject.GetComponent<Character>().AttackRange += dValue;
                break;
            case 5:
                this.gameObject.GetComponent<Character>().AttackDamage += dValue;
                break;
            case 6:
                this.gameObject.GetComponent<Character>().HitRecover += dValue;
                break;
            case 7:
                this.gameObject.GetComponent<Character>().Spasticity += dValue;
                break;
            case 8:
                this.gameObject.GetComponent<Character>().Sight += (int)dValue;
                break;
            case 9:
                this.gameObject.GetComponent<Character>().Luck += (int)dValue;
                break;
            default:
                break;

        }
    }

    public override void DestroyBuff()
    {
        
        base.DestroyBuff();
    }

	void Start () {
	
	}
	
	
}

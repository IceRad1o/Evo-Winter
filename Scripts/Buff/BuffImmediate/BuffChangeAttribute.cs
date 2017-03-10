using UnityEngine;
using System.Collections;

public class BuffChangeAttribute : Buff
{
    /// <summary>
    /// 改变的差值
    /// </summary>
    float dValue;
    public float DValue
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


    public void Trigger() {
       
       switch (attribute) 
       { 
           case 0:
               Debug.Log("Trigger");
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

       GameObject pfb = Resources.Load("Buffs/12") as GameObject;
       GameObject prefabInstance = Instantiate(pfb);
       prefabInstance.transform.parent = this.gameObject.transform;
 
       this.DestroyBuff();
    }



    public void Create(int ID) {

        
        int[] part = { 4, 2, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        attribute = idPart[1];
        
        dValue = idPart[2];
        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        Trigger();
    }


	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
}

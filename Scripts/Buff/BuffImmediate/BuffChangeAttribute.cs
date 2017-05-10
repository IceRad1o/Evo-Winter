using UnityEngine;
using System.Collections;

public class BuffChangeAttribute : Buff
{
    GameObject pf1;

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


    public void Trigger() {
        //Debug.Log(tag + " Trigger" + dValue + " attribute " + attribute);
       switch (attribute) 
       { 
           case 0:
               this.gameObject.GetComponent<Character>().Hp += dValue;
               break;
           case 2:
               this.gameObject.GetComponent<Character>().Mov += dValue;
               break;
           case 3:
               this.gameObject.GetComponent<Character>().Spd += dValue;
               break;
           case 4:
               this.gameObject.GetComponent<Character>().Rng += dValue;
               break;
           case 5:
               this.gameObject.GetComponent<Character>().Atk += dValue;
               break;
           case 6:
               this.gameObject.GetComponent<Character>().Fhr += dValue;
               break;
           case 7:
               //this.gameObject.GetComponent<Character>().Spasticity += dValue;
               break;
           case 8:
               this.gameObject.GetComponent<Character>().Sight += (int)dValue;
               break;
           case 9:
               this.gameObject.GetComponent<Character>().Luk += (int)dValue;
               break;
           default:
               break;
        
       }

       GameObject pfb = Resources.Load("Buffs/12") as GameObject;
       Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
       GameObject prefabInstance = Instantiate(pfb);
       prefabInstance.transform.position = s;
       prefabInstance.transform.parent = this.gameObject.transform;
       
       this.DestroyBuff();
    }



    public void Create(int ID)
    {
       

        //倒数第二位1表示值为负
        int[] part = { 3, 1, 1,1 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        if (idPart[0] == 1) 
        {
            attribute = idPart[1];
            if (idPart[2] != 1)
                dValue = idPart[3];
            else
                dValue = -idPart[3];
        }
        //命运骰子
        if (idPart[0] == 101)
        {
            attribute = idPart[1];
            
            System.Random random = new System.Random();
            int result = random.Next(100);
            if (result <= 10) 
                dValue =2;
            if (result <= 30 && result >10)
                dValue = 0;
            if (result <= 80 && result > 30)
                dValue = 1;
            if (result <= 100 && result > 80)
                dValue = -1;
        }
        if (idPart[0] == 201)
        {
            attribute = 0;
            dValue = 10 - (int)this.gameObject.GetComponent<Character>().Hp;
        }
        //命运硬币
        if (idPart[0] == 301)
        {
            attribute = 0;

            System.Random random = new System.Random();
            int result = random.Next(100);
            if (result <= 50)
                dValue = -(int)this.gameObject.GetComponent<Character>().Hp;
            else
                DValue = 10 - (int)this.gameObject.GetComponent<Character>().Hp;
        }
        //时间回溯装置
        if (idPart[0] == 401)
        {
            attribute = 0;
            dValue = this.gameObject.GetComponent<BuffManager>().PlayerHealth-(int)this.gameObject.GetComponent<Character>().Hp;

            GameObject pfb = Resources.Load("Buffs/12") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            GameObject pf1 = Instantiate(pfb);
            pf1.transform.position = s;
            pf1.transform.parent = this.gameObject.transform;
            
        }
        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);

        Trigger();
    }


	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
    //延迟触发防止enemy死亡，循环出错
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        
    } 
}

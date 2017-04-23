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
    /// ××（F）××(E)××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID, string spTag = "")
    {
        SpecialTag = spTag;

        int[] part = { 2,2,2,2,2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        BuffDuration = idPart[2];
        Attribute = idPart[3];
        if (idPart[1] == 1)
            DValue = idPart[4];
        else
            DValue = -idPart[4];

        Trigger();
        if (buffDuration!=0)
            StartCoroutine(delay(BuffDuration, 0));
        else
            StartCoroutine(delay(10000, 0));


    }


    public override void Trigger()
    {
        switch (attribute)
        {
            case 0:
                this.gameObject.GetComponent<Character>().Health += dValue;
                break;
            case 2:
                this.gameObject.GetComponent<Character>().MoveSpeed += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                if (dValue <= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 3:
                this.gameObject.GetComponent<Character>().AttackSpeed += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 4:
                this.gameObject.GetComponent<Character>().AttackRange += dValue;
                break;
            case 5:
                this.gameObject.GetComponent<Character>().AttackDamage += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/AttackDamageUp") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 6:
                this.gameObject.GetComponent<Character>().HitRecover += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/HitRecoverUp") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 7:
                this.gameObject.GetComponent<Character>().Spasticity += dValue;
                break;
            case 8:
                this.gameObject.GetComponent<Character>().Sight += dValue;
                break;
            case 9:
                this.gameObject.GetComponent<Character>().Luck += dValue;
                break;
            default:
                break;

        }
    }

    public override void DestroyBuff()
    {
        dValue = -dValue;
        switch (attribute)
        {
            case 0:
                this.gameObject.GetComponent<Character>().Health += dValue;
                break;
            case 2:
                this.gameObject.GetComponent<Character>().MoveSpeed += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                if (dValue <= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 3:
                this.gameObject.GetComponent<Character>().AttackSpeed += dValue;
                break;
            case 4:
                this.gameObject.GetComponent<Character>().AttackRange += dValue;
                break;
            case 5:
                this.gameObject.GetComponent<Character>().AttackDamage += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/AttackDamageUp") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 6:
                this.gameObject.GetComponent<Character>().HitRecover += dValue;
                if (dValue >= 0)
                {
                    GameObject pfb = Resources.Load("Buffs/HitRecoverUp") as GameObject;
                    Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
                    prefabInstance = Instantiate(pfb);
                    prefabInstance.transform.position = s;
                    prefabInstance.transform.parent = this.gameObject.transform;
                    prefabInstance.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case 7:
                this.gameObject.GetComponent<Character>().Spasticity += dValue;
                break;
            case 8:
                this.gameObject.GetComponent<Character>().Sight += dValue;
                break;
            case 9:
                this.gameObject.GetComponent<Character>().Luck += dValue;
                break;
            default:
                break;

        }


        Destroy(prefabInstance);
        base.DestroyBuff();
    }
 
	void Start () {
        
	}
	

    
	
}

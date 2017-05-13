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
        base.Create(ID,spTag);
        
        SpecialTag = spTag;

        if (SpecialTag == "Altar" )
        {
            
            RoomManager.Instance.AddObserver(this);

            int[] part = { 2, 2, 2, 1, 3 };
            int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

            BuffDuration = idPart[2];
            Attribute = idPart[3];
            if (idPart[1] == 1)
                DValue = idPart[4];
            else
                DValue = -idPart[4];
            //Debug.Log("Trigger in buff    value:" +dValue+"   attribute:   "+attribute);
            Trigger();

        }
        else
        {
            int[] part = { 2, 2, 2, 2, 2 };
            int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

            BuffDuration = idPart[2];
            Attribute = idPart[3];
            if (idPart[1] == 1)
                DValue = idPart[4];
            else
                DValue = -idPart[4];

            Trigger();
            if (buffDuration != 0 && timingType == 0)
                StartCoroutine(delay(BuffDuration, 0));

        }
        //else
        //    StartCoroutine(delay(10000, 0));


    }


    public override void Trigger()
    {
        switch (attribute)
        {
            case 0:
                this.gameObject.GetComponent<Character>().Hp += dValue;
                break;
            case 2:
                this.gameObject.GetComponent<Character>().Mov += dValue;

                if (dValue >= 0)
                {
                    //Debug.Log("Speed UP:" + this.gameObject.GetComponent<Character>().MoveSpeed);
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
                this.gameObject.GetComponent<Character>().Spd += dValue;
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
                this.gameObject.GetComponent<Character>().Rng += dValue;
                break;
            case 5:
                this.gameObject.GetComponent<Character>().Atk += dValue;
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
                this.gameObject.GetComponent<Character>().Fhr += dValue;
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
                //this.gameObject.GetComponent<Character>().Spasticity += dValue;
                break;
            case 8:
                this.gameObject.GetComponent<Character>().Sight += dValue;
                break;
            case 9:
                this.gameObject.GetComponent<Character>().Luk += dValue;
                break;
            default:
                break;

        }
    }

    public override void DestroyBuff()
    {
        if (SpecialTag == "Altar")
            UIManager.Instance.RemoveObserver(this);


        dValue = -dValue;
        Destroy(prefabInstance);
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
                this.gameObject.GetComponent<Character>().Sight += dValue;
                break;
            case 9:
                this.gameObject.GetComponent<Character>().Luk += dValue;
                break;
            default:
                break;

        }


        Destroy(prefabInstance);
        base.DestroyBuff();
    }


    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
    }
	

    
	
}

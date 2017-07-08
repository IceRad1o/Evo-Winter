using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuffManager : ExSubject
{
    private string buffManagerTag;
    bool judgeCreate=false;

    int playerHealth;
    //进入房间是玩家的生命
    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    static public int TagBuffNumber(string spTag)
    {
        switch (spTag)
        {
            case "Monster":
                return 1;
            case "Player":
                return 0;
            case "Boss":
                return 2;


            default:
                return -1;
        }
    }


    ArrayList buffList = new ArrayList();
    List<Buff> buffL = new List<Buff>();
    public ArrayList BuffList
    {
        get { return buffList; }
        set { buffList = value; }
    }



    public void CreateBuff(int ID,string spTag="")
    {
        

        if (!judgeCreate)
            return;

        judgeCreate = false;
        int[] part={2,2};
        int[] idPart = UtilManager.Instance.DecomposeID(ID,part);
        switch (idPart[0])
        { 
            case 1:
                BuffChangeAttribute newBuff = this.gameObject.AddComponent<BuffChangeAttribute>();                
                newBuff.Create(ID);
                buffList.Add(newBuff);
                break;
            case 2:
                BuffCreateItem newBuff1 = this.gameObject.AddComponent<BuffCreateItem>();
                newBuff1.Create(ID);
                buffList.Add(newBuff1);
                break;
            case 9:
                new BuffAura().CreateBuff(ID, this.gameObject,spTag);
                break;
            case 10:
                new BuffAttack().CreateBuff(ID,this.gameObject);
                break;
            case 11:
                //Debug.Log("Trigger3");
                new BuffTiming().CreateBuff(ID, this.gameObject,spTag);
                break;

            case 20:
                new BuffAura().CreateBuff(ID, this.gameObject);                
                break;
            case 30:
                BuffShield newBuff2;
                if (this.gameObject.GetComponent<BuffShield>() == null)
                {
                    newBuff2 = this.gameObject.AddComponent<BuffShield>();
                    newBuff2.Create(ID);
                    buffList.Add(newBuff2);
                }
                
                break;
            default:
                break;
        }
    }

    public void CreateDifferenceBuff(int ID,string spTag="")
    {
        if (buffManagerTag == "Player" && ID % 10 == 0)
            judgeCreate = true;
        if (buffManagerTag == "Monster" && ID % 10 == 1)
            judgeCreate = true;
        if (buffManagerTag == "Boss" && ID % 10 == 2)
            judgeCreate = true;

        //Debug.Log("         " + buffManagerTag);
        CreateBuff(ID / 10,spTag);

    }

    /// <summary>
    /// 保存buff的信息
    /// </summary>
    /// <returns></returns>
    public string[] SavingBuff()
    {
        /// <summary>
        /// 临时存Buff
        /// </summary>
        List<string> list = new List<string>();

        foreach (var item in this.GetComponents<Buff>())
        {
            list.Add(item.SaveBuff());
        }
        return list.ToArray();
    }

    public void LoadBuff()
    {
        string[] strBuff={""," "};

        for (int i = 0; i < strBuff.Length; i++)
        {
            CreateDifferenceBuff(int.Parse(UtilManager.Instance.GetFieldFormMsg(strBuff[i], 0))*10,"time;"+UtilManager.Instance.GetFieldFormMsg(strBuff[i], 1));
            
        }
    
    }

    public void LoadBuff(string[] str)
    {
        string[] strBuff = str;
        //Debug.Log("strBuff.Length     " + strBuff.Length);
        for (int i = 0; i < strBuff.Length; i++)
        {
            //Debug.Log("strBuff   :" + strBuff[i]);
            CreateDifferenceBuff(int.Parse(UtilManager.Instance.GetFieldFormMsg(strBuff[i], 0)) * 10, "time;" + UtilManager.Instance.GetFieldFormMsg(strBuff[i], 1));
        }

    }


    public void DestoryManager()
    {
        if (this.tag == "Player")
        {
            ItemManager.Instance.RemoveObserver(this);

            this.gameObject.GetComponent<Character>().RemoveObserver(this);

            
            RoomManager.Instance.RemoveObserver(this);
        }
        //Destroy(this);
    }


	void Start () {

        //将ItemManager设为观察者
        if (this.gameObject.tag == "Player")
        {
            ItemManager.Instance.AddObserver(this);
            int loadOrNew = PlayerPrefs.GetInt("isNew", 1);
            if (loadOrNew != 1)
            { 
                
            }
        }
        this.gameObject.GetComponent<Character>().AddObserver(this);
        RoomManager.Instance.AddObserver(this);
        if (this.gameObject.tag == "Player")
            buffManagerTag = "Player";
        if (this.gameObject.tag == "Monster")
            buffManagerTag = "Monster";
        if (this.gameObject.tag == "Boss")
            buffManagerTag = "Boss";



	}


    void Awake()
    {
        if (this.gameObject.tag == "Player")
            buffManagerTag = "Player";
        if (this.gameObject.tag == "Monster")
            buffManagerTag = "Monster";
        if (this.gameObject.tag == "Boss")
            buffManagerTag = "Boss";
    }


    public override void OnNotify(string msg)
    {

        string bID = "";        

        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Buff_ID", msg, 0);
        if (bID != "Fail" )
        {
            int id = int.Parse(bID);
            //Debug.Log("bID" + id);
            if (buffManagerTag == "Player" && id % 10 == 0)
                judgeCreate = true;
            if (buffManagerTag == "Monster" && id % 10 == 1)
                judgeCreate = true;
            CreateBuff(id/10);
        }

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "HealthChanged" && int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0)) - int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 1)) > 0 && UtilManager.Instance.GetFieldFormMsg(msg, 2) == "Player")
        {
            CreateDifferenceBuff(100110);
        }
        //Debug.Log(UtilManager.Instance.GetFieldFormMsg(msg, -1));
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "EnterRoom" && buffManagerTag == "Player") 
        {
            playerHealth = (int)this.gameObject.GetComponent<Character>().Hp;
        }
    }
	
}


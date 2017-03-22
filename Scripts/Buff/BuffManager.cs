using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuffManager : ExSubject
{
    private string buffManagerTag;
    bool judgeCreate=false;

    ArrayList buffList = new ArrayList();
    List<Buff> buffL = new List<Buff>();
    public ArrayList BuffList
    {
        get { return buffList; }
        set { buffList = value; }
    }



    public void CreateBuff(int ID)
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
                if (idPart[1] == 1)
                {
                    BuffCreateItem newBuff1 = this.gameObject.AddComponent<BuffCreateItem>();
                    newBuff1.Create(ID);
                    buffList.Add(newBuff1);
                }  

                break;
            case 10:
                new BuffAttack().CreateBuff(ID,this.gameObject);
                break;
            case 11:
                new BuffTiming().CreateBuff(ID, this.gameObject);
                break;

            case 20:
                BuffAllDamage newBuff3 = this.gameObject.AddComponent<BuffAllDamage>();                
                newBuff3.Create(ID);
                buffList.Add(newBuff3);
                break;
            default:
                break;
        }
    }

    public void CreateDifferenceBuff(int ID)
    {
        if (buffManagerTag == "Player" && ID % 10 == 0)
            judgeCreate = true;
        if (buffManagerTag == "Enemy" && ID % 10 == 1)
            judgeCreate = true;
        CreateBuff(ID / 10);

    }

	
	void Start () {
        //将ItemManager设为观察者
        ItemManager.Instance.AddObserver(this);
        Player.Instance.Character.AddObserver(this);
        Debug.Log(this.gameObject.tag);
        if (this.gameObject.tag == "Player")
            buffManagerTag = "Player";
        else
            buffManagerTag = "Enemy";
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
            if (buffManagerTag == "Enemy" && id % 10 == 1)
                judgeCreate = true;
            CreateBuff(id/10);
        }

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "HealthChanged" && int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0)) - int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 1)) > 0 && UtilManager.Instance.GetFieldFormMsg(msg, 2) == "Player")
        {
            CreateDifferenceBuff(100110);
        }
    }
	
}


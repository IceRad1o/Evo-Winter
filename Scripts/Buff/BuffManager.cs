using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuffManager : ExSubject
{
    private string buffManagerTag;
    
    ArrayList buffList = new ArrayList();
    List<Buff> buffL = new List<Buff>();
    public ArrayList BuffList
    {
        get { return buffList; }
        set { buffList = value; }
    }



    public void CreateBuff(int ID)
    {
        int[] part={2};
        int[] idPart = UtilManager.Instance.DecomposeID(ID,part);
        switch (idPart[0])
        { 
            case 1:
                BuffChangeAttribute newBuff = this.gameObject.AddComponent<BuffChangeAttribute>();                
                newBuff.Create(ID);
                buffList.Add(newBuff);
                break;
            case 10:
                new BuffAttack().CreateBuff(ID,this.gameObject);
                break;
            case 11:
                new BuffTiming().CreateBuff(ID, this.gameObject);
                break;
            default:
                break;
        }
    }



	
	void Start () {
        //将ItemManager设为观察者
        ItemManager.Instance.AddObserver(this);
        if (this.gameObject.tag == "Player")
            buffManagerTag = "Player";
	}


    public override void OnNotify(string msg)
    {

        string bID = "";
        if (buffManagerTag != "Player")
            return;

        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Buff_ID", msg, 0);
        if (bID != "Fail" )
            CreateBuff(int.Parse(bID));

    }
	
}


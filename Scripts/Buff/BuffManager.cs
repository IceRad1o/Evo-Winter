using UnityEngine;
using System.Collections;

public class BuffManager : UnitySingleton<BuffManager>
{



    public void CreateBuff(int ID)
    {
    
    }



	// Use this for initialization
	void Start () {
	
	}
	
	
}



class Item_Buff_Observer : Observer 
{
    public override void OnNotify(string msg)
    {
        string bID = "";
            
            
        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Buff_ID", msg, 1);
        if (bID != "Error")
            BuffManager.Instance.CreateBuff(int.Parse(bID));










    }
}

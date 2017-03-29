using UnityEngine;
using System.Collections;

public class BuffAura : BuffTiming {

    int addBuffID;
    /// <summary>
    /// 光环要增加的buff的ID
    /// </summary>
    public int AddBuffID
    {
        get { return addBuffID; }
        set { addBuffID = value; }
    }



    public void CreateBuff(int ID, GameObject ob)
    {
        int[] part = { 2, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        switch (idPart[0])
        {
            case 20:
                BuffAllDamage newBuff3 = ob.gameObject.AddComponent<BuffAllDamage>();                
                newBuff3.Create(ID);
                ob.gameObject.GetComponent<BuffManager>().BuffList.Add(newBuff3);
                break;
            case 2:
                BuffChangeAttributeTemp newBuff2 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff2.Create(ID);
                break;
            default:
                break;
        }
    }




   
	void Start () {
	
	}
	
	
}

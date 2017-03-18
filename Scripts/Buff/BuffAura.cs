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
        switch (idPart[1])
        {
            case 1:
                BuffChangeAttributeTemp newBuff1 = ob.AddComponent<BuffChangeAttributeTemp>();
                newBuff1.Create(ID);
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

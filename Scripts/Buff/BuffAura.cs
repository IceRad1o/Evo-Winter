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



    public void CreateBuff(int ID, GameObject ob,string spTag="")
    {
        int[] part = { 2, 2,8};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        if (spTag != "")
            SpecialTag = spTag;
        else
            SpecialTag = "Monster";

        int tagNumber=BuffManager.TagBuffNumber(SpecialTag);
        


        //普遍的光环buff
        if (idPart[0] == 9)
        {
            var listTemp = CharacterManager.Instance.CharacterList.ToArray();
            for (int item=0;item<listTemp.Length;item++)
            {
                if (listTemp[item] != null && listTemp[item].tag == SpecialTag)
                    this.GetComponent<BuffManager>().CreateDifferenceBuff(idPart[2] * 10 + tagNumber);                
            }
        }


        switch (idPart[1])
        {
            case 1:
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

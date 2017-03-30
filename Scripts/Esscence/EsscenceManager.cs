using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EsscenceManager : ExUnitySingleton<EsscenceManager>
{
    public GameObject esscencePfb;
    List<Esscence> esscenceList = new List<Esscence>();
    List<int> esscenceNumber = new List<int>();
    List<List<int>> skillList=new List<List<int>>();


    /// <summary>
    /// 创造一个精华
    /// </summary>
    /// <param name="ID">精华的ID</param>
    /// <param name="s">精华生成的位置</param>
    public void CreateEsscence(int ID=5,Vector3 s= default(Vector3)) 
    {
        Esscence esscenceInstance = Instantiate(esscencePfb, s, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Esscence;
        if (ID >= 0 && ID <= 3)
            esscenceInstance.Create(ID);
        else
            esscenceInstance.Create((int)Random.value * 4);
        esscenceList.Add(esscenceInstance);
    }

    private void addEsscence(int ID) 
    {
        esscenceNumber[ID]++;
        for (int i = 1; i <= 5; i++)
            if (esscenceNumber[ID] == i * (i + 1) / 2)
                skillList[ID].Add(addSkill(ID));
    }

    private int addSkill(int ID) 
    {
        Debug.Log("dddddddddddd");
        return 0;
    }

    void Start() 
    {
        for (int i = 0; i <= 3; i++)
        {
            esscenceNumber.Add(0);
            List<int> newlist = new List<int>();
            skillList.Add(newlist);
        }
    
    }


    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "Get_Esscence")
        {
            addEsscence(int.Parse(str[1]));
        }
    }


    

}

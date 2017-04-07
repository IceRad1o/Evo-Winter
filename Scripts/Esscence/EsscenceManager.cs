using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EsscenceManager : ExUnitySingleton<EsscenceManager>
{
    public Esscence esscencePfb;
    List<Esscence> esscenceList = new List<Esscence>();
    List<int> esscenceNumber = new List<int>();
    public List<int> EsscenceNumber
    {
        get { return esscenceNumber; }
        set { esscenceNumber = value; }
    }
    List<List<int>> skillList=new List<List<int>>();

    public bool doubleEsscence=false;


    int skillEsscence=0;

    int[,] skillArray = {    
                        { 0, 1, 2, 3, 4 },
                        { 0, 1, 2, 3, 4 },
                        { 0, 1, 2, 3, 4 },
                        { 0, 1, 2, 3, 4 }
                        }; 
    
    int[,] skillTable = {    
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 }, 
                        { 0, 0, 0, 0, 0 }, 
                        { 0, 0, 0, 0, 0 } 
                        }; 
    

    /// <summary>
    /// 创造一个精华
    /// </summary>
    /// <param name="ID">精华的ID</param>
    /// <param name="s">精华生成的位置</param>
    public void CreateEsscence(int ID=5,Vector3 s= default(Vector3)) 
    {
        if (s == new Vector3(0, 0, 0))
            s = new Vector3(1, -1, -1);
        Esscence esscenceInstance = Instantiate(esscencePfb, s, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Esscence;
        if (ID >= 0 && ID <= 3)
            esscenceInstance.Create(ID);
        else
            esscenceInstance.Create((int)Random.value * 4);
        esscenceList.Add(esscenceInstance);
    }
    /// <summary>
    /// 增加一个精华
    /// </summary>
    /// <param name="ID"></param>
    public void AddEsscence(int ID) 
    {

        esscenceNumber[ID]++;
        for (int i = 1; i <= 5; i++)
            if (esscenceNumber[ID] == i * (i + 1) / 2)
                AddSkill(skillArray[skillEsscence,i-1]);

        if (doubleEsscence)
        {
            esscenceNumber[ID]++;
            for (int i = 1; i <= 5; i++)
                if (esscenceNumber[ID] == i * (i + 1) / 2)
                    AddSkill(skillArray[skillEsscence, i - 1]);  
      
        }
    }
    /// <summary>
    /// 移除一个精华
    /// </summary>
    /// <param name="ID"></param>
    public void RemoveEsscence(int ID)
    {
        esscenceNumber[ID]--;
        for (int i = 1; i <= 5; i++)
            if (esscenceNumber[ID] == i * (i + 1) / 2-1)
                RemoveSkill(skillArray[skillEsscence, i - 1]);
    }
    /// <summary>
    /// 将两个精华转换
    /// </summary>
    public void ChangeTwoEsscence() 
    {
        int judge = 0;
        for (int k = 0; k <= 3; k++)
            judge += esscenceNumber[k];
        if (judge == 0)
            return;
        int i = 0, j = 0;
        while (true)
        {
            i = (int)(Random.value * 4);
            if (esscenceNumber[i] > 0)
                break;
        }
        while (true)
        {
            j = (int)(Random.value * 4);
            if (esscenceNumber[j] > 0)
                break;
        }
        esscenceNumber[j]--;
        esscenceNumber[i]++;
        Debug.Log("i:   " + i + "  j:   " + j);
    }
    /// <summary>
    /// 增加一个技能
    /// </summary>
    /// <param name="ID">技能ID</param>
    /// <returns></returns>
    private int AddSkill(int ID) 
    {
        Debug.Log("dddddddddddd");
        return 0;
    }
    /// <summary>
    /// 移除一个技能
    /// </summary>
    /// <param name="ID">技能ID</param>
    /// <returns></returns>
    private int RemoveSkill(int ID)
    {
        Debug.Log("ssss");
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
        GetRandomArray();
    }

    void GetRandomArray()
    {
        int skillNumber = 5;
        int i,k;
        for (int j = 0; j < 4;j++)
            for (i = 0; i < skillNumber - 1; i++)
            {
                k = (int)(Random.value * (skillNumber - i)) + i;
                int n = skillArray[j, i];
                skillArray[j, i] = skillArray[j, k];
                skillArray[j, k] = n;
            }
        string s="";
        for (int a = 0; a < 4; a++)
        {
            for (int b = 0; b < 5; b++)
                s += skillArray[a, b];
            s += '\n';
        }
        Debug.Log(s);
    }


    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "Get_Esscence")
        {
            AddEsscence(int.Parse(str[1]));
        }
    }


    

}

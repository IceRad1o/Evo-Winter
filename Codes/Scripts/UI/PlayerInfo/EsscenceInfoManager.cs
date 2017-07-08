using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class EsscenceInfo
{
    public string name;
    public string desc;
    public Sprite sprite;
    public int type;
    public int id;
    public void init(string name,string desc,Sprite sprite,int type,int id)
    {
        this.name=name;
        this.desc=desc;
        this.sprite=sprite;
        this.type=type;
        this.id=id;
    }
}

public class EsscenceInfoManager : ExUnitySingleton<EsscenceInfoManager>
{
    const int esscenceTypeNum = 4;
    const int esscenceEachNum = 4;

     List<EsscenceInfo>[] infos = new List<EsscenceInfo>[esscenceTypeNum];
    List<GameObject> iconList = new List<GameObject>();
    public GameObject skillIcon;
    public GameObject[] esscenceIcons;
    // Use this for initialization

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < esscenceTypeNum; i++)
        {
            infos[i] = new List<EsscenceInfo>();
        }

        for (int i = 0; i < esscenceTypeNum; i++)
        {
            for (int j = 0; j < esscenceEachNum; j++)
            {
                // Debug.Log(skillIcon);

                GameObject a = Instantiate(skillIcon, esscenceIcons[i].transform, true) as GameObject;
                a.transform.localPosition = new Vector3((j + 1.2f) * 90, 0, 0);
                iconList.Add(a);
            }
        }
    }

    void Start()
    {
   



    }


    public void Add(EsscenceInfo eInfo)
    {
        Debug.Log("tttt:"+eInfo.type);
        if(infos[eInfo.type]==null)
        {
            infos[eInfo.type] = new List<EsscenceInfo>();
        }
        infos[eInfo.type].Add(eInfo);

        int a = esscenceEachNum * (eInfo.type );
        int b = infos[eInfo.type].Count-1;
       // Debug.Log("位于" + a + "排" + b + "列");
        iconList[a + b].GetComponent<Image>().sprite = eInfo.sprite;


    }


    void Adjust()
    {

    }




}

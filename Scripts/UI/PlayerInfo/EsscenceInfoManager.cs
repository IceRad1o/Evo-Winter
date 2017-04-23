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
    void Start()
    {
        for (int i = 0; i < esscenceTypeNum; i++)
        {
            infos[i] = new List<EsscenceInfo>();
        }


        for (int i = 0; i < esscenceTypeNum; i++)
        {
            for (int j = 0; j < esscenceEachNum; j++)
            {
                GameObject a = Instantiate(skillIcon, esscenceIcons[i].transform,true) as GameObject;
                a.transform.localPosition = new Vector3(0, -(j + 1) * 80, 0);
                iconList.Add(a);
            }
        }
    }


    public void Add(EsscenceInfo eInfo)
    {
        infos[eInfo.type].Add(eInfo);
        iconList[esscenceEachNum * (eInfo.type - 1) + infos[eInfo.type].Count - 1].GetComponent<Image>().sprite = eInfo.sprite;


    }


    void Adjust()
    {

    }




}

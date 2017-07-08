using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RETag
{
    Peaceful,
    Terror,
    LargeSize,
    MiddleSize,
    SmallSize
}

public enum CombinationID
{

}

public class RECombination : MonoBehaviour {
    public int combinationID=0;
    public string combinationName = "Undefined";
    public RETag[] tags;
    public Sprite icon;
    public int minCheckpoint=1;
    public int maxCheckpoint = 5;
    public RmType type;
    public int size;


    public RoomElementInfo[] GetRECombinationInfo()
    {
       var re= GetComponentsInChildren<RoomElement>();
        List<RoomElementInfo> list=new List<RoomElementInfo>(re.Length);
        for(int i=0;i<re.Length;i++)
        {
            list.Add(re[i].GetInfo());
        }
        return list.ToArray();
    }

    public void AddRECombinationInfoToList(List<RoomElementInfo> list)
    {
        var re = GetComponentsInChildren<RoomElement>();
      
        for (int i = 0; i < re.Length; i++)
        {
            list.Add(re[i].GetInfo());
            //Debug.Log("11:"+re[i].GetInfo().ID);
        }
      
    }

    public void MakeToJsonFile()
    {

    }

}

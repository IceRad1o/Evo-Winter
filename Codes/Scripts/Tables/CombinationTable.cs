using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinationTable : ExUnitySingleton<CombinationTable> {

    public RECombination[] combinations;
    public static bool isInit = false;
    public static Dictionary<int, RECombination> dict = new Dictionary<int, RECombination>(100);

    public RECombination[] maps;

    public static Dictionary<int, RECombination> mapIDDict = new Dictionary<int, RECombination>(100);
    public static Dictionary<RmType, RECombination[]> mapTypeDict = new Dictionary<RmType, RECombination[]>();
    public void Start()
    {
        if(!isInit)
        {
            Init();
            isInit = true;
        }
     
    }

    public void Init()
    {

        for (int i = 0; i < combinations.Length; i++)
        {
            //Debug.Log("<color=blue>Fatal error:</color>" + i, gameObject);
            dict.Add(combinations[i].combinationID, combinations[i]);
        }

        for (int i = 0; i < maps.Length; i++)
        {
            //Debug.Log("<color=blue>Fatal error:</color>" + i, gameObject);
            mapIDDict.Add(maps[i].combinationID, maps[i]);
        }

        foreach (RmType item in System.Enum.GetValues(typeof(RmType)))
        {
            mapTypeDict.Add(item, FindMapsByType(item));
        }
    }

    RECombination[] FindMapsByType(RmType rmType)
    {
        List<RECombination> list = new List<RECombination>();
        for (int i = 0; i < maps.Length; i++)
        {
            if (maps[i].type == rmType)
                list.Add(maps[i]);
        }
        return list.ToArray();
    }
}

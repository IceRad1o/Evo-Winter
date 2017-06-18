using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinationTable : ExUnitySingleton<CombinationTable> {

    public RECombination[] combinations;

    public static Dictionary<int, RECombination> dict = new Dictionary<int, RECombination>(100);

    public RECombination[] maps;

    public static Dictionary<int, RECombination> mapDict = new Dictionary<int, RECombination>(100);
    public void Start()
    {
        Init();
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
            mapDict.Add(maps[i].combinationID, maps[i]);
        }
    }

}

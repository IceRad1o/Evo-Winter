using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldDisplayer : ExUnitySingleton<GoldDisplayer> {

    public GameObject valueObj;

    public void SetGlod(int value)
    {
        valueObj.GetComponent<Text>().text = value.ToString();
    }

}

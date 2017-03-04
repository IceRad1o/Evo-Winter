using UnityEngine;
using System.Collections;

public class PreferenceManager : UnitySingleton<PreferenceManager> {

    PreferenceData data;

    public PreferenceData Data
    {
        get { return data; }
        set { data = value; }
    }

    void InitData()
    {

    }

}

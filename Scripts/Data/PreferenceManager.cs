using UnityEngine;
using System.Collections;
/// <summary>
/// 首选项管理
/// </summary>
public class PreferenceManager : ExUnitySingleton<PreferenceManager> {

    PreferenceData data;
    int[] AdItem;
    public PreferenceData Data
    {
        get { return data; }
        set { data = value; }
    }

    void InitData()
    {
        data = new PreferenceData();
        data.Init();
    }

    public override void Awake()
    {
 	     base.Awake();
        InitData();
        AdItem = data.AdvancedItem;
    } 

    public override void OnNotify(string msg)
    {
       
       if(msg==null)
       {
           Debug.LogError("the msg is null!");
       }
        string [] str=UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "BgmVolumeChanged")
            data.BackGroundMusicVolume = float.Parse(str[1]);
        if (str[0] == "EfxVolumeChanged")
            data.SoundEffectVolume = float.Parse(str[1]);
        if (str[0] == "IsVolumeOnChanged")
            data.IsVolumeOn = int.Parse(str[1]);
        if (str[0] == "Item_Advance")
        {
            AdItem[int.Parse(str[1])] = 1;
            data.AdvancedItem = AdItem;
        }

    }
}

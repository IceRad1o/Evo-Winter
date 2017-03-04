using UnityEngine;
using System.Collections;

public class ProfileManager : ExUnitySingleton<ProfileManager>{


    ProfileData data;

    public ProfileData Data
    {
        get { return data; }
        set { data = value; }
    }

    void InitData()
    {
        data = new ProfileData();
        data.Init();
    }


    void Start()
    {
        InitData();

    }

    public override void OnNotify(string msg)
    {

        if (msg == null)
        {
            Debug.LogError("the msg is null!");
        }
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "BgmVolumeChanged")
            ;// data.BackGroundMusicVolume = float.Parse(str[1]);
        if (str[0] == "EfxVolumeChanged")
                ; // data.SoundEffectVolume = float.Parse(str[1]);
    }
}

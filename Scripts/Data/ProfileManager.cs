using UnityEngine;
using System.Collections;


/// <summary>
/// 存档管理
/// 存档数据在每一次进入房间和清空房间的时候更新
/// </summary>
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
        if (str[0] == "ClearRoom")
        {
            data.Health = Player.Instance.Character.Health;
            data.MoveSpeed = Player.Instance.Character.MoveSpeed;
            data.AttackRange = Player.Instance.Character.AttackRange;
            data.AttackDamage = Player.Instance.Character.AttackDamage;
            data.HitRecover = Player.Instance.Character.HitRecover;
        }
        if(str[0]=="EnterRoom")
        {

        }
        //if (str[0] == "BgmVolumeChanged")
            // data.BackGroundMusicVolume = float.Parse(str[1]);
    }
}

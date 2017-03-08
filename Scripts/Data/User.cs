using UnityEngine;
using System.Collections;
/// <summary>
/// 记录用户的数据,每次开启游戏会从存档中加载数据
/// 每次通过一个房间会加载数据到用户数据中
/// </summary>
public class User :ExUnitySingleton<User> {

    GameData data;

    public GameData Data
    {
        get { return data; }
        set { data = value; }
    }

 
    void InitData()
    {
        data = new GameData();
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
        //if (str[0] == "BgmVolumeChanged")
          //  data.BackGroundMusicVolume = float.Parse(str[1]);

    }
}

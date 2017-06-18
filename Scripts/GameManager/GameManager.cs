using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// 负责控制整个游戏的流程
/// 上帝
/// </summary>
public class GameManager : ExUnitySingleton<GameManager>{	

	void Start () {
	
        Player.Instance.Character.AddObserver(this);
        InitGame();
        PlayerPrefs.SetInt("canLoad", 1);
	}
		
    //游戏初始化
    void InitGame()
    {
        int isNewGame = PlayerPrefs.GetInt("isNew", 1);
        RETable.Instance.InitREDict();
        if (isNewGame == 1)
        {
            //设置关卡
            CheckpointManager.Instance.SetupCheckpoint();
        }
        else
        {
			CheckpointManager.Instance.LoadCheckpoint();
        }

    }

    //切换到主场景
    void SwitchToMainScene()
    {
        SceneManager.LoadScene("Scenes/Formal/MainScene");
    }

    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "Die")
        {
            if (str[1] == "Player")
            {
                PlayerPrefs.SetInt("canLoad", 0);
                SwitchToMainScene();
            }
        }
        
    }
	

}

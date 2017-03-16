using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : ExUnitySingleton<GameManager>{

    //参数的声明


    private int loadOrNew;
    private bool doingSetup;



	// Use this for initialization
	void Start () {

        InitGame();
	}

    //游戏初始化
    void InitGame()
    {
        doingSetup = true;

        loadOrNew = PlayerPrefs.GetInt("isNew", 1);

        if (loadOrNew == 1)
        {
            //设置关卡
            CheckpointManager.Instance.SetupCheckpoint();
            Notify("SetupCheckpoint;" + CheckpointManager.Instance.CheckpointNumber);
            //设置房间0
            RoomManager.Instance.SetupScene(CheckpointManager.Instance.roomList[0].type,
                                    CheckpointManager.Instance.roomList[0].doorDirection,
                                    CheckpointManager.Instance.roomList[0].roomX,
                                    CheckpointManager.Instance.roomList[0].roomY);
        }

        else
        {

        }

    }

	

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : ExUnitySingleton<GameManager>{

    //参数的声明



    private bool doingSetup;



	// Use this for initialization
	void Start () {

        InitGame();
	}

    //游戏初始化
    void InitGame()
    {
        doingSetup = true;
        //设置关卡
        CheckpointManager.Instance.SetupCheckpoint();
        //传递房间门的方向
        //roomScript.SetDoorDierction(CheckpointManager.Instance.roomList[0].doorDirection);

        Debug.Log("type" + CheckpointManager.Instance.roomList[0].type);
        RoomManager.Instance.SetupScene(  CheckpointManager.Instance.roomList[0].type,
                                CheckpointManager.Instance.roomList[0].doorDirection, 
                                CheckpointManager.Instance.roomList[0].roomX, 
                                CheckpointManager.Instance.roomList[0].roomY);
    }

	

}

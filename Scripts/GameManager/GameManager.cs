using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : ExUnitySingleton<GameManager>{

    //参数的声明
    public static GameManager instance = null;
    public RoomManager roomScript;
    public CheckpointManager checkpointScrip;

    private bool doingSetup;



	// Use this for initialization
	void Start () {
        roomScript = GetComponent<RoomManager>();
        checkpointScrip = GetComponent<CheckpointManager>();
        InitGame();
	}

    //游戏初始化
    void InitGame()
    {
        doingSetup = true;
        //设置关卡
        checkpointScrip.SetupCheckpoint();
        //传递房间门的方向
        //roomScript.SetDoorDierction(checkpointScrip.roomList[0].doorDirection);

        Debug.Log("type" + checkpointScrip.roomList[0].type);
        roomScript.SetupScene(  checkpointScrip.roomList[0].type,
                                checkpointScrip.roomList[0].doorDirection, 
                                checkpointScrip.roomList[0].roomX, 
                                checkpointScrip.roomList[0].roomY);
    }

	

}

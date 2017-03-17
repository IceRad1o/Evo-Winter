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
        //loadOrNew = 0;

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
            //ProfileManager.Instance.Data.CurMapX;
            CheckpointManager.Instance.LoadCheckpoint(ProfileManager.Instance.Data.Map);
            //ProfileManager.Instance.Data.Map;

            RoomManager.Instance.LoadScene(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY,
                CheckpointManager.Instance.GetNextRoom(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY).doorDirection,
                ProfileManager.Instance.Data.RoomElementRoomX,
                ProfileManager.Instance.Data.RoomElementRoomY,
                ProfileManager.Instance.Data.RoomElementID,
                ProfileManager.Instance.Data.RoomElementPosX,
                ProfileManager.Instance.Data.RoomElementPosY,
                ProfileManager.Instance.Data.RoomElementPosZ);

            RoomManager.Instance.LoadEnemy(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY,
                ProfileManager.Instance.Data.EnemyID,
                ProfileManager.Instance.Data.EnemyPosX,
                ProfileManager.Instance.Data.EnemyPosY,
                ProfileManager.Instance.Data.EnemyPosZ);


        }

    }

	

}

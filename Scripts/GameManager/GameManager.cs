using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : ExUnitySingleton<GameManager>{

    //参数的声明
    private int loadOrNew;
    private bool doingSetup;

	//左墙0，右墙1
	public GameObject[] wall;
	private GameObject lefWall;
	private GameObject rigWall;
	//墙的位置
	private Vector3[] bigWall = new Vector3[]{new Vector3(14.11f,0,0),new Vector3(-16.12f,2.9f,0)};
	private Vector3[] midWall = new Vector3[]{new Vector3(10.11f,0,0),new Vector3(-11.12f,2.9f,0)};
	private Vector3[] smlWall = new Vector3[]{new Vector3(7.11f,0,0),new Vector3(-8.5f,2.9f,0)};

	// Use this for initialization
	void Start () {
		lefWall = Instantiate(wall[0], bigWall[0], Quaternion.Euler (-45f, 0f, 0f)) as GameObject;
		rigWall = Instantiate(wall[1], bigWall[1], Quaternion.Euler (-45f, 0f, 0f)) as GameObject;
        Player.Instance.Character.AddObserver(this);
        InitGame();
        PlayerPrefs.SetInt("canLoad", 1);
	}
		
	//布局墙
	public void LayoutWall(int x, int y)
	{
		int rms = CheckpointManager.Instance.GetNextRoom (x, y).roomSize;
		Vector3[] wal = bigWall;
		switch (rms)
		{
		case 1:
			wal = smlWall;
			break;
		case 2:
			wal = midWall;
			break;
		case 3:
			wal = bigWall;
			break;
		}
		lefWall.transform.position = wal [0];
		rigWall.transform.position = wal [1];
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
            //CheckpointManager.Instance.SetRowColumn(4,4);
            CheckpointManager.Instance.SetupCheckpoint();
            Notify("SetupCheckpoint;" + CheckpointManager.Instance.CheckpointNumber);
            //设置房间
            int roomNumber = 0;
            for (int i = 0; i < CheckpointManager.Instance.roomList.Count; i++)
            {
                if (CheckpointManager.Instance.roomList[i].type == -1)
                {
                    roomNumber = i;
                    break;
                }
            }
            RoomManager.Instance.SetupScene(CheckpointManager.Instance.roomList[roomNumber].type,
                                    CheckpointManager.Instance.roomList[roomNumber].doorDirection,
                                    CheckpointManager.Instance.roomList[roomNumber].roomX,
                                    CheckpointManager.Instance.roomList[roomNumber].roomY,
									CheckpointManager.Instance.roomList[roomNumber].roomSize);
            RoomManager.Instance.Notify("EnterRoom;Unknow;" + CheckpointManager.Instance.roomList[roomNumber].type);
        }

        else
        {
            //ProfileManager.Instance.Data.CurMapX;
			CheckpointManager.Instance.LoadCheckpoint(ProfileManager.Instance.Data.Map, ProfileManager.Instance.Data.IsMapPassed, ProfileManager.Instance.Data.RoomSize);

            RoomManager.Instance.LoadScene(
                ProfileManager.Instance.Data.Map[ProfileManager.Instance.Data.CurMapX * (CheckpointManager.Instance.columns)+ProfileManager.Instance.Data.CurMapY * (CheckpointManager.Instance.rows)],
                ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY,
                CheckpointManager.Instance.GetNextRoom(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY).doorDirection,
                ProfileManager.Instance.Data.RoomElementRoomX,
                ProfileManager.Instance.Data.RoomElementRoomY,
                ProfileManager.Instance.Data.RoomElementID,
                ProfileManager.Instance.Data.RoomElementPosX,
                ProfileManager.Instance.Data.RoomElementPosY,
                ProfileManager.Instance.Data.RoomElementPosZ,
				CheckpointManager.Instance.GetNextRoom(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY).roomSize);


            

            RoomManager.Instance.LoadEnemy(ProfileManager.Instance.Data.CurMapX, ProfileManager.Instance.Data.CurMapY,
                ProfileManager.Instance.Data.EnemyID,
                ProfileManager.Instance.Data.EnemyPosX,
                ProfileManager.Instance.Data.EnemyPosY,
                ProfileManager.Instance.Data.EnemyPosZ);

            RoomManager.Instance.Notify("EnterRoom;Know");


        }

    }
    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "Die")
        {
            if (str[1] == "Player")
            {
                PlayerPrefs.SetInt("canLoad", 0);
                SceneManager.LoadScene("Scenes/Formal/MainScene");
            }
        }
        
    }
	

}

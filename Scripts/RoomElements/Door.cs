using UnityEngine;
using System.Collections;

public class Door : RoomElement
{
    //门的位置，0上，1下，2左，3右
    private int position;
	//判断是否进入过房间
	int pass = 0;
    public override void Awake()
    {
        base.Awake();
        RoomElementID = 3;
        this.tag = "StaticGroundElement";
	}

    public void SetPosition(int posi)
    {
        position = posi;
    }


    //碰撞检测
    private void OnTriggerEnter(Collider other)
    {

    

        //Debug.Log("DoorOnTiger" + other.tag + "    敌人数量：" + EnemyManager.Instance.EnemyList.Count);
        if (other.tag == "Player"&&EnemyManager.Instance.EnemyList.Count==0)
        {
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(EnterRoom());
            //等待1s
        }
    }

	//设置或载入
	void SetOrLoad(int x, int y, int map)
	{
		// x , y = RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1
		// map = ProfileManager.Instance.Data.CurMapX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurMapY+1)
		if (CheckpointManager.Instance.GetNextRoom(x, y).pass == 0)
		{
			RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(x, y).type,
				CheckpointManager.Instance.GetNextRoom(x, y).doorDirection,
				CheckpointManager.Instance.GetNextRoom(x, y).roomX,
				CheckpointManager.Instance.GetNextRoom(x, y).roomY,
				CheckpointManager.Instance.GetNextRoom(x, y).roomSize);
		}
		else
		{
			pass = 1;
			RoomManager.Instance.LoadScene(
				ProfileManager.Instance.Data.Map[map], 
				x, y,
				CheckpointManager.Instance.GetNextRoom(x, y).doorDirection,
				ProfileManager.Instance.Data.RoomElementRoomX,
				ProfileManager.Instance.Data.RoomElementRoomY,
				ProfileManager.Instance.Data.RoomElementID,
				ProfileManager.Instance.Data.RoomElementPosX,
				ProfileManager.Instance.Data.RoomElementPosY,
				ProfileManager.Instance.Data.RoomElementPosZ,
				CheckpointManager.Instance.GetNextRoom(x, y).roomSize);

		}
	}


    IEnumerator EnterRoom()
    {
        RoomManager.Instance.Notify("LeaveRoom;"+position);


        yield return new WaitForSeconds(0.5f);

        //CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);
        int roomDir = position;
        int rmX;
        int rmY;
        int map;
        //yield return(WaitForSeconds (1f));

        switch (roomDir)
        {

            case 0:
                //进入上侧房间   
                Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                Player.Instance.Character.transform.position = new Vector3(0f, -7f, 0f);
                rmX = RoomManager.Instance.roomX - 1;
                rmY = RoomManager.Instance.roomY;
                map = (ProfileManager.Instance.Data.CurMapX - 1) * (CheckpointManager.Instance.columns) + ProfileManager.Instance.Data.CurMapY;
                SetOrLoad(rmX, rmY, map);
                break;
            case 1:
                //进入下侧房间
                Debug.Log("进下xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                Player.Instance.Character.transform.position = new Vector3(0f, -1.2f, 0f);
                rmX = RoomManager.Instance.roomX + 1;
                rmY = RoomManager.Instance.roomY;
                map = (ProfileManager.Instance.Data.CurMapX + 1) * (CheckpointManager.Instance.columns) + ProfileManager.Instance.Data.CurMapY;
                SetOrLoad(rmX, rmY, map);
                break;
            case 2:
                //进入左侧房间
                Debug.Log("进左xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                //Player.Instance.Character.transform.position = new Vector3 (10.5f, -4f, 0f);
                rmX = RoomManager.Instance.roomX;
                rmY = RoomManager.Instance.roomY - 1;
                map = ProfileManager.Instance.Data.CurMapX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurMapY - 1);
                SetOrLoad(rmX, rmY, map);
                if (CheckpointManager.Instance.GetNextRoom(rmX, rmY).roomSize == 1)
                    Player.Instance.Character.transform.position = new Vector3(4.5f, -4f, 0f);
                else if (CheckpointManager.Instance.GetNextRoom(rmX, rmY).roomSize == 2)
                    Player.Instance.Character.transform.position = new Vector3(7f, -4f, 0f);
                else
                    Player.Instance.Character.transform.position = new Vector3(10.5f, -4f, 0f);
                break;
            case 3:
                //进入右侧房间
                Debug.Log("进右xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                //Player.Instance.Character.transform.position = new Vector3 (-10.5f, -4f, 0f);
                rmX = RoomManager.Instance.roomX;
                rmY = RoomManager.Instance.roomY + 1;
                map = ProfileManager.Instance.Data.CurMapX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurMapY + 1);
                SetOrLoad(rmX, rmY, map);
                if (CheckpointManager.Instance.GetNextRoom(rmX, rmY).roomSize == 1)
                    Player.Instance.Character.transform.position = new Vector3(-4.5f, -4f, 0f);
                else if (CheckpointManager.Instance.GetNextRoom(rmX, rmY).roomSize == 2)
                    Player.Instance.Character.transform.position = new Vector3(-7f, -4f, 0f);
                else
                    Player.Instance.Character.transform.position = new Vector3(-10.5f, -4f, 0f);
                break;
        }

        CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);

        if (pass == 1)
        {
            //Debug.Log("进进过的房间");
            RoomManager.Instance.Notify("EnterRoom;Know;" + roomDir);

        }
        else
        {
            //Debug.Log("进没进过的房间");
            RoomManager.Instance.Notify("EnterRoom;Unknow;" + roomDir);
        }
    }

}

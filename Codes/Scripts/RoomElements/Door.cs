using UnityEngine;
using System.Collections;

public class Door : RoomElement
{
    public Direction doorType;
    //门的位置，0上，1下，2左，3右
    private int position;
	//判断是否进入过房间
	int pass = 0;
    public override void Awake()
    {
        base.Awake();
        //RoomElementID = 3;
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
    Vector2 GetNearRoomXY()
    {
        int x = RoomManager.Instance.roomInfo.roomX;
        int y = RoomManager.Instance.roomInfo.roomY;
        switch (RoomElementID)
        {

            case REID.DoorFront:
                return new Vector2(x-1, y );
               
            case REID.DoorBack:
                return new Vector2(x+1,y );
           
            case REID.DoorLeft:
                return new Vector2(x, y-1);
           ;
            case REID.DoorRight:
                return new Vector2(x, y+1 );

            default:
                break;
        }
        return new Vector2();
    }
	//设置或载入
	void SetOrLoad(int x, int y, int map)
	{

        RoomManager.Instance.LoadRoom(GetNearRoomXY());
        return;
        // x , y = RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1
        // map = ProfileManager.Instance.Data.CurMapX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurMapY+1)
        if (CheckpointManager.Instance.GetRoomInfo(x, y).pass == 0)
		{
			RoomManager.Instance.LoadRoom(CheckpointManager.Instance.GetRoomInfo(x, y));
		}
		else
		{
			pass = 1;
			RoomManager.Instance.LoadRoom(x, y);

		}
	}


    IEnumerator EnterRoom()
    {
        //RoomManager.Instance.Notify("LeaveRoom;"+ (RoomElementID-REID.DoorFront));
        RoomManager.Instance.LeaveRoom((RoomElementID - REID.DoorFront));

        yield return new WaitForSeconds(0.5f);

        //CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);
        int roomDir = position;
        int rmX;
        int rmY;
        int map;
        //yield return(WaitForSeconds (1f));

        switch (RoomElementID)
        {

            case REID.DoorFront:
                //进入上侧房间   
                Debug.Log("进上xy：" + RoomManager.Instance.RoomX + "," + RoomManager.Instance.RoomY);
                Player.Instance.Character.transform.position = new Vector3(0f, -6.5f, 0f);
                rmX = RoomManager.Instance.RoomX - 1;
                rmY = RoomManager.Instance.RoomY;
                map = (ProfileManager.Instance.Data.CurRoomX - 1) * (CheckpointManager.Instance.columns) + ProfileManager.Instance.Data.CurRoomY;
                SetOrLoad(rmX, rmY, map);
                break;
            case REID.DoorBack:
                //进入下侧房间
                Debug.Log("进下xy：" + RoomManager.Instance.RoomX + "," + RoomManager.Instance.RoomY);
                Player.Instance.Character.transform.position = new Vector3(0f, -1.2f, 0f);
                rmX = RoomManager.Instance.RoomX + 1;
                rmY = RoomManager.Instance.RoomY;
                map = (ProfileManager.Instance.Data.CurRoomX + 1) * (CheckpointManager.Instance.columns) + ProfileManager.Instance.Data.CurRoomY;
                SetOrLoad(rmX, rmY, map);
                break;
                case REID.DoorLeft:
                //进入左侧房间
                Debug.Log("进左xy：" + RoomManager.Instance.RoomX + "," + RoomManager.Instance.RoomY);
                //Player.Instance.Character.transform.position = new Vector3 (10.5f, -4f, 0f);
                rmX = RoomManager.Instance.RoomX;
                rmY = RoomManager.Instance.RoomY - 1;
                map = ProfileManager.Instance.Data.CurRoomX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurRoomY - 1);
                SetOrLoad(rmX, rmY, map);
                if (CheckpointManager.Instance.GetRoomInfo(rmX, rmY).roomSize == 1)
                    Player.Instance.Character.transform.position = new Vector3(4.5f, -4f, 0f);
                else if (CheckpointManager.Instance.GetRoomInfo(rmX, rmY).roomSize == 2)
                    Player.Instance.Character.transform.position = new Vector3(7f, -4f, 0f);
                else
                    Player.Instance.Character.transform.position = new Vector3(10.5f, -4f, 0f);
                break;
            case REID.DoorRight:
                //进入右侧房间
                Debug.Log("进右xy：" + RoomManager.Instance.RoomX + "," + RoomManager.Instance.RoomY);
                //Player.Instance.Character.transform.position = new Vector3 (-10.5f, -4f, 0f);
                rmX = RoomManager.Instance.RoomX;
                rmY = RoomManager.Instance.RoomY + 1;
                map = ProfileManager.Instance.Data.CurRoomX * (CheckpointManager.Instance.columns) + (ProfileManager.Instance.Data.CurRoomY + 1);
                SetOrLoad(rmX, rmY, map);
                if (CheckpointManager.Instance.GetRoomInfo(rmX, rmY).roomSize == 1)
                    Player.Instance.Character.transform.position = new Vector3(-4.5f, -4f, 0f);
                else if (CheckpointManager.Instance.GetRoomInfo(rmX, rmY).roomSize == 2)
                    Player.Instance.Character.transform.position = new Vector3(-7f, -4f, 0f);
                else
                    Player.Instance.Character.transform.position = new Vector3(-10.5f, -4f, 0f);
                break;
        }

        CheckpointManager.Instance.GetRoomInfo(RoomManager.Instance.RoomX, RoomManager.Instance.RoomY).pass=1;

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

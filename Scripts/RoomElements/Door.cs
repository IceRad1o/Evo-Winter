using UnityEngine;
using System.Collections;

public class Door : RoomElement
{
    private RoomManager roomManager;
    private CheckpointManager checkpointManager;

	void Start () {
        RoomElementID = 3;
        roomManager = GetComponent<RoomManager>();
        checkpointManager = GetComponent<CheckpointManager>();

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        RoomManager rm = roomManager;
        Debug.Log("门的碰撞物"+other.tag);
        if (other.tag == "PlayerRB2D")
        {
            int roomDir = 0;
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("房间管理者" + roomManager);
                if (roomManager.DoorDirection[i] > 0)
                {
                    roomDir = i;
                    break;
                }
            }
            switch (roomDir)
            {
                case 0:
                    //进入上侧房间
                    roomManager.SetupScene(checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY).type,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY).doorDirection,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY).roomX,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY).roomY);
                    break;
                case 1:
                    //进入下侧房间
                    roomManager.SetupScene(checkpointManager.GetNextRoom(roomManager.roomX + 1, roomManager.roomY).type,
                                    checkpointManager.GetNextRoom(roomManager.roomX + 1, roomManager.roomY).doorDirection,
                                    checkpointManager.GetNextRoom(roomManager.roomX + 1, roomManager.roomY).roomX,
                                    checkpointManager.GetNextRoom(roomManager.roomX + 1, roomManager.roomY).roomY);
                    break;
                case 2:
                    //进入左侧房间
                    roomManager.SetupScene(checkpointManager.GetNextRoom(roomManager.roomX, roomManager.roomY - 1).type,
                                    checkpointManager.GetNextRoom(roomManager.roomX, roomManager.roomY - 1).doorDirection,
                                    checkpointManager.GetNextRoom(roomManager.roomX, roomManager.roomY - 1).roomX,
                                    checkpointManager.GetNextRoom(roomManager.roomX, roomManager.roomY - 1).roomY);
                    break;
                case 3:
                    //进入右侧房间
                    roomManager.SetupScene(checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY + 1).type,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY + 1).doorDirection,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY + 1).roomX,
                                    checkpointManager.GetNextRoom(roomManager.roomX - 1, roomManager.roomY + 1).roomY);
                    break;
            }
        }
    }

}

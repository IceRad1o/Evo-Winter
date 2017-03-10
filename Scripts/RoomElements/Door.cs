using UnityEngine;
using System.Collections;

public class Door : RoomElement
{


	void Start () {
        RoomElementID = 3;
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PlayerRB2D"&&EnemyManager.Instance.EnemyList.Count==0)
        {
            RoomElementManager.Instance.Notify("LeaveRoom");
            int roomDir = 0;
            for (int i = 0; i < 4; i++)
            {
                if (RoomManager.Instance.DoorDirection[i] > 0)
                {
                    roomDir = i;
                    break;
                }
            }

            //RoomElementManager.Instance.RoomElementList.Clear();
            
            switch (roomDir)
            {
                    
                case 0:
                    //进入上侧房间   
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomY);
                    break;
                case 1:
                    //进入下侧房间
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomY);
                    break;
                case 2:
                    //进入左侧房间
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomY);
                    break;
                case 3:
                    //进入右侧房间
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomY);
                    break;
            }
        }
    }

}

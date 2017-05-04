using UnityEngine;
using System.Collections;

public class Stair : RoomElement {

    public override void Awake()
    {
        base.Awake();
        RoomElementID = 16;
	}
	
     //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("StairOnTiger" + other.tag + "    敌人数量：" + EnemyManager.Instance.EnemyList.Count);
        if (other.tag == "Player" && EnemyManager.Instance.EnemyList.Count == 0)
        {
            Debug.Log("StairOnTiger");
            //设置关卡
            if (CheckpointManager.Instance.CheckpointNumber < 5)
            {
                CheckpointManager.Instance.SetupCheckpoint();
                GameManager.Instance.Notify("SetupCheckpoint;"+CheckpointManager.Instance.CheckpointNumber);
            }

            //设置房间0
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

            RoomManager.Instance.Notify("EnterRoom;Unknow");
        }
    }

}

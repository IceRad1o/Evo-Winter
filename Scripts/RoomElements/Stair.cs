using UnityEngine;
using System.Collections;

public class Stair : RoomElement {

	void Awake () {
        RoomElementID = 10;
	}
	
     //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && EnemyManager.Instance.EnemyList.Count == 0)
        {
            //设置关卡
            if (CheckpointManager.Instance.CheckpointNumber < 5)
            {
                CheckpointManager.Instance.SetupCheckpoint();
                GameManager.Instance.Notify("SetupCheckpoint;"+CheckpointManager.Instance.CheckpointNumber);
            }

            //设置房间0
            RoomManager.Instance.SetupScene(CheckpointManager.Instance.roomList[0].type,
                                    CheckpointManager.Instance.roomList[0].doorDirection,
                                    CheckpointManager.Instance.roomList[0].roomX,
                                    CheckpointManager.Instance.roomList[0].roomY);
        }
    }

}

using UnityEngine;
using System.Collections;

public class Door : RoomElement
{
    //门的位置，0上，1下，2左，3右
    private int position;


	void Start () {
        RoomElementID = 3;
        
	}

    public void SetPosition(int posi)
    {
        position = posi;
    }


    //碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PlayerRB2D"&&EnemyManager.Instance.EnemyList.Count==0)
        {
            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);
            RoomElementManager.Instance.Notify("LeaveRoom");
            int roomDir = position;
            
            switch (roomDir)
            {
                    
                case 0:
                    //进入上侧房间   
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomY);
                    }
                    else
                    {
                        //RoomManager.Instance.LoadScene();
                        //RoomManager.Instance.LoadEnemy();
                    }
                    break;
                case 1:
                    //进入下侧房间
                    Debug.Log("进下xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomY);
                    }
                    else
                    {
                        //RoomManager.Instance.LoadScene();
                        //RoomManager.Instance.LoadEnemy();
                    }                   
                    break;
                case 2:
                    //进入左侧房间
                    Debug.Log("进左xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomY);
                    }
                    else
                    {
                        //RoomManager.Instance.LoadScene();
                        //RoomManager.Instance.LoadEnemy();
                    }
                    break;
                case 3:
                    //进入右侧房间
                    Debug.Log("进右xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomY);
                    }
                    else
                    {
                        //RoomManager.Instance.LoadScene();
                        //RoomManager.Instance.LoadEnemy();
                    }
                    break;
            }
        }
    }

}

using UnityEngine;
using System.Collections;

public class Door : RoomElement
{
    //门的位置，0上，1下，2左，3右
    private int position;


	void Awake () {
        RoomElementID = 3;
        
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
            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);
            //RoomManager.Instance.Notify("LeaveRoom");    
            int roomDir = position;
            int pass = 0;

            //for (int i = 0; i < ProfileManager.Instance.Data.RoomElementID.Length; i++)
            //{
            //    Debug.Log("ID:" + ProfileManager.Instance.Data.RoomElementID[i]);
            //    Debug.Log("posX:" + ProfileManager.Instance.Data.RoomElementPosX[i]);
            //    Debug.Log("roomX:" + ProfileManager.Instance.Data.RoomElementRoomX[i]);
            //    Debug.Log("roomY:" + ProfileManager.Instance.Data.RoomElementRoomY[i]);
            //    Debug.Log("\n");
            //}



            switch (roomDir)
            {
                    
                case 0:
                    //进入上侧房间   
                    Debug.Log("进上xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    Player.Instance.Character.transform.position = new Vector3(0f, -1f, 0f);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).pass == 0)
                    {

                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).roomY);
                    }
                    else
                    {
                        pass = 1;
                        RoomManager.Instance.LoadScene(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY,
                            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY).doorDirection,
                            ProfileManager.Instance.Data.RoomElementRoomX,
                            ProfileManager.Instance.Data.RoomElementRoomY,
                            ProfileManager.Instance.Data.RoomElementID,
                            ProfileManager.Instance.Data.RoomElementPosX,
                            ProfileManager.Instance.Data.RoomElementPosY,
                            ProfileManager.Instance.Data.RoomElementPosZ);

                        //RoomManager.Instance.LoadEnemy(RoomManager.Instance.roomX - 1, RoomManager.Instance.roomY,
                        //    ProfileManager.Instance.Data.EnemyID,
                        //    ProfileManager.Instance.Data.EnemyPosX,
                        //    ProfileManager.Instance.Data.EnemyPosY,
                        //    ProfileManager.Instance.Data.EnemyPosZ);

                    }
                    break;
                case 1:
                    //进入下侧房间
                    Debug.Log("进下xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    Player.Instance.Character.transform.position = new Vector3(0f, -0.8f, 0f);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).roomY);
                    }
                    else
                    {
                        pass = 1;
                        RoomManager.Instance.LoadScene(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY,
                            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX + 1, RoomManager.Instance.roomY).doorDirection,
                            ProfileManager.Instance.Data.RoomElementRoomX,
                            ProfileManager.Instance.Data.RoomElementRoomY,
                            ProfileManager.Instance.Data.RoomElementID,
                            ProfileManager.Instance.Data.RoomElementPosX,
                            ProfileManager.Instance.Data.RoomElementPosY,
                            ProfileManager.Instance.Data.RoomElementPosZ);


                    }                   
                    break;
                case 2:
                    //进入左侧房间
                    Debug.Log("进左xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    Player.Instance.Character.transform.position = new Vector3(4.5f, -2f, 0f);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).roomY);
                    }
                    else
                    {
                        pass = 1;
                        Debug.Log("回左边:" + ProfileManager.Instance.Data.RoomElementRoomX[0] + " ");
                        RoomManager.Instance.LoadScene(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1,
                            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY - 1).doorDirection,
                            ProfileManager.Instance.Data.RoomElementRoomX,
                            ProfileManager.Instance.Data.RoomElementRoomY,
                            ProfileManager.Instance.Data.RoomElementID,
                            ProfileManager.Instance.Data.RoomElementPosX,
                            ProfileManager.Instance.Data.RoomElementPosY,
                            ProfileManager.Instance.Data.RoomElementPosZ);

                    }
                    break;
                case 3:
                    //进入右侧房间
                    Debug.Log("进右xy：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
                    Player.Instance.Character.transform.position = new Vector3(-4.5f, -2f, 0f);
                    if (CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).pass == 0)
                    {
                        RoomManager.Instance.SetupScene(CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).type,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).doorDirection,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomX,
                                    CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).roomY);
                    }
                    else
                    {
                        pass = 1;
                        RoomManager.Instance.LoadScene(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1,
                            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY + 1).doorDirection,
                            ProfileManager.Instance.Data.RoomElementRoomX,
                            ProfileManager.Instance.Data.RoomElementRoomY,
                            ProfileManager.Instance.Data.RoomElementID,
                            ProfileManager.Instance.Data.RoomElementPosX,
                            ProfileManager.Instance.Data.RoomElementPosY,
                            ProfileManager.Instance.Data.RoomElementPosZ);

                    }
                    break;
            }
            CheckpointManager.Instance.GetNextRoom(RoomManager.Instance.roomX, RoomManager.Instance.roomY).SetPass(1);

            if (pass == 1)
            {
                //Debug.Log("进进过的房间");
                RoomManager.Instance.Notify("EnterRoom;Know");
             
            }
            else
            {
                //Debug.Log("进没进过的房间");
                RoomManager.Instance.Notify("EnterRoom;Unknow");
            }

        }
    }

}

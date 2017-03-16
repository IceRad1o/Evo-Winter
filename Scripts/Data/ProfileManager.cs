using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 存档管理
/// 存档数据在每一次进入房间和清空房间的时候更新
/// </summary>
public class ProfileManager : ExUnitySingleton<ProfileManager>{


    ProfileData data;

    List<int> tempREID = new List<int>();
    List<float> tempREPosX = new List<float>();
    List<float> tempREPosY = new List<float>();
    List<float> tempREPosZ = new List<float>();
    List<int> tempRERoomX = new List<int>();
    List<int> tempRERoomY = new List<int>();

    public ProfileData Data
    {
        get { return data; }
        set { data = value; }
    }

    void InitData()
    {
        data = new ProfileData();
        data.Init();
    }


    void Start()
    {
        RoomManager.Instance.AddObserver(this);
        EnemyManager.Instance.AddObserver(this);
        InitData();

    }

    public override void OnNotify(string msg)
    {

        if (msg == null)
        {
            Debug.LogError("the msg is null!");
        }
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        //TODO leaveRoom存档
        if (str[0] == "ClearRoom" || (str[0] == "EnterRoom"&&str[1]=="Unknow")||str[0]== "LeaveRoom")
        {
            Debug.Log("PofileManager recieved the msg : "+msg);
            //Player
            data.Health = Player.Instance.Character.Health;
            data.MoveSpeed = Player.Instance.Character.MoveSpeed;
            data.AttackRange = Player.Instance.Character.AttackRange;
            data.AttackDamage = Player.Instance.Character.AttackDamage;
            data.HitRecover = Player.Instance.Character.HitRecover;
            data.Spasticity = Player.Instance.Character.Spasticity;
            data.Race = Player.Instance.Character.Weapon;
            data.Sight = Player.Instance.Character.Sight;
            data.Camp = Player.Instance.Character.Camp;
            data.Luck = Player.Instance.Character.Luck;
            data.ActionStateMachineID = Player.Instance.Character.ActionStateMachine.MachineID;
            data.CurPosition = Player.Instance.Character.transform.position;


            //Item
            if (ItemManager.Instance.itemInitiative!=null)
                data.ItemEnergy = ItemManager.Instance.itemInitiative.EnergyNow;
            List<int> tempID = new List<int>();
            if (ItemManager.Instance.itemInitiative != null)
                tempID.Add(ItemManager.Instance.GetInitiativeItem().ItemID);
            else
                tempID.Add(-1);
            if (ItemManager.Instance.GetDisposableItems() != null)
                tempID.Add(ItemManager.Instance.GetDisposableItems().ItemID);

            for (int i = 0; i < ItemManager.Instance.listDisposableItem.Count; i++)
                tempID.Add(ItemManager.Instance.listDisposableItem[i].ItemID);
            for (int i = 0; i < ItemManager.Instance.listImmediatelyItem.Count; i++)
                tempID.Add(ItemManager.Instance.listImmediatelyItem[i].ItemID);
            for (int i = 0; i < ItemManager.Instance.listInitiativeItem.Count; i++)
                tempID.Add(ItemManager.Instance.listInitiativeItem[i].ItemID);
            data.ItemsID = tempID.ToArray();
            tempID.Clear();




            //Enemy
            List<float> tempPosX = new List<float>();
            List<float> tempPosY = new List<float>();
            List<float> tempPosZ = new List<float>();
            for (int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
            {
                tempID.Add(EnemyManager.Instance.EnemyList[i].CharacterID);
                tempPosX.Add(EnemyManager.Instance.EnemyList[i].transform.position.x);
                tempPosY.Add(EnemyManager.Instance.EnemyList[i].transform.position.y);
                tempPosZ.Add(EnemyManager.Instance.EnemyList[i].transform.position.z);
            }
            data.EnemyID=tempID.ToArray();
            data.EnemyPosX=tempPosX.ToArray();
            data.EnemyPosY=tempPosY.ToArray();
            data.EnemyPosZ=tempPosZ.ToArray();
            tempID.Clear();
            tempPosX.Clear();
            tempPosY.Clear();
            tempPosZ.Clear();

            //Room
            
            for(int i=0;i<CheckpointManager.Instance.rows;i++)
                for(int j=0;j<CheckpointManager.Instance.columns;j++)
                {
                    
                         tempID.Add(CheckpointManager.Instance.roomArray[i,j]);
                }
                
            data.Map = tempID.ToArray();
            //TODO data.curLevel;
            data.CurMapX = RoomManager.Instance.roomX;
            data.CurMapY = RoomManager.Instance.roomY;

            //RoomElements

            //移除重复元素
            //注意要从后往前删,否则序号会出问题
            for (int i = tempRERoomX.Count-1; i >=0; i--)
                   {
                       if (RoomManager.Instance.roomX == tempRERoomX[i] && RoomManager.Instance.roomY ==tempRERoomY[i])
                       {
                           Debug.Log("删除:" + tempREID[i]);
                           tempREID.RemoveAt(i);
                           tempREPosX.RemoveAt(i);
                           tempREPosY.RemoveAt(i);
                           tempREPosZ.RemoveAt(i);
                           tempRERoomX.RemoveAt(i);
                           tempRERoomY.RemoveAt(i);
                       }
                   }
           

            //加载元素
            for(int i=0;i<RoomElementManager.Instance.RoomElementList.Count;i++)
            {
                Debug.Log("加载:"+RoomElementManager.Instance.RoomElementList[i].RoomElementID);
                tempREID.Add(RoomElementManager.Instance.RoomElementList[i].RoomElementID);
                tempREPosX.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.x);
                tempREPosY.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.y);
                tempREPosZ.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.z);
                tempRERoomX.Add(RoomManager.Instance.roomX);
                tempRERoomY.Add(RoomManager.Instance.roomY);
            }
            data.RoomElementID = tempREID.ToArray();
            data.RoomElementPosX = tempREPosX.ToArray();
            data.RoomElementPosY = tempREPosY.ToArray();
            data.RoomElementPosZ = tempREPosZ.ToArray();
            data.RoomElementRoomX = tempRERoomX.ToArray();
            data.RoomElementRoomY = tempRERoomY.ToArray();



            //TODO BuffID

            //TODO EsscencesID

           

        }

    }
}

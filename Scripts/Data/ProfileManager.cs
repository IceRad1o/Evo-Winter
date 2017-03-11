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
        InitData();

    }

    public override void OnNotify(string msg)
    {

        if (msg == null)
        {
            Debug.LogError("the msg is null!");
        }
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "ClearRoom" || str[0] == "EnterRoom")
        {

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
                for(int j=0;j<CheckpointManager.Instance.columns;i++)
                 tempID.Add(CheckpointManager.Instance.roomArray[i,j]);
            data.Map = tempID.ToArray();
            //TODO data.curLevel;
            data.CurMapX = RoomManager.Instance.roomX;
            data.CurMapY = RoomManager.Instance.roomY;

            //RoomElements
            for(int i=0;i<RoomElementManager.Instance.RoomElementList.Count;i++)
            {
                tempREID.Add(RoomElementManager.Instance.RoomElementList[i].RoomElementID);
                tempREPosX.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.x);
                tempREPosY.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.y);
                tempREPosZ.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.z);
                tempRERoomX.Add(RoomManager.Instance.roomX);
                tempRERoomX.Add(RoomManager.Instance.roomY);
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

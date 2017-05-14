using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 存档管理
/// Brief:存档数据在每一次进入房间和清空房间以及离开房间的时候更新
/// Author:IfYan
/// Latest Update Time:2017.5.14
/// </summary>
/// 
public class ProfileManager : ExUnitySingleton<ProfileManager>
{
    #region Variable
    //存档数据
    ProfileData data;
    //暂存房间元素数据
    List<int> tempREID = new List<int>();
    List<int> tempREState = new List<int>();
    List<float> tempREPosX = new List<float>();
    List<float> tempREPosY = new List<float>();
    List<float> tempREPosZ = new List<float>();
    List<int> tempRERoomX = new List<int>();
    List<int> tempRERoomY = new List<int>();

    #endregion

    #region Data Methods
    /// <summary>
    /// 存档数据
    /// </summary>
    public ProfileData Data
    {
        get { return data; }
        set { data = value; }
    }
    /// <summary>
    /// 初始化数据
    /// </summary>
    void InitData()
    {
        data = new ProfileData();
        data.Init();
		//return;
        for (int i = 0; i < data.RoomElementID.Length; i++)
        {
            tempREID.Add(data.RoomElementID[i]);
            tempREState.Add(data.RoomElementState[i]);
            tempREPosX.Add(data.RoomElementPosX[i]);
            tempREPosY.Add(data.RoomElementPosY[i]);
            tempREPosZ.Add(data.RoomElementPosZ[i]);
            tempRERoomX.Add(data.RoomElementRoomX[i]);
            tempRERoomY.Add(data.RoomElementRoomY[i]);
        }

    }
    /// <summary>
    /// 存档
    /// </summary>
    void SaveData()
    {
        //Player
        data.Hp = Player.Instance.Character.Hp;
        data.Atk = Player.Instance.Character.Atk;
        data.Spd = Player.Instance.Character.Spd;
        data.Rng = Player.Instance.Character.Rng;
        data.Mov = Player.Instance.Character.Mov;
        data.Fhr = Player.Instance.Character.Fhr;
        data.Luk = Player.Instance.Character.Luk;
        data.Sight = Player.Instance.Character.Sight;

        data.BuffsID = Player.Instance.GetComponent<BuffManager>().SavingBuff();
        data.CurPosition = Player.Instance.Character.transform.position;


        //Room Data
        List<int> tempRoomID = new List<int>();
        List<int> tempRoomPass = new List<int>();
        List<int> tempRoomSize = new List<int>();
        for (int i = 0; i < CheckpointManager.Instance.rows; i++)
            for (int j = 0; j < CheckpointManager.Instance.columns; j++)
            {
                if (CheckpointManager.Instance.roomArray[i, j] == 1)
                {
                    tempRoomID.Add(1);
                    tempRoomPass.Add(CheckpointManager.Instance.GetNextRoom(i, j).pass);
                    tempRoomSize.Add(CheckpointManager.Instance.GetNextRoom(i, j).RoomSize);
                }
                else
                {
                    tempRoomID.Add(0);
                    tempRoomPass.Add(0);
                    tempRoomSize.Add(0);
                }

            }

        data.Map = tempRoomID.ToArray();
        data.IsRoomPassed = tempRoomPass.ToArray();
        data.RoomSize = tempRoomSize.ToArray();
        data.CurLevel = CheckpointManager.Instance.CheckpointNumber;
        data.CurRoomX = RoomManager.Instance.roomX;
        data.CurRoomY = RoomManager.Instance.roomY;

        //RoomElements Data

        //移除重复元素
        //注意要从后往前删,否则序号会出问题
        for (int i = tempRERoomX.Count - 1; i >= 0; i--)
        {
            if (RoomManager.Instance.roomX == tempRERoomX[i] && RoomManager.Instance.roomY == tempRERoomY[i])
            {
                //Debug.Log("删除:" + tempREID[i]);
                tempREID.RemoveAt(i);
                tempREState.RemoveAt(i);
                tempREPosX.RemoveAt(i);
                tempREPosY.RemoveAt(i);
                tempREPosZ.RemoveAt(i);
                tempRERoomX.RemoveAt(i);
                tempRERoomY.RemoveAt(i);
            }
        }

        //Debug.Log("Pro:"+RoomElementManager.Instance.RoomElementList.Count);

        //加载元素
        for (int i = 0; i < RoomElementManager.Instance.RoomElementList.Count; i++)
        {
            //Debug.Log("加载:"+RoomElementManager.Instance.RoomElementList[i].RoomElementID);
            tempREID.Add(RoomElementManager.Instance.RoomElementList[i].RoomElementID);
            tempREState.Add(RoomElementManager.Instance.RoomElementList[i].RoomElementState);
            tempREPosX.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.x);
            tempREPosY.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.y);
            tempREPosZ.Add(RoomElementManager.Instance.RoomElementList[i].transform.position.z);
            tempRERoomX.Add(RoomManager.Instance.roomX);
            tempRERoomY.Add(RoomManager.Instance.roomY);
        }
        //Debug.Log ("房间号：" + RoomManager.Instance.roomX + "," + RoomManager.Instance.roomY);
        data.RoomElementID = tempREID.ToArray();
        data.RoomElementState = tempREState.ToArray();
        data.RoomElementPosX = tempREPosX.ToArray();
        data.RoomElementPosY = tempREPosY.ToArray();
        data.RoomElementPosZ = tempREPosZ.ToArray();
        data.RoomElementRoomX = tempRERoomX.ToArray();
        data.RoomElementRoomY = tempRERoomY.ToArray();

    }
    #endregion

    #region Other Methods
    void Awake()
    {
        InitData();

    }
    void Start()
    {
        RoomManager.Instance.AddObserver(this);
        EnemyManager.Instance.AddObserver(this);
    }
    public override void OnNotify(string msg)
    {
        //Debug.Log("OnNotify the msg : " + msg);
        if (msg == null)
        {
            Debug.LogError("ProfileManager:The msg cannot be null!");
        }
        string[] str = UtilManager.Instance.GetMsgFields(msg);

        if (str[0] == "SetupCheckpoint")
        {
            //清空所有
            tempREID.Clear();
            tempREPosX.Clear();
            tempREPosY.Clear();
            tempREPosZ.Clear();
            tempRERoomX.Clear();
            tempRERoomY.Clear();
        }


        //TODO leaveRoom存档
        if (str[0] == "ClearRoom" || (str[0] == "EnterRoom") || str[0] == "LeaveRoom")
        {
            //Debug.Log("PofileManager recieved the msg : " + msg);
            SaveData();
        }

    }
    #endregion
}

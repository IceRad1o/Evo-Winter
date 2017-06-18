using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
public enum Direction
{
    Front,
    Back,
    Left,
    Right,
    Top,
    Bottom
}
//房间类型枚举,房间类型号，-2BOSS，-1起始，0无，1宝箱，2商店，3祭坛，4隐藏房间
public enum RmType { Hidden = -3, Boss, Start, Non, Box, Shop, Altar, Normal,Story,Test1,Test2,HardLevel,Organ};
[Serializable]
//单个房间信息
public class RoomInfo
{
    //房间类型号
    public RmType type = 0;
    //是否进入过该房间，0否，1是
    public int pass = 0;
    //房间位置x,y
    public int roomX;
    public int roomY;
    //门位置
    public int[] doorDirection = new int[4];
    //
    public int count;
    //即将废弃,房间大小，1小，2中，3大
    public int roomSize = 3;
    //可控的房间大小,x长,y宽,z高
    public Vector2 size;
    //房间内元素的信息
    public List<RoomElementInfo> roomElementInfoList=new List<RoomElementInfo>();

    //构造函数
    public RoomInfo(RmType type, int x, int y, int[] doorDir, int pass, int size,int roomCount)
    {
        this.pass = pass;
        this.type = type;
        roomX = x;
        roomY = y;
        roomSize = size;
        count = roomCount;
        for (int i = 0; i < 4; i++)
            doorDirection[i] = doorDir[i];
    }

}

/// <summary>
/// 负责管理房间的布局、生成与销毁
/// Layout       布局 仅将房间元素信息写入roomInfo中,不生成
/// Instantiate  生成
/// </summary>
public class RoomManager : ExUnitySingleton<RoomManager>
{
    #region Variables
    public RoomInfo roomInfo;
    
    public Transform room;
    public Transform wall;
    public Transform blocks;
    public Transform ground;
    public Transform[] blockWalls = new Transform[6];

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    //音乐
    public AudioClip[] BackgroundMusic;


    //最大最小敌人数量
    public int maxEnemyNumber = 5;
    public int minEnemyNumber = 2;


    //宝箱房间号//房间类型号，-2BOSS，-1起始，0无，1宝箱，2商店，3祭坛，4隐藏房间
    private int boxTypeRoom = 1;


    public int[] DoorDirection
    {
        get
        {
            return roomInfo.doorDirection;
        }
    }
    //房间大小，1小，2中，3大
    public int RoomSize
    {
        get
        {
            return roomInfo.roomSize;
        }


    }
    //房间类型
    public int RoomType
    {
        get
        {
            return (int)roomInfo.type;
        }

  
    }

    public int RoomX
    {
        get
        {
            return roomInfo.roomX;
        }

   
    }

    public int RoomY
    {
        get
        {
            return roomInfo.roomY;
        }


    }


    public List<RoomElementInfo> REList
    {
        get
        {
            return roomInfo.roomElementInfoList;
        }


    }

    //行列
    private int rows = 3;
    private int columns = 12;
    //墙上物件随机个数，地上物件随机个数
    private Count wallElementsCount = new Count(2, 6);
    private Count groundElementsCount = new Count(2, 6);

    #region Elements
    //墙上物件，地上物件
    //public GameObject[] wallElements;
    //public GameObject[] groundElements;
    //public GameObject[] doors;
    //public GameObject[] stair;
    //public GameObject[] handle;
    ////宁静类物品
    //public GameObject[] peace;
    ////恐怖类物品
    //public GameObject[] terror;
    ////功能类物品
    //public GameObject[] function;
    ////祭坛房间
    //public GameObject[] altar;
    ////商店
    //public GameObject[] shop;
    ////牌子
    //public GameObject[] plate;
    ////小怪
    //public GameObject[] enemys;
    ////Boss
    //public GameObject[] boss;
    ////金币
    //public GameObject[] coin;


    #endregion
    #region Positions
    //隐藏房间的门
    public bool hiddenDoor = false;


    //墙的位置
    static Vector3[] bigWall = new Vector3[] { new Vector3(20f, 0, 0), new Vector3(-20f, 0f, 0) };
    static Vector3[] midWall = new Vector3[] { new Vector3(15.8f, 0, 0), new Vector3(-15.8f, 0f, 0) };
    static Vector3[] smlWall = new Vector3[] { new Vector3(13f, 0, 0), new Vector3(-13f, 0f, 0) };


    //private Vector3[] doorPos ={ new Vector3(0f, 1.4f * 2f, 0f), new Vector3(0f, -4.7f * 2f, 0f), new Vector3(-12.8f, -1.46f * 2f, 0f), new Vector3(12.8f, -1.46f * 2f, 0f) };
    private Vector3[] doorPos = { new Vector3(0f, 1.4f * 2f, 0f), new Vector3(0f, -4.7f * 2f, 0f), new Vector3(-5.8f, -1.46f * 2f, 0f), new Vector3(5.8f, -1.46f * 2f, 0f) };

    //大房间的门
    private Vector3 door0 = new Vector3(0f, 1.4f * 2f, 0f);
    private Vector3 door1 = new Vector3(0f, -4.7f * 2f, 0f);
    private Vector3 door2 = new Vector3(-12.8f, -1.46f * 2f, 0f);
    private Vector3 door3 = new Vector3(12.8f, -1.46f * 2f, 0f);
    //中房间的左右门
    private Vector3 door22 = new Vector3(-8.8f, -1.46f * 2f, 0f);
    private Vector3 door32 = new Vector3(8.8f, -1.46f * 2f, 0f);
    //小房间的左右门
    private Vector3 door23 = new Vector3(-5.8f, -1.46f * 2f, 0f);
    private Vector3 door33 = new Vector3(5.8f, -1.46f * 2f, 0f);
    //单个物件长度
    private int objLen = 10;
    //宝箱位置
    private int boxPos = 0;

    private Transform boardHolder;
    //列表ID:0 镜子
    private List<Vector3> mirrorPosition = new List<Vector3>();
    //列表ID:1 图片
    private List<Vector3> picturePosition = new List<Vector3>();
    //列表ID:2 门
    private List<Vector3> doorPosition = new List<Vector3>();
    //列表ID:3 地上物品
    private List<Vector3> groundPosition = new List<Vector3>();
    //列表ID:4 雕像
    private List<Vector3> statuePosition = new List<Vector3>();
    //列表ID:5 爪子
    private List<Vector3> clawPosition = new List<Vector3>();
    //列表ID:6 固定位置
    private List<Vector3> settledPosition = new List<Vector3>();

    #endregion

    #endregion

    void Start()
    {
        EnemyManager.Instance.AddObserver(this);
        //InitialiseList();
    }




    //墙上物体位置向量
    /* 门Y:1.4       X最小间距2
     * 雕像Y：1.54   X最小间距2
     * 镜子Y：1.88   X最小间距1
     * 图片Y：2.09   X最小间距1
     * */

    //初始化列表
    void InitPositionList()
    {
        //镜子位置列表
        mirrorPosition.Clear();
        for (float x = -1 * columns; x < columns; x += 2f)
        {

            if (x != 0) mirrorPosition.Add(new Vector3(x, 1.8f * 2f, 0f));
        }
        //图片位置列表
        picturePosition.Clear();
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            if (x != 0) picturePosition.Add(new Vector3(x, 2.0f * 2f, 0f));
        }
        //门位置列表
        doorPosition.Clear();

        if (DoorDirection[0] == 1)
        {
            doorPosition.Add(door0);
        }
        if (DoorDirection[1] == 1)
        {
            doorPosition.Add(door1);
        }
        if (DoorDirection[2] == 1)
        {
            if (RoomSize == 1) doorPosition.Add(door23);
            else if (RoomSize == 2) doorPosition.Add(door22);
            else doorPosition.Add(door2);
        }
        if (DoorDirection[3] == 1)
        {
            if (RoomSize == 1) doorPosition.Add(door33);
            else if (RoomSize == 2) doorPosition.Add(door32);
            else doorPosition.Add(door3);
        }

        //doorPosition.Add(new Vector3(x, 1.4f, 0f));

        //雕像位置列表
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            if (x != 0) statuePosition.Add(new Vector3(x, 1.54f * 2f, 0f));
        }

        //爪子位置列表
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            if (x != 0) clawPosition.Add(new Vector3(x, 0.79f * 2f, 0f));
        }

        //地上物体列表
        groundPosition.Clear();
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            for (float y = -1 * rows; y < 0; y += 2f)
            {
                groundPosition.Add(new Vector3(x, y, 0f));
            }
        }

        //固定位置列表
        settledPosition.Clear();
        switch (RoomSize)
        {
            case 1://小房间
                settledPosition.Add(new Vector3(-3.5f, -0.5f, 0f));
                settledPosition.Add(new Vector3(-3.5f, -6.0f, 0f));
                settledPosition.Add(new Vector3(-2.5f, -2.5f, 0f));
                settledPosition.Add(new Vector3(2.5f, -6.5f, 0f));
                settledPosition.Add(new Vector3(3.5f, -2.0f, 0f));
                settledPosition.Add(new Vector3(4.5f, -5.5f, 0f));
                break;
            case 2://中房间
                settledPosition.Add(new Vector3(-6f, -1.5f, 0f));
                settledPosition.Add(new Vector3(-3.5f, -0.5f, 0f));
                settledPosition.Add(new Vector3(-3.5f, -6.0f, 0f));
                settledPosition.Add(new Vector3(-2.5f, -2.5f, 0f));
                settledPosition.Add(new Vector3(2.5f, -6.5f, 0f));
                settledPosition.Add(new Vector3(3.5f, -2.0f, 0f));
                settledPosition.Add(new Vector3(4.5f, -5.5f, 0f));
                settledPosition.Add(new Vector3(6f, -3.5f, 0f));
                break;
            case 3://大房间
                settledPosition.Add(new Vector3(-12f, -0.5f, 0f));
                settledPosition.Add(new Vector3(-11f, -6.0f, 0f));
                settledPosition.Add(new Vector3(-9f, -3f, 0f));
                settledPosition.Add(new Vector3(-6f, -1.5f, 0f));
                settledPosition.Add(new Vector3(-3.5f, -0.5f, 0f));
                settledPosition.Add(new Vector3(-3.5f, -6.0f, 0f));
                settledPosition.Add(new Vector3(-2.5f, -2.5f, 0f));
                settledPosition.Add(new Vector3(2.5f, -6.5f, 0f));
                settledPosition.Add(new Vector3(3.5f, -2.0f, 0f));
                settledPosition.Add(new Vector3(4.5f, -5.5f, 0f));
                settledPosition.Add(new Vector3(6f, -3.5f, 0f));
                settledPosition.Add(new Vector3(9f, -0.5f, 0f));
                settledPosition.Add(new Vector3(9f, -6.5f, 0f));
                settledPosition.Add(new Vector3(12f, -6.0f, 0f));
                break;
        }


    }
    //随机位置
    Vector3 RandomPosition(int wallElementID)
    {
        int randomIndex;
        Vector3 randomPosition = new Vector3(0f, 0f, 0f);
        switch (wallElementID)
        {
            //镜子位置
            case 0:
                randomIndex = Random.Range(0, mirrorPosition.Count);
                randomPosition = mirrorPosition[randomIndex];
                RemoveWallPosition(randomIndex);
                break;
            //图片位置
            case 1:
                randomIndex = Random.Range(0, picturePosition.Count);
                randomPosition = picturePosition[randomIndex];
                RemoveWallPosition(randomIndex);
                break;
            //雕像位置
            case 2:
                randomIndex = Random.Range(0, statuePosition.Count);
                randomPosition = statuePosition[randomIndex];
                RemoveWallPosition(randomIndex);
                break;
            //地上物体位置
            case 3:
                //randomIndex = Random.Range(0, groundPosition.Count);
                //randomPosition = groundPosition[randomIndex];
                //groundPosition.RemoveAt(randomIndex);
                randomIndex = Random.Range(0, settledPosition.Count);
                randomPosition = settledPosition[randomIndex];
                settledPosition.RemoveAt(randomIndex);
                break;
            //爪子位置
            case 4:
                randomIndex = Random.Range(0, clawPosition.Count);
                randomPosition = clawPosition[randomIndex];
                RemoveWallPosition(randomIndex);
                break;

        }
        return randomPosition;
    }
    //移除墙上物体占用位置
    void RemoveWallPosition(int randomIndex)
    {
        return;
        mirrorPosition.RemoveAt(randomIndex);
        picturePosition.RemoveAt(randomIndex);
        //doorPosition.RemoveAt(randomIndex);
        statuePosition.RemoveAt(randomIndex);
        clawPosition.RemoveAt(randomIndex);
    }
    //将墙调整到与房间大小相适应
    public void AdjustWallPostion()
    {
        Vector3[] wal = bigWall;
        switch (roomInfo.roomSize)
        {
            case 1:
                wal = smlWall;
                break;
            case 2:
                wal = midWall;
                break;
            case 3:
                wal = bigWall;
                break;
        }
        blockWalls[(int)Direction.Left].transform.position = wal[1];
        blockWalls[(int)Direction.Right].transform.position = wal[0];
    }
    //随机布局墙上物体
    void LayoutWallAtRandom(RoomElement[] objectArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);
        Vector3 randomPosition = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < objectCount; i++)
        {

            REID ElementID = objectArray[Random.Range(0, objectArray.Length)].RoomElementID;
            if(ElementID==REID.DoorBack|| ElementID == REID.DoorFront || ElementID == REID.DoorLeft || ElementID == REID.DoorRight )
            {
                i--;
                continue;
            }
            //放置镜子
            if (ElementID == REID.Mirror) randomPosition = RandomPosition(0);
            //放置图片
            if (ElementID == REID.Picture1|| ElementID == REID.Picture2) randomPosition = RandomPosition(1);
            //放置雕像
            if (ElementID == REID.Statue)
            {
                randomPosition = RandomPosition(2);
            }
            //放置爪子
            if (ElementID == REID.Claw)
            {
                randomPosition = RandomPosition(4);
            }
           
            roomInfo.roomElementInfoList.Add(new RoomElementInfo(ElementID, randomPosition));

            //GameObject objectChoice = objectArray[wallElementsID].gameObject;
            //GameObject roomElement = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            //roomElement.transform.SetParent(wall.transform);
            //房间物件存入列表

            // RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());

        }
    }
    //随机布局地上物体
    void LayoutGroundAtRandom(RoomElement[] objectArray, int minimum, int maximum)
    {
        //数量
        int objectCount = Random.Range(minimum, maximum);

        for (int i = 0; i < objectCount; i++)
        {
            if (RoomSize < 3)
                objectCount--;
            REID ChoiceID=0;
            bool isCombination = false;
            Vector3 randomPosition = RandomPosition(3);
       
            //房间类型号，-2BOSS，-1起始，0无，1宝箱，2商店，3祭坛，4隐藏房间
            //宝箱房
            if (RoomType == (int)RmType.Box)
            {
                objectCount--;
                ChoiceID = REID.Box;
            }
            //商店
            else if (RoomType == (int)RmType.Shop)
            {
                // 地摊摊主
                objectCount = -1;
                randomPosition = new Vector3(0, -2f, -2f);
                ChoiceID = REID.Shop;
            }
            //祭坛
            else if (RoomType == (int)RmType.Altar)
            {
                //主祭坛
                objectCount = -1;
                randomPosition = new Vector3(0, -2f, -2f);
                ChoiceID = (REID)Random.Range((int)REID.Altar1,(int)REID.Altar2+1); ;
            }
            //其他
            else
            {
                isCombination = true;
                var arr = CombinationTable.Instance.combinations;
                arr[Random.Range(0, arr.Length - 1)].GetComponent<RECombination>().AddRECombinationInfoToList(roomInfo.roomElementInfoList);
                //随机生成机关开关
               // LayoutHandle();
            }
            //else
           //     ChoiceID = objectArray[Random.Range(0, objectArray.Length - 1)].RoomElementID;

            if (ChoiceID == REID.DoorBack || ChoiceID == REID.DoorFront || ChoiceID == REID.DoorLeft || ChoiceID == REID.DoorRight)
            {
                i--;
                continue;
            }
            if(!isCombination)
                roomInfo.roomElementInfoList.Add(new RoomElementInfo(ChoiceID, randomPosition));
         

            //GameObject roomElement = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            //roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);

        }
    }
    //随机布局小怪
    void LayoutEnemyAtRandom(GameObject[] objectArray, int minimum, int maximum)
    {
       
        int objectCount = Random.Range(minimum, maximum);
        int randomIndex = Random.Range(0, groundPosition.Count);
        for (int i = 0; i < objectCount; i++)
        {
            GameObject objectChoice;
            Vector3 randomPosition = groundPosition[randomIndex];
            //groundPosition.RemoveAt(randomIndex);
            if (RoomType == (int)RmType.Normal || RoomType == (int)RmType.Boss)
            {
                objectChoice = objectArray[Random.Range(0, objectArray.Length)];
                //遗传算法
                Genetic(objectChoice);

                //GameObject enemy = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
                //enemy.transform.SetParent(GameObject.Find("GroundElements").transform);
                //小怪存入列表
                //EnemyManager.Instance.EnemyList.Add(enemy.GetComponent<Character>());

                if (randomIndex < groundPosition.Count - 1 && groundPosition[randomIndex] != null) randomIndex++;
                else if (randomIndex > 0 && groundPosition[0] != null) randomIndex--;
            }

        }
    }
    //设置门的位置
    public void SetDoorDierction(int[] doorDir)
    {
        for (int i = 0; i < 4; i++)
        {
            DoorDirection[i] = doorDir[i];
        }
    }

    void LayoutDoor()
    {
        int ChoiceID=0;
        for (int i = 0; i < 4; i++)
        {

            if (DoorDirection[i] > 0)
            {
                ChoiceID = (int)REID.DoorFront + i;
                roomInfo.roomElementInfoList.Add(new RoomElementInfo((REID)ChoiceID,doorPos[i]));
            }
     
        }
       
    }

    ////布局门
    //void LayoutDoor()
    //{
    //    int j = 0;

    //    //Debug.Log("roomX:" + doors[0]);
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (DoorDirection[i] > 0)
    //        {
    //            GameObject objectChoice;
    //            //下门
    //            if (i == 1)
    //            {

    //                //非正常门
    //                if (CheckpointManager.Instance.GetRoomInfo(RoomX + 1, RoomY) != null)
    //                {
    //                    //BOSS门
    //                    if (CheckpointManager.Instance.GetRoomInfo(RoomX + 1, RoomY).type == RmType.Boss)
    //                        objectChoice = doors[5];
    //                    //隐藏门
    //                    else if (CheckpointManager.Instance.GetRoomInfo(RoomX + 1, RoomY).type == RmType.Hidden)
    //                    {
    //                        if (hiddenDoor)
    //                            objectChoice = doors[0];
    //                        else objectChoice = null;
    //                    }
    //                    //正常门
    //                    else
    //                        objectChoice = doors[0];
    //                }

    //                //正常门
    //                else
    //                {
    //                    objectChoice = doors[0];
    //                }

    //            }
    //            //上门
    //            else if (i == 0)
    //            {
    //                //非正常门
    //                if (CheckpointManager.Instance.GetRoomInfo(RoomX - 1, RoomY) != null)
    //                {
    //                    //BOSS门
    //                    if (CheckpointManager.Instance.GetRoomInfo(RoomX - 1, RoomY).type == RmType.Boss)
    //                        objectChoice = doors[4];
    //                    //隐藏门
    //                    else if (CheckpointManager.Instance.GetRoomInfo(RoomX - 1, RoomY).type == RmType.Hidden)
    //                    {
    //                        if (hiddenDoor)
    //                            objectChoice = doors[1];
    //                        else objectChoice = null;
    //                    }
    //                    //正常门
    //                    else
    //                        objectChoice = doors[1];
    //                }

    //                //正常门
    //                else
    //                    objectChoice = doors[1];
    //            }

    //            //左右BOSS门
    //            else if ((i == 2 && CheckpointManager.Instance.GetRoomInfo(RoomX, RoomY - 1).type == RmType.Boss)
    //                     || (i == 3 && CheckpointManager.Instance.GetRoomInfo(RoomX, RoomY + 1).type == RmType.Boss))
    //                objectChoice = doors[2];
    //            //左隐藏门
    //            else if (i == 2 && CheckpointManager.Instance.GetRoomInfo(RoomX, RoomY - 1).type == RmType.Hidden)
    //            {
    //                if (hiddenDoor) objectChoice = doors[3];
    //                else objectChoice = null;
    //            }
    //            //右正常门
    //            else objectChoice = doors[3];
    //            //生成

    //            if (objectChoice != null)
    //            {
    //                GameObject roomElement = Instantiate(objectChoice, doorPosition[j], Quaternion.identity) as GameObject;

    //                roomElement.GetComponent<Door>().SetPosition(i);
    //                roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //            }
    //            j++;
    //        }
    //    }
    //}


    //设置房间位置
    //void SetRoomXY(int x, int y, int tp)
    //{
    //    RoomX = x;
    //    RoomY = y;
    //    RoomType = tp;
    //}

    //特定生成函数中门位置
    void InitDoorList()
    {
        doorPosition.Clear();

        if (DoorDirection[0] == 1)
        {
            doorPosition.Add(door0);
        }
        if (DoorDirection[1] == 1)
        {
            doorPosition.Add(door1);
        }
        if (DoorDirection[2] == 1)
        {
            if (RoomSize == 1)
                doorPosition.Add(door23);
            else if (RoomSize == 2)
                doorPosition.Add(door22);
            else
                doorPosition.Add(door2);
        }
        if (DoorDirection[3] == 1)
        {
            if (RoomSize == 1)
                doorPosition.Add(door33);
            else if (RoomSize == 2)
                doorPosition.Add(door32);
            else
                doorPosition.Add(door3);
        }
    }

    //在最后一个房间生成楼梯
    void LayoutStair()
    {
        Vector3 position;
        if (RoomSize == 1)
            position = new Vector3(4.5f, -0.8f, 0f);
        else if (RoomSize == 2)
            position = new Vector3(7.5f, -0.8f, 0f);
        else
            position = new Vector3(11.5f, -0.8f, 0f);
        roomInfo.roomElementInfoList.Add(new RoomElementInfo(REID.Stair, position));
        //GameObject objectChoice = stair[0];
        //GameObject roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
        //roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);

    }

    //随机生成机关开关
    void LayoutHandle()
    {
        if (Random.Range(0, 10) > 0 &&
            (RoomX != CheckpointManager.Instance.hiddenRoomX || RoomY != CheckpointManager.Instance.hiddenRoomY + 1))
        {
            Vector3 handlePosition = RandomPosition(3);
            roomInfo.roomElementInfoList.Add(new RoomElementInfo(REID.Handle, handlePosition));
            //GameObject myHandle = Instantiate(handle[0], handlePosition, Quaternion.identity) as GameObject;
            //myHandle.transform.SetParent(GameObject.Find("GroundElements").transform);
        }
    }

    //在指定位置布局一个结合体
    public void LayoutCombination(int combinationID,Vector3 position)
    {
        CombinationTable.dict[combinationID].transform.position = position;
        CombinationTable.dict[combinationID].AddRECombinationInfoToList(roomInfo.roomElementInfoList);
    }
    //在指定位置布局一个房间元素
    public void LayoutRoomElement(REID id, Vector3 position)
    {
       var info= RETable.REDict[id].GetInfo();
        info.Position = position;
        roomInfo.roomElementInfoList.Add(info);
    }
    //清空
    public void ClearAll()
    {
        //清除位置
        mirrorPosition.Clear();
        picturePosition.Clear();
        doorPosition.Clear();
        groundPosition.Clear();
        statuePosition.Clear();
        clawPosition.Clear();
        //清除物件
        RoomElementManager.Instance.ClearAll();
        //清除敌人
        // EnemyManager.Instance.ClearAll();

    }

    public void SetupPresetRoom(RoomInfo roomdata,int presetID)
    {
        roomInfo = roomdata;
        InitPositionList();
        CombinationTable.mapDict[presetID].AddRECombinationInfoToList(roomdata.roomElementInfoList);
        LayoutDoor();
    }

    public void UpdateREList()
    {
        roomInfo.roomElementInfoList.Clear();
        var list = RoomElementManager.Instance.RoomElementList;
        for(int i=0;i<list.Count;i++)
        {
            roomInfo.roomElementInfoList.Add(list[i].GetInfo());
        }
    }

    public void SetupRoom(RoomInfo roomdata)
    {
       
        roomInfo = roomdata;
        InitPositionList();
        //LayoutWall();
        //LayoutEnemyAtRandom(enemys, minEnemyNumber, maxEnemyNumber);
        //Debug.Log("aa:" + RETable.DomainDict);
        LayoutWallAtRandom(RETable.DomainDict[RoomDomain.RoomWall], wallElementsCount.minimum, wallElementsCount.maximum);
        LayoutGroundAtRandom(RETable.DomainDict[RoomDomain.RoomGround], groundElementsCount.minimum, groundElementsCount.maximum);
        LayoutDoor();

        if (roomInfo.type == RmType.Boss)
        {
            LayoutStair();
            //布局BOSS，测试小怪
            //LayoutEnemyAtRandom(boss, 1, 1);
            //SoundManager.Instance.PlayBackGroundMusic(BackgroundMusic[1]);
        }
        else
            ;// SoundManager.Instance.PlayBackGroundMusic(BackgroundMusic[0]);

        //hiddenDoor = false;
        //Notify("EnterRoom;Unknow;" + (int)roomInfo.type);
    }

    //设置场景,类型号，门位置,房间x，房间y，房间大小r
    public void SetupRoom(RmType tp, int[] dp, int x, int y, int r)
    {
        //SetupRoom(new RoomInfo(tp, x, y, dp, 0, r));
    }

    //小怪数目为0,生成一个宝箱
    public override void OnNotify(string msg)
    {
        string content = UtilManager.Instance.GetMsgField(msg, 0);
        //string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (content == "ClearRoom")
        {
            //Debug.Log("CLEAR ROOM CLEAR ROOM");
            Vector3 randomPosition = RandomPosition(3);
            GameObject objectChoice = RETable.REDict[REID.Box].gameObject;
            GameObject roomElement = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            //roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
        }
    }

    //遗传算法
    void Genetic(GameObject objectChoice)
    {

    }


    public void LoadRoom(RoomInfo Info)
    {
       
        ClearAll();
        roomInfo = Info;
        InitDoorList();
        AdjustWallPostion();
        //LayoutDoor();
        //来过即可见
        Info.pass = 1;
       
        for (int i = 0; i < REList.Count; i++)
        {
            REID id = REList[i].ID;
            RoomElement ins=null;
            if(id==REID.Unknown)
            {
                
            }
            else if ((int)id >= 1000 && id < REID.ItemEnd)
            {//金币报错
                ins=ItemManager.Instance.CreateItemID((int)id, REList[i].Position);
            }
            else if (id >= REID.Character&& id < REID.CharacterEnd)
            {
                //生成Character
            }
            else
            {
                //Debug.Log("id:" + id);
                ins = Instantiate(RETable.REDict[id], REList[i].Position, RETable.REDict[id].transform.rotation) as RoomElement;
              
            }
            if (ins != null)
            {
                switch (ins.belongDomain)
                {
                    case RoomDomain.RoomGround:
                        ins.transform.SetParent(ground.transform);
                        break;
                    case RoomDomain.RoomWall:
                        ins.transform.SetParent(wall.transform);
                        break;
                    case RoomDomain.RoomBlocks:
                        ins.transform.SetParent(blocks.transform);
                        break;
                    case RoomDomain.UnLimited:
                        ins.transform.SetParent(room.transform);
                        break;
                    default:
                        break;
                }
                ins.RoomElementState = REList[i].State;
            }
    
        }

        Notify("EnterRoom;Know");
    }

    public void LoadRoom(Vector2 vec2)
    {
        LoadRoom((int)vec2.x,(int)vec2.y);
    }
    public void LoadRoom(int x, int y)
    {
       
        LoadRoom(CheckpointManager.Instance.GetRoomInfo(x, y));

    }


    public void LeaveRoom(int dir)
    {
        UpdateREList();
        Notify("LeaveRoom;"+dir);
    }

    public void ClearRoom()
    {
        UpdateREList();
        Notify("ClearRoom");
    }

    //加载确定场景 类型号tp,房间号xy,门位置 int数组roomX[],roomY[],id[],posiX[],posiY[],posiZ[],房间大小roomS
    //public void LoadScene(RoomInfo Info, int[] roomX, int[] roomY, int[] id, float[] posiX, float[] posiY, float[] posiZ, int roomS)
    //{
    //    //Debug.Log("LoadScene进入" + x + ";" + y);
    //    ClearAll();
    //    roomInfo = CheckpointManager.Instance.GetRoom(x, y);
    //    //SetDoorDierction(dp);
    //    InitDoorList(x, y);
    //    //SetRoomXY(x, y, tp);
    //    LayoutWall();
    //    LayoutDoor();
     
    //    if (roomInfo.type== RmType.Boss)
    //    {
    //        LayoutStair();
    //    }
    //    //RoomSize = roomS;

    //    int count = 0;
    //    for (int i = 0; i < roomX.Length; i++)
    //    {

    //        {
    //            if (roomY[i] == y && roomX[i] == x)
    //            {
    //                //Debug.Log("选中物体:"+id[count]);
    //                count = i;
    //                Vector3 position = new Vector3(posiX[count], posiY[count], posiZ[count]);
    //                GameObject objectChoice;
    //                GameObject roomElement = null;

    //                int roomElementState = ProfileManager.Instance.Data.RoomElementState[count];
    //                //if(roomElementState>0)Debug.Log ("状态位:"+roomElementState);

    //                if (id[count] >= 1000 && id[count] < 2000)
    //                {
    //                    //ItemManager.Instance.ItemsTransform = this.transform;
    //                    //ItemManager.Instance.ItemsTransform.position = position;
    //                    //ItemManager.Instance.CreateItemID(id[count]);
    //                    ItemManager.Instance.CreateItemID(id[count], position);
    //                    //Debug.Log ("Create item ID:   " + id [count]);
    //                }
    //                else if (id[count] >= 2100 && id[count] < 3000)
    //                {
    //                    //Debug.Log ("生成小怪:" + count);
    //                    objectChoice = enemys[Random.Range(0, enemys.Length)];
    //                    roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                    roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                }
    //                else
    //                    switch (id[count])
    //                    {
    //                        case 0:
    //                            //Missile
    //                            break;
    //                        case (int)RoomElement.REID.Box:
    //                            //Debug.Log("选中箱子");
    //                            objectChoice = groundElements[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.GetComponent<Box>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Mirror:
    //                            //Debug.Log("选中镜子");
    //                            objectChoice = wallElements[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            roomElement.GetComponent<Mirror>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Door:
    //                            //objectChoice = doors[1];
    //                            //roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            //roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            break;
    //                        case (int)RoomElement.REID.Statue:
    //                            //Debug.Log("选中雕塑");
    //                            objectChoice = wallElements[1];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            roomElement.GetComponent<Statue>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Claw:
    //                            //Debug.Log("选中爪子");
    //                            objectChoice = wallElements[2];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            roomElement.GetComponent<Claw>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Picture1:
    //                            //Debug.Log("选中图一");
    //                            objectChoice = wallElements[3];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            Debug.Log("选中图1，Y：" + position.y);
    //                            //roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Picture1>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Picture2:
    //                            //Debug.Log("选中图二");
    //                            objectChoice = wallElements[4];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
    //                            roomElement.GetComponent<Picture2>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Skull:
    //                            //Debug.Log("选中骷髅");
    //                            objectChoice = groundElements[1];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Skull>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.SkullLight:
    //                            //Debug.Log("选中骷髅灯");
    //                            objectChoice = groundElements[2];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<SkullLight>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Bottle1:
    //                            //Debug.Log("选中瓶子一");
    //                            objectChoice = groundElements[5];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Bottle1>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Bottle2:
    //                            //Debug.Log("选中瓶子二");
    //                            objectChoice = groundElements[6];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            //roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Bottle2>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Gone:
    //                            //Debug.Log("骨头");
    //                            objectChoice = groundElements[4];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Bone>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Rod:
    //                            //Debug.Log("选中杆子");
    //                            objectChoice = groundElements[7];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Rod>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Stone:
    //                            //Debug.Log("选中石头");
    //                            objectChoice = groundElements[8];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Stone>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Trap:
    //                            //Debug.Log("选中陷阱");
    //                            objectChoice = groundElements[9];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Trap>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Stair:
    //                            //Debug.Log("选中楼梯");
    //                            objectChoice = stair[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Stair>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Altar1:
    //                            //Debug.Log("选中祭坛1");
    //                            objectChoice = altar[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Altar>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Altar2:
    //                            //Debug.Log("选中祭坛2");
    //                            objectChoice = altar[1];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Altar>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Shop:
    //                            //Debug.Log("选中商店");
    //                            objectChoice = shop[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Shop>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Plate:
    //                            //Debug.Log("选中牌子");
    //                            objectChoice = plate[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Plate>().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Coin:
    //                            //Debug.Log("选中金币");
    //                            objectChoice = coin[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            ///roomElement.GetComponent<Coin> ().RoomElementState = roomElementState;
    //                            break;
    //                        case (int)RoomElement.REID.Handle:
    //                            //Debug.Log("选中机关开关");
    //                            objectChoice = handle[0];
    //                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
    //                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
    //                            roomElement.transform.localPosition = position;
    //                            roomElement.GetComponent<Handle>().RoomElementState = roomElementState;
    //                            break;

    //                    }

    //            }
    //        }
    //    }
    //    //Notify("EnterRoom;Know");
    //}





    public void DropBox(Vector3 position, int minNum = 1, int maxNum = 2)
    {

        Vector3 startPoint = position + new Vector3(0, 1, 0);
        int num = Random.Range(minNum, maxNum);
        for (int i = 0; i < num; i++)
        {
            Vector3 deltaPos = new Vector3((Random.value - 0.5f) * 5, (Random.value - 0.5f) * 5);
            GameObject ins = Instantiate(RETable.REDict[REID.Box], startPoint, Quaternion.identity) as GameObject;
            Vector3[] paths = new Vector3[3];
            paths[0] = startPoint;
            paths[1] = startPoint + deltaPos / 3 + new Vector3(0, 1.5f, 0);
            paths[2] = startPoint + deltaPos;
            iTween.MoveTo(ins, iTween.Hash("path", paths, "speed", 20f, "easeType", iTween.EaseType.linear));
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class RoomManager : ExUnitySingleton<RoomManager>
{
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


    //行列
    private int rows = 3;
    private int columns = 6;
    //墙上物件随机个数，地上物件随机个数
    private Count wallElementsCount = new Count(2, 6);
    private Count groundElementsCount = new Count(2, 6);
    //墙上物件，地上物件
    public GameObject[] wallElements;
    public GameObject[] groundElements;
    public GameObject[] doors;
    //小怪
    public GameObject[] enemys;
    //房间坐标位置
    public int roomX;
    public int roomY;
    //门的位置(参数传递设置)
    private int[] doorDirection = new int[4];
    public int[] DoorDirection
    {
        get { return doorDirection; }
        set { doorDirection = value; }
    }


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

    //墙上物体位置向量
    /* 门Y:1.4       X最小间距2
     * 雕像Y：1.54   X最小间距2
     * 镜子Y：1.88   X最小间距1
     * 图片Y：2.09   X最小间距1
     * */

    //初始化列表
    void InitialiseList()
    {
        //镜子位置列表
        mirrorPosition.Clear();
        for (float x = -1 * columns; x < columns; x+=2f)
        {
            mirrorPosition.Add(new Vector3(x, 1.8f, 0f));
        }
        //图片位置列表
        picturePosition.Clear();
        for (float x = -1 * columns; x < columns; x+=2f)
        {
            picturePosition.Add(new Vector3(x, 2.0f, 0f));
        }
        //门位置列表
        doorPosition.Clear();

        if (doorDirection[0] == 1)
        {
            doorPosition.Add(new Vector3(-4f, 1.4f, 0f));
        }
        if (doorDirection[1] == 1)
        {
            doorPosition.Add(new Vector3(-4f, -2f, 0f));
        }
        if (doorDirection[2] == 1)
        {
            doorPosition.Add(new Vector3(4f, 1.4f, 0f));
        }
        if (doorDirection[3] == 1)
        {
            doorPosition.Add(new Vector3(4f, -2f, 0f));
        }    

        //doorPosition.Add(new Vector3(x, 1.4f, 0f));
       
        //雕像位置列表
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            statuePosition.Add(new Vector3(x, 1.54f, 0f));
        }

        //爪子位置列表
        for (float x = -1 * columns; x < columns; x += 2f)
        {
            clawPosition.Add(new Vector3(x, 0.79f, 0f));
        }

        //地上物体列表
        groundPosition.Clear();
        for (int x = -1 * columns; x < columns; x++)
        {
            for (int y = -1 * rows; y < 0; y++)
            {
                groundPosition.Add(new Vector3(x, y, 0f));
            }
        }
    }



    //随机位置
    Vector3 RandomPosition(int wallElementID)
    {
        int randomIndex;
        Vector3 randomPosition=new Vector3(0f,0f,0f);
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
                randomIndex = Random.Range(0, groundPosition.Count);
                randomPosition = groundPosition[randomIndex];
                groundPosition.RemoveAt(randomIndex);
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
        mirrorPosition.RemoveAt(randomIndex);
        picturePosition.RemoveAt(randomIndex);
        //doorPosition.RemoveAt(randomIndex);
        statuePosition.RemoveAt(randomIndex);
        clawPosition.RemoveAt(randomIndex);
    }


    //随机布局墙上物体
    void LayoutWallAtRandom(GameObject[] objectArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);
        Vector3 randomPosition = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < objectCount; i++)
        {
            
            int wallElementsID = Random.Range(0, objectArray.Length);
            //放置镜子
            if(wallElementsID==0) randomPosition = RandomPosition(0);
            //放置图片
            if (wallElementsID == 3||wallElementsID==4) randomPosition = RandomPosition(1);
            //放置雕像
            if (wallElementsID == 1)
            {
                randomPosition = RandomPosition(2);
            }
            if (wallElementsID == 2)
            {
                randomPosition = RandomPosition(4);
            }

            GameObject objectChoice = objectArray[wallElementsID];
            GameObject roomElement = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
            //房间物件存入列表
            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());

        }
    }
    //随机布局地上物体
    void LayoutGroundAtRandom(GameObject[] objectArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition(3);
            GameObject objectChoice = objectArray[Random.Range(0, objectArray.Length)];
            GameObject roomElement = Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
            //房间物件存入列表
            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());

        }
    }
    //随机布局小怪
    void LayoutEnemyAtRandom(GameObject[] objectArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);
        int randomIndex = Random.Range(0, groundPosition.Count); ;
        for (int i = 0; i < objectCount; i++)
        {         
            Vector3 randomPosition = groundPosition[randomIndex];
            groundPosition.RemoveAt(randomIndex);
            GameObject objectChoice = objectArray[Random.Range(0, objectArray.Length)];
            GameObject enemy= Instantiate(objectChoice, randomPosition, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(GameObject.Find("GroundElements").transform);
            //小怪存入列表
            //EnemyManager.Instance.EnemyList.Add(enemy.GetComponent<Character>());

            if (randomIndex < groundPosition.Count - 1 && groundPosition[randomIndex]!=null) randomIndex++;
            else if (randomIndex > 0 && groundPosition[0] != null) randomIndex--;

        }
    }
    //设置门的位置
    public void SetDoorDierction(int[] doorDir)
    {
        for (int i = 0; i < 4; i++)
        {
            doorDirection[i] = doorDir[i];
        }
    }
    //布局门
    void LayoutDoor()
    {
        int j = 0;
        for (int i = 0; i < 4; i++)
        {
            if (doorDirection[i] > 0)
            {
                GameObject objectChoice = doors[Random.Range(0,doors.Length-1)];
                GameObject roomElement = Instantiate(objectChoice, doorPosition[j], Quaternion.identity) as GameObject;
                roomElement.GetComponent<Door>().SetPosition(i);
                roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                //房间物件存入列表
                RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                j++;
            }
        }
    }

    //设置房间位置
    void SetRoomXY(int x, int y)
    {
        roomX = x;
        roomY = y;
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
        EnemyManager.Instance.ClearAll();

    }

    //设置场景,类型号，门位置,房间x，房间y
    public void SetupScene(int tp, int[] dp, int x, int y)
    {
        ClearAll();
        SetDoorDierction(dp);
        InitialiseList();
        SetRoomXY(x, y);
        LayoutEnemyAtRandom(enemys, 1, 8);
        LayoutWallAtRandom(wallElements, wallElementsCount.minimum, wallElementsCount.maximum);
        LayoutGroundAtRandom(groundElements, groundElementsCount.minimum, groundElementsCount.maximum);
        LayoutDoor();
        Notify("EnterRoom");     
    }

    //加载确定场景 房间号 int数组roomX[],roomY[],id[],posiX[],posiY[],posiZ[]
    public void LoadScene(int x,int y,int[] roomX,int[] roomY,int[] id,float[] posiX,float[] posiY,float[] posiZ)
    {
        ClearAll();
        int count = 0;
        for (int i = 0; i < roomX.Length; i++)
        {
            for (int j = 0; j < roomY.Length; j++)
            {
                if (j == y && i == x)
                {
                    Vector3 position = new Vector3(posiX[count],posiY[count],posiZ[count]);
                    GameObject objectChoice;
                    GameObject roomElement;
                    count = i * roomY.Length + j;
                    switch (id[count])
                    {
                        case 0:
                            //Missile
                            break;
                        case 1:
                            //Box Ground
                            objectChoice = groundElements[0];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());                            
                            break;
                        case 2:
                            //Mirror Wall
                            objectChoice = wallElements[0];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 3:
                            //Door WALL
                            objectChoice = doors[1];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 4:
                            //Statue Wall
                            objectChoice = wallElements[1];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 5:
                            //Claw Wall
                            objectChoice = wallElements[2];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 6:
                            //Picture1 Wall
                            objectChoice = wallElements[3];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 7:
                            //Picture2 Wall
                            objectChoice = wallElements[4];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("WallElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>());
                            break;
                        case 8:
                            //Skull Ground
                            objectChoice = groundElements[1];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>()); 
                            break;
                        case 9:
                            //SkullLight Ground
                            objectChoice = groundElements[2];
                            roomElement = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
                            roomElement.transform.SetParent(GameObject.Find("GroundElements").transform);
                            RoomElementManager.Instance.RoomElementList.Add(roomElement.GetComponent<RoomElement>()); 
                            break;
                    }                    
                }
            }
        }
        //Notify("EnterRoom");
    }

    //加载小怪 房间号 int数组roomX[],roomY[],id[],posiX[],posiY[],posiZ[]
    public void LoadEnemy(int x, int y, int[] id, float[] posiX, float[] posiY, float[] posiZ)
    {
        for (int count = 0; count < posiX.Length; count++)
        {
            Vector3 position = new Vector3(posiX[count], posiY[count], posiZ[count]);
            GameObject objectChoice;
            GameObject enemy;

            objectChoice = enemys[0];
            enemy = Instantiate(objectChoice, position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(GameObject.Find("GroundElements").transform);
        }

            Notify("EnterRoom");
    }

}

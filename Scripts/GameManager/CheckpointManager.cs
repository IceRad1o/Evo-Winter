using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class CheckpointManager : ExUnitySingleton<CheckpointManager>
{
    [Serializable]

    //房间分布类
    public class Room
    {
        //房间类型号
        public int type = 0;
        //是否进入过该房间，0否，1是
        public int pass = 0;
        //房间位置x,y
        public int roomX;
        public int roomY;
        //门位置
        public int[] doorDirection = new int[4];
        //构造函数
        public Room(int tp, int x, int y,int[] doorDir)
        {
            type = tp;
            roomX = x;
            roomY = y;
            for (int i = 0; i < 4;i++ )
                doorDirection[i] = doorDir[i];
        }
    }

    //行列
    public int rows = 6;
    public int columns = 6;
    //房间分布
    public int[,] roomArray;
    //周围房间0：上方，1：下方，2：左方，3：右方
    public int[] surroundRoom = new int[4];
    //房间列表,存放Room类
    public List<Room> roomList = new List<Room>();
    
    //获取下个房间类
    public Room GetNextRoom(int x, int y)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].roomX == x && roomList[i].roomY==y)
            {
                return roomList[i];
            }
        }
        return null;
    }

    //初始化房间分布列表
    void InitalRoomLayout()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i == 0 && j == 0 || i == rows - 1 && j == columns - 1)
                {
                    roomArray[i, j] = 1;
                }
                if (roomArray[i, j] == 1)
                {

                    int randomDerection = Random.Range(0, 10);
                    //0,1,2向右走,走到最右向下走
                    if (randomDerection <= 2)
                    {
                        if (i + 1 < rows)
                            roomArray[i + 1, j] = 1;
                        else if (j + 1 < columns)
                            roomArray[i, j + 1] = 1;
                    }
                    //3,4,5向下走，走到最下向右走
                    else if (randomDerection <= 5 && randomDerection >= 3)
                    {
                        if (j + 1 < columns)
                            roomArray[i, j + 1] = 1;
                        else if (i + 1 < rows)
                            roomArray[i + 1, j] = 1;
                    }
                    //6,7,8向下和向右走
                    else if (randomDerection <= 8 && randomDerection >= 6)
                    {
                        if (i + 1 < rows)
                            roomArray[i + 1, j] = 1;
                        if (j + 1 < columns)
                            roomArray[i, j + 1] = 1;
                    }
                    //9，10向下、向右和向左走
                    else
                    {
                        if (i + 1 < rows)
                            roomArray[i + 1, j] = 1;
                        if (j + 1 < columns)
                            roomArray[i, j + 1] = 1;
                        if (i > 0)
                            roomArray[i - 1, j] = 1;
                    }
                }
            }
        }
    }



    //检索roomArray[x,y]周围房间
    int GetSurroundRoom(int x, int y)
    {
        for (int i = 0; i < 4;i++ )
            surroundRoom[i] = 0;
        int count=0;
        //检查右侧
        if (y+1<columns)
        {
            if (roomArray[x, y + 1] == 1)
            {
                surroundRoom[3] = 1;
                count++;
            }
        }
        //检查左侧
        if (y - 1 >= 0)
        {
            if (roomArray[x, y - 1] == 1)
            {
                surroundRoom[2] = 1;
                count++;
            }
        }
        //检查上侧
        if (x - 1 >= 0)
        {
            if (roomArray[x - 1, y] == 1)
            {
                surroundRoom[0] = 1;
                count++;
            }
        }
        //检查下侧
        if (x + 1 < rows)
        {
            if (roomArray[x + 1, y] == 1)
            {
                surroundRoom[1] = 1;
                count++;
            }
        }
        return count;
    }

    //void Start()
    //{
    //    roomArray=new int[rows,columns];
    //    SetupCheckpoint();

    //}


    //设置关卡
    public void SetupCheckpoint()
    {
        roomArray = new int[rows, columns];
        InitalRoomLayout();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int surroundRoomNumber = GetSurroundRoom(i, j);
                if (surroundRoomNumber > 0)
                {
                    int type = Random.Range(0, 3);
                    roomList.Add(new Room(type, i, j, surroundRoom));
                }
            }
        }

        //输出房间布局
        string str = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                str += roomArray[i, j].ToString();
            }
            str += "\n";
        }
        Debug.Log(str);
    }

}

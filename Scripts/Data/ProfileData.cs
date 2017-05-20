using UnityEngine;
using System.Collections;

public class ProfileData
{
    #region Variables
    /*地图关卡数据*/
    #region Level&Map Data
    //当前关卡号
    int curLevel;
    //当前关卡地图类型数组
    int[] map;
    int[] isRoomPassed;
    //当前关卡房间大小数组
    int[] roomSize;
    int curRoomX;//当前所在房间X
    int curRoomY;//当前所在房间Y
    #endregion
    
    /*人物数据*/
    #region Player Data
    float hp;
    int atk;
    int spd;
    int mov;//移速
    int rng;//攻击范围
    int fhr;
    int luk;
    int race;//种族
    int career;
    int sight;
    Vector3 curPosition;
    //buff数据
    string[] buffsID;
    #endregion

    /*房间元素数据*/
    #region RoomElement Data
    int[] roomElementID;
    int[] roomElementState;
    float[] roomElementPosX;
    float[] roomElementPosY;
    float[] roomElementPosZ;
    int[] roomElementRoomX;
    int[] roomElementRoomY;
    #endregion

    #endregion

    #region Methods
    #region Getter&Setter
    #region Level&Map
    public int CurLevel
    {
        get { return curLevel; }
        set
        {
            curLevel = value;
            PlayerPrefs.SetInt("curLevel", curLevel);
        }
    }
    public int[] Map
    {
        get { return map; }
        set
        {
            map = value;
            PlayerPrefsX.SetIntArray("map", map);

        }
    }
    public int[] RoomSize
    {
        get { return roomSize; }
        set
        {
            roomSize = value;
            PlayerPrefsX.SetIntArray("roomSize", roomSize);
        }
    }
    public int[] IsRoomPassed
    {
        get { return isRoomPassed; }
        set
        {
            isRoomPassed = value;
            PlayerPrefsX.SetIntArray("isRoomPassed", isRoomPassed);
        }
    }
    public int CurRoomX
    {
        get { return curRoomX; }
        set
        {
            curRoomX = value;
            PlayerPrefs.SetInt("curRoomX", curRoomX);
        }
    }
    public int CurRoomY
    {
        get { return curRoomY; }
        set
        {
            curRoomY = value;
            PlayerPrefs.SetInt("curRoomY", curRoomY);
        }
    }

    #endregion

    #region Player Data
    public float Hp
    {
        get { return hp; }
        set { hp = value;
        PlayerPrefs.SetFloat("hp", hp);
        }
    }
    public int Atk
    {
        get { return atk; }
        set
        {
            atk = value;
			PlayerPrefs.SetInt("atk", atk);
        }
    }
    public int Spd
    {
        get { return spd; }
        set 
        {
            spd = value;
            PlayerPrefs.SetFloat("spd", spd);
        }
    }
    public int Mov
    {
        get { return mov; }
        set { mov = value;
        PlayerPrefs.SetInt("mov", mov);
        }
    }
    public int Rng
    {
        get { return rng; }
        set { rng = value;
			PlayerPrefs.SetInt("rng", rng);
        }
    }
    public int Fhr
    {
        get { return fhr; }
        set { fhr = value;
			PlayerPrefs.SetInt("fhr", fhr);
        }
    }
    public int Luk
    {
        get { return luk; }
        set
        {
            luk = value;
			PlayerPrefs.SetInt("luk", luk);
        }
    }
    public int Race
    {
        get { return race; }
        set { race = value;
        PlayerPrefs.SetInt("race", race);
        }
    }
    public int Career
    {
        get { return career; }
        set { career = value;
        PlayerPrefs.SetInt("career", career);
        }
    }
    public int Sight
    {
        get { return sight; }
        set { sight = value;
        PlayerPrefs.SetInt("sight", sight);
        }
    }
    public Vector3 CurPosition
    {
        get { return curPosition; }
        set { curPosition = value;
        PlayerPrefsX.SetVector3("curPosition", curPosition);
        }
    }
    public string[] BuffsID
    {
        get { return buffsID; }
        set
        {
            buffsID = value;
            PlayerPrefsX.SetStringArray("buffsID", buffsID);
        }
    }

#endregion

    #region RoomElements Data
    public int[] RoomElementID
    {
        get { return roomElementID; }
        set { roomElementID = value;
        PlayerPrefsX.SetIntArray("roomElementID", roomElementID);
        }
    }
    public float[] RoomElementPosX
    {
        get { return roomElementPosX; }
        set { roomElementPosX = value;
        PlayerPrefsX.SetFloatArray("roomElementPosX",roomElementPosX);
        }
    }
    public float[] RoomElementPosY
    {
        get { return roomElementPosY; }
        set { roomElementPosY = value;
        PlayerPrefsX.SetFloatArray("roomElementPosY", roomElementPosY);
        }
    }
    public float[] RoomElementPosZ
    {
        get { return roomElementPosZ; }
        set { roomElementPosZ = value;
        PlayerPrefsX.SetFloatArray("roomElementPosZ", roomElementPosZ);
        }
    }
    public int[] RoomElementRoomX
    {
        get { return roomElementRoomX; }
        set 
        {
            roomElementRoomX = value;
            PlayerPrefsX.SetIntArray("roomElementRoomX",roomElementRoomX);
        }
    }
    public int[] RoomElementRoomY
    {
        get { return roomElementRoomY; }
        set 
        { 
            roomElementRoomY = value;
            PlayerPrefsX.SetIntArray("roomElementRoomY", roomElementRoomY);
        }
    }
    public int[] RoomElementState
    {
        get { return roomElementState; }
        set {
            roomElementState = value;
            PlayerPrefsX.SetIntArray("roomElementState", roomElementState);
        }
    }
    #endregion
    #endregion
    public void Init()
    {
        curLevel = PlayerPrefs.GetInt("curLevel");
        map = PlayerPrefsX.GetIntArray("map");
        isRoomPassed = PlayerPrefsX.GetIntArray("isRoomPassed");
        curRoomY = PlayerPrefs.GetInt("curRoomY");
        curRoomX = PlayerPrefs.GetInt("curRoomX");

        hp = PlayerPrefs.GetFloat("hp");
        atk = PlayerPrefs.GetInt("atk");
        mov = PlayerPrefs.GetInt("mov");
        rng = PlayerPrefs.GetInt("rng");
        fhr = PlayerPrefs.GetInt("fhr");
        luk = PlayerPrefs.GetInt("luk");
        race = PlayerPrefs.GetInt("race");
        career = PlayerPrefs.GetInt("weapon");
        sight = PlayerPrefs.GetInt("sight");
        curPosition = PlayerPrefsX.GetVector3("curPosition");
        buffsID = PlayerPrefsX.GetStringArray("buffsID");


		roomSize = PlayerPrefsX.GetIntArray ("roomSize");

        roomElementID = PlayerPrefsX.GetIntArray("roomElementID");
        roomElementState = PlayerPrefsX.GetIntArray("roomElementState");
        roomElementPosX = PlayerPrefsX.GetFloatArray("roomElementPosX");
        roomElementPosY = PlayerPrefsX.GetFloatArray("roomElementPosY");
        roomElementPosZ = PlayerPrefsX.GetFloatArray("roomElementPosZ");
        roomElementRoomX = PlayerPrefsX.GetIntArray("roomElementRoomX");
        roomElementRoomY = PlayerPrefsX.GetIntArray("roomElementRoomY");
    }
    #endregion
}

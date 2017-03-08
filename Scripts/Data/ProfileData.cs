using UnityEngine;
using System.Collections;

public class ProfileData
{

    //地图关卡数据
    int curLevel;//当前关卡

    public int CurLevel
    {
        get { return curLevel; }
        set { curLevel = value;
        PlayerPrefs.SetInt("curLevel", curLevel);
        }
    }
    int[] map;

    public int[] Map
    {
        get { return map; }
        set 
        { 
            map = value;
            PlayerPrefsX.SetIntArray("map", map);
            
        }
    }
    int curMap;

    public int CurMap
    {
        get { return curMap; }
        set 
        { 
            curMap = value;
            PlayerPrefs.SetInt("curMap", curMap);
        }
    }

    //人物数据
    float  health;

    public float Health
    {
        get { return health; }
        set { health = value;
        PlayerPrefs.SetFloat("health", health);
        }
    }
    float moveSpeed;    //移速

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value;
        PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        }
    }
    float attackRange;

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value;
        PlayerPrefs.SetFloat("attackRange", attackRange);
        }
    }
    float attackDamage;

    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value;
        PlayerPrefs.SetFloat("attackDamage", attackDamage);
        }
    }
    float hitRecover;

    public float HitRecover
    {
        get { return hitRecover; }
        set { hitRecover = value;
        PlayerPrefs.SetFloat("hitRecover", hitRecover);
        }
    }
    float spasticity;

    public float Spasticity
    {
        get { return spasticity; }
        set { spasticity = value;
        PlayerPrefs.SetFloat("spasticity", spasticity);
        }
    }
    int race;   //种族

    public int Race
    {
        get { return race; }
        set { race = value;
        PlayerPrefs.SetInt("race", race);
        }
    }
    int weapon;

    public int Weapon
    {
        get { return weapon; }
        set { weapon = value;
        PlayerPrefs.SetInt("weapon", weapon);
        }
    }
    int sight;

    public int Sight
    {
        get { return sight; }
        set { sight = value;
        PlayerPrefs.SetInt("sight", sight);
        }
    }
    int camp;

    public int Camp
    {
        get { return camp; }
        set { camp = value;
        PlayerPrefs.SetInt("camp", camp);
        }
    }
    float luck;

    public float Luck
    {
        get { return luck; }
        set { luck = value;
        PlayerPrefs.SetFloat("luck",luck);
        }
    }
    int actionStateMachineID;

    public int ActionStateMachineID
    {
        get { return actionStateMachineID; }
        set { actionStateMachineID = value;
        PlayerPrefs.SetInt("actionStateMachineID", actionStateMachineID);
        }
    }

    Vector3 curPosition;

    public Vector3 CurPosition
    {
        get { return curPosition; }
        set { curPosition = value;
        PlayerPrefsX.SetVector3("curPosition", curPosition);
        }
    }



    //敌人数据
    int[] enemyID;

    public int[] EnemyID
    {
        get { return enemyID; }
        set { enemyID = value;
        PlayerPrefsX.SetIntArray("enemyID", enemyID);
        }
    }
    float[] enemyPosX;

    public float[] EnemyPosX
    {
        get { return enemyPosX; }
        set { enemyPosX = value;
        PlayerPrefsX.SetFloatArray("enemyPosX", enemyPosX);
        }
    }
    float[] enemyPosY;

    public float[] EnemyPosY
    {
        get { return enemyPosY; }
        set { enemyPosY = value;
        PlayerPrefsX.SetFloatArray("enemyPosY", enemyPosY);
        }
    }
    float[] enemyPosZ;

    public float[] EnemyPosZ
    {
        get { return enemyPosZ; }
        set { enemyPosZ = value;
        PlayerPrefsX.SetFloatArray("enemyPosZ", enemyPosZ);
        }
    }
    
    //房间元素数据
    int[] roomElementID;

    public int[] RoomElementID
    {
        get { return roomElementID; }
        set { roomElementID = value;
        PlayerPrefsX.SetIntArray("roomElementID", roomElementID);
        }
    }
    float[] roomElementPosX;

    public float[] RoomElementPosX
    {
        get { return roomElementPosX; }
        set { roomElementPosX = value;
        PlayerPrefsX.SetFloatArray("roomElementPosX",roomElementPosX);
        }
    }
    float[] roomElementPosY;

    public float[] RoomElementPosY
    {
        get { return roomElementPosY; }
        set { roomElementPosY = value;
        PlayerPrefsX.SetFloatArray("roomElementPosY", roomElementPosY);
        }
    }
    float[] roomElementPosZ;

    public float[] RoomElementPosZ
    {
        get { return roomElementPosZ; }
        set { roomElementPosZ = value;
        PlayerPrefsX.SetFloatArray("roomElementPosZ", roomElementPosZ);
        }
    }
    


    //buff数据
    int[] buffsID;

    public int[] BuffsID
    {
        get { return buffsID; }
        set { buffsID = value;
        PlayerPrefsX.SetIntArray("buffsID", buffsID);
        }
    }
    //item数据
    int[] itemsID;

    public int[] ItemsID
    {
        get { return itemsID; }
        set { itemsID = value;
        PlayerPrefsX.SetIntArray("itemsID", itemsID);
        }
    }
    int itemEnergy;

    public int ItemEnergy
    {
        get { return itemEnergy; }
        set { itemEnergy = value;
        PlayerPrefs.SetInt("itemEnergy", itemEnergy);
        }
    }


    int[] esscencesID;

    public int[] EsscencesID
    {
        get { return esscencesID; }
        set { esscencesID = value;
        PlayerPrefsX.SetIntArray("esscencesID", esscencesID);
        }
    }
    int[] esscencesNum;

    public int[] EsscencesNum
    {
        get { return esscencesNum; }
        set { esscencesNum = value;
        PlayerPrefsX.SetIntArray("esscencesNum", esscencesNum);
        }
    }

    












    public void Init()
    {
        curLevel = PlayerPrefs.GetInt("curLevel");
        curMap = PlayerPrefs.GetInt("curMap");
        health = PlayerPrefs.GetFloat("health");
        moveSpeed = PlayerPrefs.GetFloat("moveSpeed");
        attackRange = PlayerPrefs.GetFloat("attackRange");
        attackDamage = PlayerPrefs.GetFloat("attackDamage");
        hitRecover = PlayerPrefs.GetFloat("hitRecover");
        spasticity = PlayerPrefs.GetFloat("spasticity");
        race = PlayerPrefs.GetInt("race");
        weapon = PlayerPrefs.GetInt("weapon");
        sight = PlayerPrefs.GetInt("sight");
        camp = PlayerPrefs.GetInt("camp");
        luck = PlayerPrefs.GetFloat("luck");
        actionStateMachineID = PlayerPrefs.GetInt("actionStateMachineID");
        itemEnergy = PlayerPrefs.GetInt("itemEnergy");
        map = PlayerPrefsX.GetIntArray("map");
        curPosition = PlayerPrefsX.GetVector3("curPosition");
        enemyID = PlayerPrefsX.GetIntArray("enemyID");
        enemyPosX = PlayerPrefsX.GetFloatArray("enemyPosX");
        enemyPosY = PlayerPrefsX.GetFloatArray("enemyPosY");
        enemyPosZ = PlayerPrefsX.GetFloatArray("enemyPosZ");
        roomElementID = PlayerPrefsX.GetIntArray("roomElementID");
        roomElementPosX = PlayerPrefsX.GetFloatArray("roomElementPosX");
        roomElementPosY = PlayerPrefsX.GetFloatArray("roomElementPosY");
        roomElementPosZ = PlayerPrefsX.GetFloatArray("roomElementPosZ");
        buffsID = PlayerPrefsX.GetIntArray("buffsID");
        itemsID = PlayerPrefsX.GetIntArray("itemsID");
        esscencesID = PlayerPrefsX.GetIntArray("esscencesID");
        esscencesNum = PlayerPrefsX.GetIntArray("esscencesNum");
    }

}

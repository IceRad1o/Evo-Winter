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
    int health;

    public int Health
    {
        get { return health; }
        set { health = value;
        PlayerPrefs.SetInt("curHealth", health);
        }
    }
    float moveSpeed;    //移速

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value;
        PlayerPrefs.SetFloat("curMoveSpeed", moveSpeed);
        }
    }
    float attackRange;

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value;
        PlayerPrefs.SetFloat("curAttackRange", attackRange);
        }
    }
    float attackDamage;

    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value;
        PlayerPrefs.SetFloat("curAttackDamage", attackDamage);
        }
    }
    float hitRecover;

    public float HitRecover
    {
        get { return hitRecover; }
        set { hitRecover = value;
        PlayerPrefs.SetFloat("curHitRecover", hitRecover);
        }
    }
    float spasticity;

    public float Spasticity
    {
        get { return spasticity; }
        set { spasticity = value;
        PlayerPrefs.SetFloat("curSpasticity", spasticity);
        }
    }
    int race;   //种族

    public int Race
    {
        get { return race; }
        set { race = value;
        PlayerPrefs.SetInt("curRace", race);
        }
    }
    int weapon;

    public int Weapon
    {
        get { return weapon; }
        set { weapon = value;
        PlayerPrefs.SetInt("curWeapon", weapon);
        }
    }
    int sight;

    public int Sight
    {
        get { return sight; }
        set { sight = value;
        PlayerPrefs.SetInt("curSight", sight);
        }
    }
    int camp;

    public int Camp
    {
        get { return camp; }
        set { camp = value;
        PlayerPrefs.SetInt("curCamp", camp);
        }
    }
    float luck;

    public float Luck
    {
        get { return luck; }
        set { luck = value;
        PlayerPrefs.SetFloat("curLuck",luck);
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
        curLevel = PlayerPrefs.GetInt("curLevel", 0);
        map = PlayerPrefsX.GetIntArray("map");
    }

}

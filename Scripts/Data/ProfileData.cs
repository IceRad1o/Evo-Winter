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
            
        }
    }
    int curMap;

    //人物数据
    int health;
    float moveSpeed;    //移速
    float attackRange;
    float attackDamage;
    float hitRecover;
    float spasticity;
    int race;   //种族
    int weapon;
    int sight;
    int camp;
    int luck;
    int actionStateMachineID;
    float posX;
    float posY;
    float posZ;


    //敌人数据
    int []enemyID;
    float[] enemyPosX;
    float[] enemyPosY;
    float[] enemyPosZ;
    int enemyNum;
    //房间元素数据
    int []roomElementID;
    float[] roomElementPosX;
    float[] roomElementPosY;
    float[] roomElementPosZ;
    int roomElementNum;


    //buff数据
    int[] buffID;
    int[] buffNum;
    //item数据
    int[] itemsID;
    int itemEnergy;


    












    public void Init()
    {
    }

}

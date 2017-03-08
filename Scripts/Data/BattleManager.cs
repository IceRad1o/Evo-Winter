using UnityEngine;
using System.Collections;
/// <summary>
/// 实时记录下战斗数据
/// 怪物种族4个,类型4-5个,共20个
/// boss共20个
/// </summary>
public class BattleManager : ExUnitySingleton<BattleManager>
{


    void InitData()
    {


        timesOfPassGame = 0;
        timesOfPassMap = 0;
        timesOfPassRoom = 0;

        timesOfKilledByItems = new int[5];//仅记录可以杀死自己的道具
        for (int i = 0; i < timesOfKilledByItems.Length; i++)
        {
            timesOfKilledByItems[i] = 0;
        }

        timesOfKilledByMonster = new int[20];
        for (int i = 0; i < timesOfKilledByMonster.Length; i++)
        {
            timesOfKilledByMonster[i] = 0;
        }
        timesOfKilledByBoss = new int[20];
        for (int i = 0; i < timesOfKilledByBoss.Length; i++)
        {
            timesOfKilledByBoss[i] = 0;
        }
        timesOfDeath = 0;

        numOfGetItem = 0;
        numOfUseItem = 0;
        numOfUseSkill = 0;
        numOfGetSkill = 0;
        numOfGetBuff = 0;

        amountOfAttackDamage = 0;
        amountOfSufferDamage = 0;
        amountOfRecoverHealth = 0;

        itemBook = new int[60];
        for (int i = 0; i < itemBook.Length; i++)
        {
            itemBook[i] = 0;
        }
        monsterBook = new int[20];
        for (int i = 0; i < monsterBook.Length; i++)
        {
            monsterBook[i] = 0;
        }
        bossBook = new int[20];
        for (int i = 0; i < bossBook.Length; i++)
        {
            bossBook[i] = 0;
        }
        esscenceBook = new int[20];
        for (int i = 0; i < esscenceBook.Length; i++)
        {
            esscenceBook[i] = 0;
        }
        weaponBook = new int[20];
        for (int i = 0; i < weaponBook.Length; i++)
        {
            weaponBook[i] = 0;
        }
        timesOfKillBossWithoutDamage = 0;
        numberOfKillSinInOnceGame = 0;

        timesOfPassGameWithSingleRace = new int[4];
        for (int i = 0; i < timesOfPassGameWithSingleRace.Length; i++)
        {
            timesOfPassGameWithSingleRace[i] = 0;
        }
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
        //if (str[0] == "BgmVolumeChanged")
        // data.BackGroundMusicVolume = float.Parse(str[1]);
        if(str[0]=="Monster Die")
        {
            monsterBook[int.Parse(str[1])]++;
        }
        if (str[0] == "Get_InitiativeItem" || str[0] == "Get_ImmediatelyItem" || str[0] == "Get_DisposableItem")
        {
            itemBook[int.Parse(str[1]) - 1000]++;
            numOfGetItem++;
        }
        if(str[0]=="UseItem_Buff_ID"||str[0]=="UseItem_Skill_ID")
        {
            numOfUseItem++;
        }
        //if(str[0]=="")
    }



    int timesOfPassGame;
    int timesOfPassMap;
    int timesOfPassRoom;

    int[] timesOfKilledByItems;
    int[] timesOfKilledByMonster;
    int[] timesOfKilledByBoss;
    int timesOfDeath;

    int numOfGetItem;
    int numOfUseItem;
    int numOfUseSkill;
    int numOfGetSkill;
    int numOfGetBuff;

    int amountOfAttackDamage;
    int amountOfSufferDamage;
    int amountOfRecoverHealth;

    int[] itemBook;
    int[] monsterBook;
    int[] bossBook;
    int[] esscenceBook;
    int[] weaponBook;
    int timesOfKillBossWithoutDamage;
    int numberOfKillSinInOnceGame;

    int[] timesOfPassGameWithSingleRace;
}

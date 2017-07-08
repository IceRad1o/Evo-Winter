using UnityEngine;
using System.Collections;

public class GameData {

    int numOfKillAllMonster;
    int[] numOfKillRaceMonster;
    int numOfKillAllBoss;
    int[] numOfKillRaceBoss;

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

    public int NumOfKillAllMonster
    {
        get { return numOfKillAllMonster; }
        set
        {
            numOfKillAllMonster = value;
            PlayerPrefs.SetInt("numOfKillAllMonster", numOfKillAllMonster);
        }
    }
    public int NumOfKillAllBoss
    {
        get { return numOfKillAllBoss; }
        set
        {
            numOfKillAllBoss = value;
            PlayerPrefs.SetInt("numOfKillAllBoss", numOfKillAllBoss);
        }
    }
    public int TimesOfPassGame
    {
        get { return timesOfPassGame; }
        set
        {
            timesOfPassGame = value;
            PlayerPrefs.SetInt("timesOfPassGame", timesOfPassGame);
        }
    }
    public int TimesOfPassMap
    {
        get { return timesOfPassMap; }
        set
        {
            timesOfPassMap = value;
            PlayerPrefs.SetInt("timesOfPassMap", timesOfPassMap);
        }
    }
    public int TimesOfPassRoom
    {
        get { return timesOfPassRoom; }
        set
        {
            timesOfPassRoom = value;
            PlayerPrefs.SetInt("timesOfPassRoom", timesOfPassRoom);
        }
    }
    public int TimesOfDeath
    {
        get { return timesOfDeath; }
        set
        {
            timesOfDeath = value;
            PlayerPrefs.SetInt("timesOfDeath", timesOfDeath);
        }
    }
    public int NumOfGetItem
    {
        get { return numOfGetItem; }
        set
        {
            numOfGetItem = value;
            PlayerPrefs.SetInt("numOfGetItem", numOfGetItem);
        }
    }
    public int NumOfUseItem
    {
        get { return numOfUseItem; }
        set
        {
            numOfUseItem = value;
            PlayerPrefs.SetInt("numOfUseItem", numOfUseItem);
        }
    }
    public int NumOfUseSkill
    {
        get { return numOfUseSkill; }
        set
        {
            numOfUseSkill = value;
            PlayerPrefs.SetInt("numOfUseSkill", numOfUseSkill);
        }
    }
    public int NumOfGetSkill
    {
        get { return numOfGetSkill; }
        set
        {
            numOfGetSkill = value;
            PlayerPrefs.SetInt("numOfGetSkill", numOfGetSkill);
        }
    }
    public int NumOfGetBuff
    {
        get { return numOfGetBuff; }
        set
        {
            numOfGetBuff = value;
            PlayerPrefs.SetInt("numOfGetBuff", numOfGetBuff);
        }
    }
    public int AmountOfAttackDamage
    {
        get { return amountOfAttackDamage; }
        set
        {
            amountOfAttackDamage = value;
            PlayerPrefs.SetInt("amountOfAttackDamage", amountOfAttackDamage);
        }
    }
    public int AmountOfSufferDamage
    {
        get { return amountOfSufferDamage; }
        set
        {
            amountOfSufferDamage = value;
            PlayerPrefs.SetInt("amountOfSufferDamage", amountOfSufferDamage);
        }
    }
    public int AmountOfRecoverHealth
    {
        get { return amountOfRecoverHealth; }
        set
        {
            amountOfRecoverHealth = value;
            PlayerPrefs.SetInt("amountOfRecoverHealth", amountOfRecoverHealth);
        }
    }
    public int TimesOfKillBossWithoutDamage
    {
        get { return timesOfKillBossWithoutDamage; }
        set
        {
            timesOfKillBossWithoutDamage = value;
            PlayerPrefs.SetInt("timesOfKillBossWithoutDamage", timesOfKillBossWithoutDamage);
        }
    }
    public int NumberOfKillSinInOnceGame
    {
        get { return numberOfKillSinInOnceGame; }
        set
        {
            numberOfKillSinInOnceGame = value;
            PlayerPrefs.SetInt("numberOfKillSinInOnceGame", numberOfKillSinInOnceGame);
        }
    }
    public int[] NumOfKillRaceMonster
    {
        get { return numOfKillRaceMonster; }
        set
        {
            numOfKillRaceMonster = value;
            PlayerPrefsX.SetIntArray("numOfKillRaceMonster", numOfKillRaceMonster);
        }
    }
    public int[] NumOfKillRaceBoss
    {
        get { return numOfKillRaceBoss; }
        set
        {
            numOfKillRaceBoss = value;
            PlayerPrefsX.SetIntArray("numOfKillRaceBoss", numOfKillRaceBoss);
        }
    }
    public int[] TimesOfKilledByItems
    {
        get { return timesOfKilledByItems; }
        set
        {
            timesOfKilledByItems = value;
            PlayerPrefsX.SetIntArray("timesOfKilledByItems", timesOfKilledByItems);
        }
    }
    public int[] TimesOfKilledByMonster
    {
        get { return timesOfKilledByMonster; }
        set
        {
            timesOfKilledByMonster = value;
            PlayerPrefsX.SetIntArray("timesOfKilledByMonster", timesOfKilledByMonster);
        }
    }
    public int[] TimesOfKilledByBoss
    {
        get { return timesOfKilledByBoss; }
        set
        {
            timesOfKilledByBoss = value;
            PlayerPrefsX.SetIntArray("timesOfKilledByBoss", timesOfKilledByBoss);
        }
    }
    public int[] ItemBook
    {
        get { return itemBook; }
        set
        {
            itemBook = value;
            PlayerPrefsX.SetIntArray("itemBook", itemBook);
        }
    }
    public int[] MonsterBook
    {
        get { return monsterBook; }
        set
        {
            monsterBook = value;
            PlayerPrefsX.SetIntArray("monsterBook", monsterBook);
        }
    }
    public int[] BossBook
    {
        get { return bossBook; }
        set
        {
            bossBook = value;
            PlayerPrefsX.SetIntArray("bossBook", bossBook);
        }
    }
    public int[] EsscenceBook
    {
        get { return esscenceBook; }
        set
        {
            esscenceBook = value;
            PlayerPrefsX.SetIntArray("esscenceBook", esscenceBook);
        }
    }
    public int[] WeaponBook
    {
        get { return weaponBook; }
        set
        {
            weaponBook = value;
            PlayerPrefsX.SetIntArray("weaponBook", weaponBook);
        }
    }
    public int[] TimesOfPassGameWithSingleRace
    {
        get { return timesOfPassGameWithSingleRace; }
        set
        {
            timesOfPassGameWithSingleRace = value;
            PlayerPrefsX.SetIntArray("timesOfPassGameWithSingleRace", timesOfPassGameWithSingleRace);
        }
    }
    public void Init()
    {
        numOfKillAllMonster = PlayerPrefs.GetInt("numOfKillAllMonster");
        numOfKillAllBoss = PlayerPrefs.GetInt("numOfKillAllBoss");
        timesOfPassGame = PlayerPrefs.GetInt("timesOfPassGame");
        timesOfPassMap = PlayerPrefs.GetInt("timesOfPassMap");
        timesOfPassRoom = PlayerPrefs.GetInt("timesOfPassRoom");
        timesOfDeath = PlayerPrefs.GetInt("timesOfDeath");
        numOfGetItem = PlayerPrefs.GetInt("numOfGetItem");
        numOfUseItem = PlayerPrefs.GetInt("numOfUseItem");
        numOfUseSkill = PlayerPrefs.GetInt("numOfUseSkill");
        numOfGetSkill = PlayerPrefs.GetInt("numOfGetSkill");
        numOfGetBuff = PlayerPrefs.GetInt("numOfGetBuff");
        amountOfAttackDamage = PlayerPrefs.GetInt("amountOfAttackDamage");
        amountOfSufferDamage = PlayerPrefs.GetInt("amountOfSufferDamage");
        amountOfRecoverHealth = PlayerPrefs.GetInt("amountOfRecoverHealth");
        timesOfKillBossWithoutDamage = PlayerPrefs.GetInt("timesOfKillBossWithoutDamage");
        numberOfKillSinInOnceGame = PlayerPrefs.GetInt("numberOfKillSinInOnceGame");
        numOfKillRaceMonster = PlayerPrefsX.GetIntArray("numOfKillRaceMonster");
        numOfKillRaceBoss = PlayerPrefsX.GetIntArray("numOfKillRaceBoss");
        timesOfKilledByItems = PlayerPrefsX.GetIntArray("timesOfKilledByItems");
        timesOfKilledByMonster = PlayerPrefsX.GetIntArray("timesOfKilledByMonster");
        timesOfKilledByBoss = PlayerPrefsX.GetIntArray("timesOfKilledByBoss");
        itemBook = PlayerPrefsX.GetIntArray("itemBook");
        monsterBook = PlayerPrefsX.GetIntArray("monsterBook");
        bossBook = PlayerPrefsX.GetIntArray("bossBook");
        esscenceBook = PlayerPrefsX.GetIntArray("esscenceBook");
        weaponBook = PlayerPrefsX.GetIntArray("weaponBook");
        timesOfPassGameWithSingleRace = PlayerPrefsX.GetIntArray("timesOfPassGameWithSingleRace");
    }

   


}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 房间元素,具备MonoBehavoir以及Notify/OnNotify的功能
/// </summary>
public class RoomElement : ExSubject
{

    #region Varibles
    public int roomElementID;
    public int maxHp = 10;
    private bool isDestoryOnEnterRoom = true;


    bool isDieWithMaster = true;


    public GameObject bloodBarPrefab;
    GameObject bloodBarInstance;

    //主人
    GameObject master;
    //从属者
    List<GameObject> servants=new List<GameObject>();

    int roomElementState = 0;
    float hp;
    float healthPercent = 1f;


    #endregion

    #region Methods

    #region Getter&Setter
    /*
     * 0:发射物Missile
     * 1:箱子Box
     * 2:镜子Mirror
     * 3:门Door
     * 4:雕像Statue
     * 5:爪子Claw
     * 6:图一Picture1
     * 7:图二Picture2
     * 8:骷髅Skull
     * 9:骷髅灯SkullLight
     * 10:瓶子一Bottle1
     * 11:瓶子二Bottle2
     * 12:骨头Gone
     * 13:杆Rod
     * 14:石头Stone
     * 15:陷阱Trap
     * 16:楼梯Stair
     * 17:祭坛一Altar1
     * 18:祭坛二Altar2
     * 19:商店Shop
     * 20:牌子Plate
     * 21:金币Coin
     * 22:开关Handle
     * 1000+:道具
     * 2000+ 人物
     * */
	public enum REID
	{
		//房间物品
		Missile = 0,
		Box = 1,
		Mirror = 2,
		Door = 3,
		Statue = 4,
		Claw = 5,
		Picture1 = 6,
		Picture2 = 7,
		Skull = 8,
		SkullLight = 9,
		Bottle1 = 10,
		Bottle2 = 11,
		Gone = 12,
		Rod = 13,
		Stone = 14,
		Trap = 15,
		Stair = 16,
		Altar1 = 17,
		Altar2 = 18,
		Shop = 19,
		Plate = 20,
		Coin = 21,
		Handle = 22,

		//小怪
		GnomeBlaster = 2100,
		GnomeWarrior = 2101,
		GnomeAlchemist = 2102,
		GnomeArcher = 2103,
		GnomePatrol = 2104,
		GnomeAdvancedArcher = 2105,
		GnomeScootWarrior = 2106,
		GnomeCheerer = 2107,
		GnomePharmacist = 2108,
		GnomeKing = 2109,

		PygmyPuppet1 = 2200,
		PygmyPuppet2 = 2201,
		PygmyPuppet3 = 2202,
		PygmyTrainGunner = 2203,
		PygmyRobber = 2204,
		PygmySummoner = 2205,
		PygmyIceGunner = 2206,
		PygmyFireGunner = 2207,
		PygmySiegePuppet = 2208,
		PygmyKing = 2209,

		VampireBat = 2300,
		VampireWarrior = 2301,
		VampireCrossbower = 2302,
		VampireMage = 2303,
		VampireAssassin = 2304,
		VampireBlaster = 2305,
		VampireCrackWarrior = 2306,
		VampireHuntter = 2307,
		VampireSummoner = 2308,
		VampireSpiritCaller = 2309,
		VampireKing = 2310

	};




    public int RoomElementID
    {
        get { return roomElementID; }
        set { roomElementID = value; }
    }
	public int RoomElementState
	{
		get { return roomElementState; }
		set { roomElementState = value; }
	}
    public bool IsDieWithMaster
    {
        get { return isDieWithMaster; }
        set { isDieWithMaster = value; }
    }
    public bool IsDestoryOnEnterRoom
    {
        get { return isDestoryOnEnterRoom; }
        set { isDestoryOnEnterRoom = value; }
    }
    //0.生命Health,代表玩家的血量
    //float hpValue;  
    public virtual float Hp
    {
        get { return hp; }
        set {
         
            StringBuilder s = new StringBuilder(30).Append("HealthChanged;").Append((int)Hp).Append(";");
            hp = value;
            HealthPercent = Hp / maxHp;
            Notify(s.Append((int)Hp).Append(";").Append(this.tag).ToString());
        }
    }
    /// <summary>
    /// 生命百分比
    /// </summary>
    public float HealthPercent
    {
        get { return healthPercent; }
        set
        {
            float tmp = healthPercent;
            healthPercent = value;
            Notify("HealthPercent;" + healthPercent + ";" + tmp);
        }
    }

    public GameObject Master
    {
        get { return master; }
        set { 
            master = value;
        
        if (!master.GetComponent<RoomElement>().Servants.Contains(gameObject))
              master.GetComponent<RoomElement>().Servants.Add(gameObject);
        }
    }

    public List<GameObject> Servants
    {
        get { return servants; }
        set { servants = value; }
    }
    #endregion

    #region Virtual Methods
    public virtual void Awake () {
        this.tag = "RoomElement";
        RoomElementManager.Instance.RoomElementList.Add(this);
	}
    public virtual void Destroy()
    {
        RoomElementManager.Instance.RoomElementList.Remove(this);
        Destroy(this.gameObject);
    }
    public virtual void KillServants()
    {
        for(int i=0;i<Servants.Count;i++)
        {
            if (Servants[i] == null)
                continue;
            RoomElement re = Servants[i].GetComponent<RoomElement>();
            if (re.isDieWithMaster)
                re.Die();
        }
    }
    public virtual void Die() {
        this.Destroy();
    }

    public virtual void Trriger()
    { 
    }
    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        // Debug.Log("altarmsg:" + msg);
        if (str[0] == "AttackStart" && str[1] == "J")
        {
            Trriger();
        }
//		if (str [0] == "MissileEnterBottle") 
//		{
//			Trriger();
//		}

    }
    #endregion

    #region Other Methods
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        SoundManager.Instance.PlaySoundEffect(clip);
    }

    public void EnableBloodBar(bool isEnable)
    {
        if(isEnable)
        {
            if (bloodBarInstance)
                bloodBarInstance.SetActive(true);
            else
                bloodBarInstance = Instantiate(bloodBarPrefab, transform,false) as GameObject;
        }
        else
        {
            if (bloodBarInstance)
                bloodBarInstance.SetActive(false);
        }
    }

    #endregion

    #endregion
}

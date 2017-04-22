using UnityEngine;
using System.Collections;

public class Esscence : RoomElement {

    int esscenceID;
    public Sprite[] spriteArray;
    //名称描述图片类别ID
    static public string[] esscenceName = { "懒惰精华", "暴怒精华", "傲慢精华", "贪婪精华" };
    static public string[] esscenceDescrible = { "由懒惰之欲凝结而成的精华,蕴含着强大的力量", "由暴怒之欲凝结而成的精华,蕴含着强大的力量", "由傲慢之欲凝结而成的精华,蕴含着强大的力量", "由贪婪之欲凝结而成的精华,蕴含着强大的力量" };
    static public int[] esscenceType = { 1, 3, 2, 0 };
    static public string[,] esscenceSkillDescribe = {
                                             { "嗜睡：\n每结束一个房间回复一格生命", "天赋：锻造\n主动道具的充能灵魂数减少1/3", "欲望：永恒安眠\n进入房间时，懒惰的欲望使敌方昏昏欲睡，导致行动迟缓（进入房间时，有一定几率使敌方的攻击速度-1所有敌人，独自判定", "天赋：坚甲\n优秀种族天赋给予了矮人们强大的抗性（不会被击倒，但是会被打断击退和硬控）","被攻击时，有一定概率增加一个护盾（抵挡3点伤害）" },
                                             { "本性：嗜血\n狼人对血的渴望使得他们越来越强（每个房间造成10点伤害后攻击速度+1）", "天赋：撕裂\n狼人利用增加尖锐的爪子撕裂对方的伤口，是对方难以移动", "欲望：血之暴怒\n当自己的生命少于3格时（不包括三格）时，处于暴走状态，造成的攻击伤害+1", "天赋：孤狼血统\n草原上的孤狼越战越勇，带着丝丝怒意，使自己变得更强，更快。在一个房间中收到超过两点伤害，攻速+1", "欲望：缠怒\n带着怒气的攻击将造成意想不到的伤害，攻击时一定几率暴击" },
                                             { "诅咒：毒噬\n攻击时用自己最拿手的剧毒诅咒吞噬对方，有一定几率使对方中毒", "吸血", "天赋：血奴\n被吸血鬼击杀的敌人都有可能变成吸血鬼虚弱的血奴，为其战斗", "欲望：唯我独尊\n过度的傲慢致使生人勿进，攻击时有一定概率击退敌人，打断攻击", "天赋：变身蝙蝠\n攻击时召唤一只蝙蝠" },
                                             { "一次性道具的使用次数+1，道具的掉落概率增加", "主动道具充能时，一定概率增加的灵魂数+1", "强大的欲望使得自己可以为了自己财富失去本性。财富（有用过的道具，详解见贪婪第五被动）越多，幸运越高（比例暂定）", "欲望：占有\n贪婪的欲望使得其想占有一切财富，越来越多的财富使其不断兴奋，变得更强。每使用3个道具回复一格体力", "欲望：驱使\n在贪婪看来，财富是世上最神奇的事物，可以驱使一切。" }
                                             };
    static public string[,] esscenceSkillName;
    public Sprite[] esscenceSkillSprite;

    bool playerIn = false;

    public void Create(int ID) 
    {
        esscenceID = ID;
        GetComponent<SpriteRenderer>().sprite=spriteArray[esscenceID];   
    }

    void PlayerGet() 
    {
        Notify("Get_Esscence;" + esscenceID);
        UIManager.Instance.RemoveObserver(this);
        Player.Instance.Character.RemoveObserver(this);

        GameObject pfb = Resources.Load("Buffs/devil") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        pfb.GetComponent<SpriteRenderer>().sprite = spriteArray[esscenceID];
        GameObject prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;


        base.Destroy();
    }



    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Notify("Player_Get_Esscence;" + esscenceID);
            playerIn = !playerIn;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Notify("Player_Leave_Esscence;" + esscenceID);
            playerIn = !playerIn;
        }
    }


	// Use this for initialization
	void Start () {
        UIManager.Instance.AddObserver(this);
        Player.Instance.Character.AddObserver(this);
        this.AddObserver(EsscenceManager.Instance);
	}


    public override void OnNotify(string msg)
    {
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "AttackStart" && playerIn)
        {
            PlayerGet();
        }
    }
	
}

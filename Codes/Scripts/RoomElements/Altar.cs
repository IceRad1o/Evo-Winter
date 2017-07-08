using UnityEngine;
using System.Collections;
/// <summary>
/// 祭坛
/// </summary>
public class Altar : RoomElement
{

    public enum Type
    {
        /// <summary>
        /// 恶魔祭坛
        /// </summary>
        evil,
        /// <summary>
        /// 普通祭坛
        /// </summary>
        normal
    }
    /// <summary>
    /// 祭坛的类型
    /// </summary>
    public Type altarType = Type.normal;
    /// <summary>
    /// 是否随机
    /// </summary>
    public bool isRandom = true;
    /// <summary>
    /// 被增益的属性
    /// </summary>
    public int buffAttri;
    /// <summary>
    /// 被减益的属性
    /// </summary>
    public int debuffAttri;
    /// <summary>
    /// 被增益的数值
    /// </summary>
    public int buffValue;
    /// <summary>
    /// 被减益的数值
    /// </summary>
    public int debuffValue;
    /// <summary>
    /// 属性对应buffID
    /// </summary>
    int[] attributeList = { 0, 5, 3, 4, 2, 6, 9 };

    /// <summary>
    /// 随机值的概率,由低到高
    /// </summary>
    float[] possibility = { 0.6f, 0.9f, 1f };

    public override void Awake()
    {
        base.Awake();
       // RoomElementID = 17 + (int)altarType;
    }

    void Start()
    {
        if (isRandom)
            RandomBuff();
    }

    /// <summary>
    /// 给予buff
    /// </summary>
    public void AddBuff()
    {


        Player.Instance.GetComponent<BuffManager>().CreateDifferenceBuff((buffValue * 10 + attributeList[buffAttri - 1]) * 10000000 + 0301110, "Altar");
        if (altarType == Type.evil)
            Player.Instance.gameObject.AddComponent<GiveBuff>().Create(((-debuffValue) * 100 + 10 + attributeList[debuffAttri - 1]) * 1000 + 001, 3, 1, "Altar");


    }

    /// <summary>
    /// 随机分配buff算法
    /// </summary>
    public void RandomBuff()
    {
        float rand = Random.value;
        if (rand < possibility[0])
            buffValue = 1;
        else if (rand < possibility[1])
            buffValue = 2;
        else
            buffValue = 3;


        if (altarType == Type.normal)
        {
            buffAttri = Random.Range(2, 8);


        }
        else
        {
            buffAttri = Random.Range(2, 7);
            buffValue += 1;
            debuffAttri = Random.Range(1, 8);
            debuffValue = -1;
        }
    }

    /// <summary>
    /// 进入祭坛
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (RoomElementState == 1)
            return;
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.Character.AddObserver(this);
            RoomManager.Instance.Notify("EnterAltar;" + (int)altarType + ";" + buffAttri + ";" + buffValue + ";" + debuffAttri + ";" + debuffValue);
        }
    }

    /// <summary>
    /// 离开祭坛
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RoomManager.Instance.Notify("LeaveAltar");
            Player.Instance.Character.RemoveObserver(this);
        }
    }


    public override void CloseAttackEvent()
    {
		if (RoomElementState == 1)
			return;
        base.CloseAttackEvent();
        AddBuff();
        RoomElementState = 1;
        Notify("UseAltar");
    }


}

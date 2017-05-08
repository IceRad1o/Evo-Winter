using UnityEngine;
using System.Collections;

public class Altar2 : RoomElement {

	public int attribute;
	public int increase;
	public override void Awake()
	{
		base.Awake();
		RoomElementID = 18;
	}
	
	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			attribute = Random.Range (1,8);
			increase = Random.Range (1,4);
			RoomManager.Instance.Notify("EnterAltar;2;"+attribute+";"+increase);
            Player.Instance.GetComponent<Character>().AddObserver(this);
		}

	}

	//调用函数
	public void AddBuff()
	{
        int[] attributeList = { 0, 5, 2, 4, 3, 6 };
        Player.Instance.GetComponent<BuffManager>().CreateDifferenceBuff((increase * 100 + attributeList[attribute-1]) * 10000000 + 0301110,"Altar");
	}

	//离开
	private void OnTriggerExit(Collider other)
	{
		RoomManager.Instance.Notify ("LeaveAltar");
        Player.Instance.GetComponent<Character>().RemoveObserver(this);
	}

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "AttackStart" && UtilManager.Instance.GetFieldFormMsg(msg, 0) == "J")
        {
            AddBuff();
        }

    }
}

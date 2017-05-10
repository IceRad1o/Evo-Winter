using UnityEngine;
using System.Collections;

public class Altar1 : RoomElement{
	public int attribute1,attribute2;
	public int change1,change2;
	public override void Awake()
	{
		base.Awake();
		RoomElementID = 17;
	}



	//调用函数
	public void AddBuff()
	{

        int[] attributeList = { 0, 5, 2, 4, 3, 6, 9 };
        Player.Instance.GetComponent<BuffManager>().CreateDifferenceBuff((change1 * 10 + attributeList[attribute1-1]) * 10000000 + 0301110,"Altar");

        Player.Instance.gameObject.AddComponent<GiveBuff>().Create(((-change2)*100+10+attributeList[attribute2-1])*1000+001, 3, 1,"Altar");
        Notify("UseAltar");

    }

	//离开
    private void OnCollisionExit(Collision collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            RoomManager.Instance.Notify("LeaveAltar");
           // Player.Instance.GetComponent<Character>().RemoveObserver(this);
        }
	}

    public override void OnNotify(string msg)
    {
        //Debug.Log("Msg      " + msg);
        base.OnNotify(msg);
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "AttackStart" && UtilManager.Instance.GetFieldFormMsg(msg, 0) == "J")
        {
            AddBuff();
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if( collision.gameObject.tag == "Player")
		{            
			attribute1 = Random.Range (1,8);
			change1 = Random.Range (1,4);
			attribute2 = Random.Range (1,8);
			change2 = Random.Range (-1,-4);
			RoomManager.Instance.Notify("EnterAltar;1;"+attribute1+";"+change1+";"+attribute2+";"+change2);
		}
    }
}

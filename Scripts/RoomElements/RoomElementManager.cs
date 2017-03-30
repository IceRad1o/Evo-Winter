using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RoomElementManager : ExUnitySingleton<RoomElementManager>
{
    List<RoomElement> roomElementList = new List<RoomElement>();
    public List<RoomElement> RoomElementList
    {
        get { return roomElementList; }
        set { roomElementList = value; }
    }

    public GameObject[] missile;


	void Start () {

        Player.Instance.Character.AddObserver(this);
    }

    public override void OnNotify(string msg)
    {
        string content = UtilManager.Instance.GetMsgField(msg, 0);
        string [] str = UtilManager.Instance.GetMsgFields(msg);
        //Debug.Log("REMmsg："+msg);
        if (content == "GenerateMissile")
        {
            //float direct = float.Parse(UtilManager.Instance.GetMsgField(msg, 1));
            //int flyPath = int.Parse(UtilManager.Instance.GetMsgField(msg, 4));
          
            //Debug.Log("flypath;"+flyPath);
            //int direction;
            //if (Player.Instance.Character.FaceDirection > 0)
            //{
            //    direction = 1;
            //}
            //else
            //{
            //    direction = -1;
            //}



            //GameObject missileInstance = Instantiate(missile[0], Player.Instance.Character.transform.position, Quaternion.identity) as GameObject;

            //Debug.Log("Missile飞行路径:" +  flyPath);
            //missileInstance.GetComponent<Missiles>().InitMissiles(7.5f, 5f, 0, direction, 1, flyPath);
            //missileInstance.GetComponent<Missiles>().Fly();
        }

    }
	
	void Update () {

	}



    public void ClearAll()
    {
        for (int i = 0; i < roomElementList.Count; i++)
        {
            Destroy(roomElementList[i].gameObject);
        }
        RoomElementList.Clear();      
    }
}

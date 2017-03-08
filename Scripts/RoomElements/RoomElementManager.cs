using UnityEngine;
using System.Collections;

public class RoomElementManager : UnitySingleton<RoomElementManager>
{

    public GameObject m_Missile;
    public int numberOfMissile;
    public static int direction;
    public static int pathNumber;
	// Use this for initialization
	void Start () {
        
        //direction = -1;
        //pathNumber = 1;
        numberOfMissile = 0;
        Player.Instance.Character.AddObserver(playerObserver);
    }

    PlayerObserver playerObserver = new PlayerObserver(); //Player的观察者
    class PlayerObserver : Observer
    {
        public override void OnNotify(string msg)
        {
            string content = UtilManager.Instance.GetMsgField(msg, 0);
            //Debug.Log("msg："+msg);
            if (content== "GenerateMissile")
            {
                float direct = float.Parse(UtilManager.Instance.GetMsgField(msg, 1));
                pathNumber = int.Parse(UtilManager.Instance.GetMsgField(msg, 4));

                if (direct > 0) direction = 1;
                else direction = -1;

                RoomElementManager.Instance.Fire();
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    Fire();
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    direction = -1;
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    direction = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (pathNumber == 1)
        //        pathNumber = 2;
        //    else if (pathNumber == 2)
        //        pathNumber = 3;
        //    else if (pathNumber == 3)
        //        pathNumber = 1;
        //}
	}

    public void Fire()
    {

        //Debug.Log("进入Fire()");
        GameObject missileInstance =
               Instantiate(m_Missile, Player.Instance.Character.transform.position, Quaternion.identity) as GameObject;
        if (numberOfMissile <100)
        {
            missileInstance.GetComponent<Missile>().SetDirection(direction);
            missileInstance.GetComponent<Missile>().SetFlyPath(pathNumber);
            missileInstance.GetComponent<Missile>().StartMove(7.5f, 80f);
        }
        else
        {       
            numberOfMissile = 0;
        }
        
        numberOfMissile++;
        //Debug.Log("发射物数量：" + numberOfMissile);
        //Debug.Log("退出Fire()");
    }
}

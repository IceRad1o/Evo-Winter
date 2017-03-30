using UnityEngine;
using System.Collections;

public class Esscence : RoomElement {

    int esscenceID;
    public Sprite[] spriteArray;


    bool playerIn = false;

    public void Create(int ID) 
    {
        esscenceID = ID;
        GetComponent<SpriteRenderer>().sprite=spriteArray[esscenceID];   
    }

    void PlayerGet() 
    {
        Notify("Get_Esscence;" + esscenceID);
        Destroy(gameObject);
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
        if (str[0] == "AttackStart")
        {
            PlayerGet();
        }
    }
	
}

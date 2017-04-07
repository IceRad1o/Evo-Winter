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

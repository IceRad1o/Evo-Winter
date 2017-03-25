using UnityEngine;
using System.Collections;

public class RoomElement : ExSubject {

    int roomElementID;
    /*
     * 
     * 
     * 
     * 
     * */
    public int RoomElementID
    {
        get { return roomElementID; }
        set { roomElementID = value; }
    }

    int health;

    public  int Health
    {
        get { return health; }
        set { health = value; }
    }

	public virtual void Awake () {
        health = 1;
        RoomElementManager.Instance.RoomElementList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Destroy()
    {
        RoomElementManager.Instance.RoomElementList.Remove(this);
        Destroy(this.gameObject);
    }
}

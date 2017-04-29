using UnityEngine;
using System.Collections;

public class RoomElement : ExSubject {

    public int roomElementID;
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
     * */
    public int RoomElementID
    {
        get { return roomElementID; }
        set { roomElementID = value; }
    }



	public virtual void Awake () {
        //health = 1;
        this.tag = "RoomElement";
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

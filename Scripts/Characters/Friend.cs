using UnityEngine;
using System.Collections;

public class Friend : Character{

	// Use this for initialization
	public override void Start () {
        base.Start();
        this.tag = "Friend";
        FriendManager.Instance.FriendList.Add(this);
	}

    public override void Die()
    {
        base.Die();
        FriendManager.Instance.FriendList.Remove(this);
    }
    
}

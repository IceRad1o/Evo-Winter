using UnityEngine;
using System.Collections;

public class Friend : Character{

	// Use this for initialization
	public override void Awake () {
        base.Awake();
        this.tag = "Friend";
        FriendManager.Instance.FriendList.Add(this);
	}

    public override void Die()
    {
        FriendManager.Instance.FriendList.Remove(this);
        base.Die();
   
    }
    
}

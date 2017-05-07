using UnityEngine;
using System.Collections;

public class Handle : RoomElement {

	private Animator animator;
	private bool isOn;
	public GameObject dart;

	void Start()
	{
		animator = this.GetComponent<Animator> ();
		isOn = false;
	}
	public override void Awake()
	{
		base.Awake ();
		roomElementID = 22;
	}

	//碰撞检测
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("开关");
		if (other.tag == "Player") 
		{
			animator.SetTrigger ("switchOn");
			isOn = true;
			SwitchOn (other);
		}

	}

	void SwitchOn(Collider other)
	{
		RoomManager.Instance.hiddenDoor = true;

		int dir = other.GetComponent<Character>().FaceDirection;
		Vector3 pos = other.GetComponent<Character>().transform.position;
		GameObject d=Instantiate(dart, new Vector3(-dir*14, pos.y,pos.z ), Quaternion.identity) as GameObject;
		d.GetComponent<Missiles>().direction = dir;

	}

	//离开
	private void OnTriggerExit(Collider other)
	{
		Notify ("LeaveAltar");
	}
}

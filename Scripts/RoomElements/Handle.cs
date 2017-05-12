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
			Trap1(other);
			OpenHiddenDoor();
		}

	}
	//触发陷阱1
	void Trap1(Collider other)
	{

		Vector3[] posi = {
			new Vector3 (other.transform.position.x, other.transform.position.y+1f, other.transform.position.z+1f),
			new Vector3 (other.transform.position.x, other.transform.position.y-1f, other.transform.position.z-1f),
			new Vector3 (other.transform.position.x, other.transform.position.y, other.transform.position.z)};
		for (int i = 0; i < 3; i++) 
		{
			int dir = other.GetComponent<Character>().FaceDirection;
			Vector3 pos = posi [i];
			GameObject d=Instantiate(dart, new Vector3(-dir*14, pos.y,pos.z ), Quaternion.identity) as GameObject;
			d.GetComponent<Missiles>().direction = dir;
		}
	}
	//打开隐藏门
	void OpenHiddenDoor()
	{
		if (RoomManager.Instance.hiddenDoor == false) 
		{
			RoomManager.Instance.hiddenDoor = true;
		}

	}

}

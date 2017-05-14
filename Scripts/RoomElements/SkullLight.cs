using UnityEngine;
using System.Collections;

public class SkullLight : RoomElement {

	private Collision coll;
    public Animator animator;
    public AudioClip putOut;
    public override void Awake()
    {
        base.Awake();
        RoomElementID = 9;

	}

    void Start()
    {
        animator = GetComponent<Animator>();
    }


	void Update () {
	
	}
		
	//碰撞检测
	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("SkullEnterTag:"+collision.gameObject.tag);
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify("EnterSkull");
		}
		coll = collision;
	}

	void OnCollisionExit(Collision collision)
	{
		//Debug.Log ("SkullLeaveTag:"+collision.gameObject.tag);
		RoomManager.Instance.Notify("LeaveSkull");
		if (collision.gameObject.tag == "Player")
		{
			Player.Instance.Character.RemoveObserver(this);
		}
	}
	//重载函数
	public override void Trriger()
	{
		//Debug.Log ("EnterTrigger");
		if (RoomElementState == 1)
			return;
		base.Trriger();
		HitScull (coll);
		RoomElementState = 1;
	}

	//动画
	private void HitScull(Collision collision)
	{
		//Debug.Log ("HitSkull_State:"+RoomElementState+", _coll:"+collision);
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Player.Instance.Character.FaceDirection < 0) animator.SetTrigger("destory");
			else animator.SetTrigger("destory2");
		}
		if (collision.gameObject.CompareTag("Missile")) 
		{
			if(collision.gameObject.transform.position.x - this.transform.position.x>0)
				animator.SetTrigger("destory");
			else
				animator.SetTrigger("destory2");
		}

	}
	//声音
    void Sound()
    {
        SoundManager.Instance.PlaySoundEffect(putOut);
    }

}

using UnityEngine;
using System.Collections;

public class Bottle1 : RoomElement
{
    private Animator animator;
    private bool isHit;
    public AudioClip hit;
	public GameObject coin;
    public override void Awake()
    {
        base.Awake();
       // RoomElementID = 10;
        this.tag = "DynamicGroundElement";
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false;
		if(RoomElementState== 1) animator.SetTrigger("Hit");
        //NEED SoundManager.instance.PlaySingle(getBox);
    }

	//进入瓶子
	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("BottleTagState:"+this.RoomElementState);
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify("EnterBottle");
		}
	}

	//离开瓶子
	void OnCollisionExit(Collision collision)
	{
		RoomManager.Instance.Notify("LeaveBottle");
		if (collision.gameObject.tag == "Player")
		{
			Player.Instance.Character.RemoveObserver(this);
		}
	}
	//重载函数
	public override void CloseAttackEvent()
	{
		if (RoomElementState == 1)
			return;
		base.CloseAttackEvent();
		RoomElementState = 1;
		Notify("OpenBottle");

		HitBottle();
		if(Random.Range (0,10) < 5)
		{
			CreateCoin ();
		}
	}

    void HitBottle()
    {
        if (animator == null)
            return;
        SoundManager.Instance.PlaySoundEffect(hit);
        animator.SetTrigger("Hit");
        isHit = true;
        RoomElementState = 1;
    }

	void CreateCoin()
	{
		CoinManager.Instance.CreateCoin (1, this.transform.position);
	}
}
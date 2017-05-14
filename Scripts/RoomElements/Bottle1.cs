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
        RoomElementID = 10;
        this.tag = "DynamicGroundElement";
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false;
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
	public override void Trriger()
	{
		if (RoomElementState == 1)
			return;
		base.Trriger();
		RoomElementState = 1;
		Notify("OpenBottle");

		HitBottle();
		if(Random.Range (0,10) <2)
		{
			CreateCoin ();
		}
	}

    void HitBottle()
    {
        SoundManager.Instance.PlaySoundEffect(hit);
        animator.SetTrigger("Hit");
        isHit = true;
        RoomElementState = 1;
    }

	void CreateCoin()
	{
		//GameObject myCoin = Instantiate(coin, this.transform.position, Quaternion.identity) as GameObject;
	}
}
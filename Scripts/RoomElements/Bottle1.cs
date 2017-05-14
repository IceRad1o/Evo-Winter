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


//    private void OnTriggerEnter(Collider other)
//    {
//        //Debug.Log("箱子碰撞物标签：" + other.tag);
//		if (other.CompareTag("Weapon"))
//		if (other.GetComponentInParent<Character>().IsWeaponDmg > 0 && isHit == false && other.GetComponentInParent<Character>().CompareTag("Player"))
//            {
//                HitBottle();
//				if(Random.Range (0,10) <2)
//				{
//					CreateCoin ();
//            	}
//			}
//
//		if(other.tag == "Missile")
//			HitBottle();
//    }

	//进入瓶子
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("BottleTag:"+collision.gameObject.tag);
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify("EnterBottle");
			//Debug.Log ("BottleTag:"+other.tag);
		}
		if ((collision.gameObject.CompareTag ("Missile"))) 
			//&&other.GetComponent<RoomElement> ().Master.CompareTag ("Player")))
		{
			Player.Instance.Character.AddObserver(this);
			//RoomManager.Instance.Notify("MissileEnterBottle");
			Debug.Log ("BottleTag:"+collision.gameObject.tag);
		}
	}

	//离开瓶子
	void OnCollisionExit(Collision collision)
	{
		RoomManager.Instance.Notify("LeaveBottle");
		if (collision.gameObject.tag == "Player")
		{
			Player.Instance.Character.RemoveObserver(this);
			Debug.Log ("LeaveBottleTag:"+collision.gameObject.tag);
		}
	}
	//重载函数
	public override void Trriger()
	{
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
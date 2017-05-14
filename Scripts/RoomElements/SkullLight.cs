using UnityEngine;
using System.Collections;

public class SkullLight : RoomElement {

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
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Weapon")
//        {
//            if (other.GetComponentInParent<Character>().IsWeaponDmg > 0 && other.GetComponentInParent<Character>().Camp == 0)
//            {
//              
//                if (Player.Instance.Character.FaceDirection < 0) animator.SetTrigger("destory");
//                else animator.SetTrigger("destory2");
//            }
//            else
//            {
//                
//            }
//        }
//		if (other.tag == "Missile") 
//		{
//			if(other.transform.position.x - this.transform.position.x>0)
//				animator.SetTrigger("destory");
//			else
//				animator.SetTrigger("destory2");
//		}
//
//    }

	//碰撞检测
	private void OnCollisionEnter(Collision collision)
	{
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify("HitSkull");
		}
	}

	void OnCollisionExit(Collision collision)
	{
		RoomManager.Instance.Notify("LeaveSkull");
		if (collision.gameObject.tag == "Player")
		{
			Player.Instance.Character.RemoveObserver(this);
		}
	}

	//动画
	private void HitScull(Collision collision)
	{
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

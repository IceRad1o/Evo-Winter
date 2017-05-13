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


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("箱子碰撞物标签：" + other.tag);
        if (other.tag == "Weapon")
            if (other.GetComponentInParent<Character>().IsWeaponDmg > 0 && isHit == false && other.GetComponentInParent<Character>().tag =="Player")
            {
                HitBottle();
				if(Random.Range (0,10) <2)
				{
					CreateCoin ();
            	}
			}

		if(other.tag == "Missile")
			HitBottle();
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
using UnityEngine;
using System.Collections;

public class SkullLight : RoomElement {

    public Animator animator;
    private int isBroken;
    public AudioClip putOut;
    public override void Awake()
    {
        base.Awake();
        RoomElementID = 9;
	}

    void Start()
    {
        animator = GetComponent<Animator>();
        isBroken = 0;
    }


	void Update () {
	
	}

        //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            if (other.GetComponentInParent<Character>().IsWeaponDmg > 0 && isBroken == 0 && other.GetComponentInParent<Character>().Camp == 0)
            {
              
                if (Player.Instance.Character.FaceDirection < 0) animator.SetTrigger("destory");
                else animator.SetTrigger("destory2");
                isBroken = 1;
            }
            else
            {
                
            }
        }

    }

    void Sound()
    {
        SoundManager.Instance.PlaySoundEffect(putOut);
    }

}

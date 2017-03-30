using UnityEngine;
using System.Collections;

public class Bottle1 : RoomElement
{
    private Animator animator;
    private bool isHit;
    public AudioClip hit;
    public override void Awake()
    {
        base.Awake();
        RoomElementID = 10;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false;
        //NEED SoundManager.instance.PlaySingle(getBox);
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("箱子碰撞物标签：" + other.tag);
        if (other.tag == "Weapon")
            if (other.GetComponentInParent<Character>().IsWeaponDmg > 0 && isHit == false && other.GetComponentInParent<Character>().Camp == 0)
            {
                HitBottle();
            }
    }

    void HitBottle()
    {
        SoundManager.Instance.PlaySoundEffect(hit);
        animator.SetTrigger("Hit");
        isHit = true;
    }
}
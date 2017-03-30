using UnityEngine;
using System.Collections;

public class Trap : RoomElement
{

    //NEED public AudioClip appearTrap; 
    //NEED public AudioClip touchTrap;
    private int damage;


    public override void Awake()
    {
        base.Awake();
        RoomElementID = 15;
        damage = 1;
        //NEED SoundManager.instance.PlaySingle(appearTrap);
    }


    void PlaySoundOfTouchTrap()
    {
        //NEED SoundManager.instance.PlaySingle(touchTrap);
    }

    //private void OnColliderEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("陷阱碰撞物标签：" + other);
        if (other.tag == "Player" || other.tag == "Monster")
        {
            //this.GetComponent<Collider>().isTrigger = false;
            PlaySoundOfTouchTrap();
            //StartCoroutine(Wait(0.4f));
            //this.GetComponent<Collider>().isTrigger = true;
        }           
    }

    //等待延迟
    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}


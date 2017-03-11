using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{

    //NEED public AudioClip appearTrap; 
    //NEED public AudioClip touchTrap;
    private int damage;


    void Awake()
    {
        damage = 1;
        //NEED SoundManager.instance.PlaySingle(appearTrap);
    }


    void Update()
    {

    }

    //获取陷阱伤害，Player进行碰撞检测成功时调用自身SubHealth(damage)函数进行减血
    int GetDamage()
    {
        return damage;
    }

    void PlaySoundOfTouchTrap()
    {
        //NEED SoundManager.instance.PlaySingle(touchTrap);
    }

    
}


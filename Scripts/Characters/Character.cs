﻿using UnityEngine;
using System.Collections;

public class Character:Subject
{
    public GameObject gnome;

    public AudioClip attackingSound;
    public AudioClip movingSound;
    public AudioClip dyingSound;
    public AudioClip damagingSound;


    private float health;

    public float Health
    {
        get { return health; }
        set 
        {
            if (value < health)
                SoundManager.Instance.PlaySoundEffect(damagingSound);
            health = value;
            if (health == 0)
            {
                Die();
            }
            Notify("HealthChanged");
            
        }
    }
    private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set 
        { 
            moveSpeed = value;
            AnimationController ac = GetComponent<AnimationController>();
            ac.ChangeAnimationSpeed("Move", moveSpeed*20);
            Notify("MoveSpeedChanged");
        }
    }
    private float attackSpeed;

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set 
        {   
            attackSpeed = value;
            actionStateMachine.IntervalTime = 0.05f/attackSpeed;
            AnimationController ac = GetComponent<AnimationController>();
            ac.ChangeAttackAnimationsSpeed(attackSpeed);
            Notify("AttackSpeedChanged");
        }
    }
    private float attackRange;

    public float AttackRange
    {
        get { return attackRange; }
        set 
        { 
            attackRange = value;
            Notify("AttackRangeChanged");
        }
    }
    private float attackDamage;

    public float AttackDamage
    {
        get { return attackDamage; }
        set 
        { 
            attackDamage = value;
            Notify("AttackDamageChanged");
        }
    }
    private float hitRecover;//硬直,即受击回复，影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短

    public float HitRecover
    {
        get { return hitRecover; }
        set 
        { 
            hitRecover = value;
            Notify("HitRecoverChanged");
        }
    }
    private float spasticity;//僵直,自身僵直度越高，那么对手或者地下城的怪物收到攻击后的呆滞时间就越长

    public float Spasticity
    {
        get { return spasticity; }
        set 
        { 
            spasticity = value;
            Notify("SpasticityChanged");
        }
    }

    private int race;

    public int Race
    {
        get { return race; }
        set 
        { 
            race = value;
            Notify("RaceChanged");
        }
    }
    private int weapon;

    public int Weapon
    {
        get { return weapon; }
        set 
        { 
            weapon = value;
            Notify("WeaponChanged");
        }
    }

    //NEED private SkillManager skillManager;
    //NEED private BuffManager buffManager;

    private int isAlive;//<0 死透 =0 正在死 >0 活着

    public int IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }
    private int camp;

    public int Camp
    {
        get { return camp; }
        set { camp = value; }
    }

    private ActionStateMachine actionStateMachine;

    public ActionStateMachine ActionStateMachine
    {
        get { return actionStateMachine; }
        set { actionStateMachine = value; }
    }

    private int canMove;    //能否移动

    public int CanMove
    {
        get { return canMove; }
        set 
        { 
            canMove = value;
            Notify("canMoveChanged");
        }
    }


    private int state;// 0=静止 1=移动

    public int State
    {
        get { return state; }
        set
        {
            if (state != value)
            {
                if (CanMove == 0 && value == 1)
                    return;
                state = value;
                actionStateMachine.Push(4 * state);
            }

        }
    }

    private int isWeaponDmg; //0=无伤害 1=武器有伤害

    public int IsWeaponDmg
    {
        get { return isWeaponDmg; }
        set 
        { 
            isWeaponDmg = value;
            if (value == 0)
                Notify("WeaponDmg");
            else
                Notify("WeaponDontDmg");
        }
    }



    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            Vector3 temp = gameObject.GetComponent<Transform>().localScale;
            if (value.x * temp.x > 0)
                temp.x = -temp.x;
            gameObject.GetComponent<Transform>().localScale = temp;

            direction = value;
            Notify("DirectionChanged");
        }
    }

    public virtual void Move()
    {
        transform.position +=direction * moveSpeed;
        Notify("Move");
     
    }

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {
        actionStateMachine.Push(5);
        isAlive = -1;
        Notify("Die");
    }

    bool CheckSurvivalTime()
    {
        return false;
    }

    public virtual void NormalAttack()
    {
        state = 0;
        CanMove = 0;
        actionStateMachine.Push(1);
    }

    public virtual void SpecialAttack()
    {
        actionStateMachine.Push(2);
    }

    public virtual void UseRaceSkill()
    {

        actionStateMachine.Push(3);
        //Instantiate(gnome, transform.position, transform.rotation);
        //Instantiate(gnome, transform.position, transform.rotation);
        
    }

    protected virtual void Start()
    {

        state = 0;
        moveSpeed = 0.05f;
        attackSpeed = 1.0f;
        health = 3;
        isAlive = 1;
        canMove = 1;
  
    }

    public virtual void FixedUpdate()
    {
        if(state==1)
        {
            Move();
           
        }
      
    }


    public void PlaySound(AudioClip clip)
    {
        SoundManager.Instance.PlaySoundEffect(clip);
    }

    public void Awake()
    {
        actionStateMachine = new ActionStateMachine();
        actionStateMachine.Character = this;
    }




}

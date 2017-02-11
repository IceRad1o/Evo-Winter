using UnityEngine;
using System.Collections;

public class Character:Subject
{


    private float health;

    public float Health
    {
        get { return health; }
        set 
        {
            health = value;
            if (health == 0)
                Die();

            //只有player才notify
            if(tag=="Player")
                 Notify("HealthChanged");
            
        }
    }
    private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    private float attackSpeed;

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    private float attackRange;

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
    private float attackDamage;

    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }
    private float hitRecover;//硬直,即受击回复，影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短

    public float HitRecover
    {
        get { return hitRecover; }
        set { hitRecover = value; }
    }
    private float spasticity;//僵直,自身僵直度越高，那么对手或者地下城的怪物收到攻击后的呆滞时间就越长

    public float Spasticity
    {
        get { return spasticity; }
        set { spasticity = value; }
    }

    private int race;

    public int Race
    {
        get { return race; }
        set { race = value; }
    }
    private int weapon;

    public int Weapon
    {
        get { return weapon; }
        set { weapon = value; }
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

    private int state;// 0=静止 1=移动

    public int State
    {
        get { return state; }
        set
        {
            if (state != value)
            {
                state = value;
                actionStateMachine.Push(4 * state);
            }

        }
    }

    private int isWeaponDmg; //0=无伤害 1=武器有伤害

    public int IsWeaponDmg
    {
        get { return isWeaponDmg; }
        set { isWeaponDmg = value; }
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
        }
    }

    public virtual void Move()
    {
        gameObject.GetComponent<Transform>().position += direction * moveSpeed;
    }

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {
        //Debug.Log("DiediediediedieDiediediediedie");
        actionStateMachine.Push(5);
        isAlive = -1;
    }

    bool CheckSurvivalTime()
    {
        return false;
    }

    public virtual void NormalAttack()
    {
        actionStateMachine.Push(1);
    }

    public virtual void SpecialAttack()
    {
        actionStateMachine.Push(2);
    }

    public virtual void UseRaceSkill()
    {
        actionStateMachine.Push(3);
    }

    protected virtual void Start()
    {
        state = 0;
        moveSpeed = 0.05f;
        health = 3;
        isAlive = 1;
  
    }

    public virtual void Update()
    {
        if(state==1)
        {
          
            Move();
           
        }
      
    }

    public void Awake()
    {
        actionStateMachine = new ActionStateMachine();
        actionStateMachine.Character = this;
    }

    void OnNotify()
    {
        Debug.Log("notify");
    }
}

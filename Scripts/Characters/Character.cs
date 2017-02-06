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
            Notify("HealthChanged");
        }
    }
    private float moveSpeed;
    private float attackSpeed;
    private float attackRange;
    private float attackDamage;
    private float hitRecover;//硬直,即受击回复，影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短
    private float spasticity;//僵直,自身僵直度越高，那么对手或者地下城的怪物收到攻击后的呆滞时间就越长

    private int race;
    private int weapon;

    //NEED private SkillManager skillManager;
    //NEED private BuffManager buffManager;

    private int isAlive;//<0 死透 =0 正在死 >0 活着
    private int camp;
    private ActionStateMachine actionStateMachine;

    private int state;
    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
        set 
        {
        

               Vector3 temp= gameObject.GetComponent<Transform>().localScale;
               if(value.x*temp.x>0)
                 temp.x = -temp.x;
               gameObject.GetComponent<Transform>().localScale = temp;
               // = gameObject.GetComponent<Transform>().localScale+new Vector3(-1,1,1);
        
          
            direction = value;
        }
    }
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
    public virtual void Move()
    {     
        gameObject.transform.position += direction * moveSpeed;
       
    }

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {

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
        Debug.Log("Character start");
        state = 0;
        moveSpeed = 0.02f;
        actionStateMachine = new ActionStateMachine();
        actionStateMachine.Character = this;
    }

    public virtual void Update()
    {
        if(state==1)
        {
           // Debug.Log("update移动");
            Move();
           
        }
      
    }


    void OnNotify()
    {
        Debug.Log("notify");
    }
}

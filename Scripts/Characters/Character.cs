using UnityEngine;
using System.Collections;

public class Character : UnitySingleton<Character>
{

    private float health;
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
   // private ActionStateMachine actionStateMachine;

    private int state;
    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    public int State
    {
        get { return state; }
        set { state = value; }
    }
    public virtual void Move()
    {
        Debug.Log("move前"+gameObject.transform.position);
        
        gameObject.transform.position += direction * moveSpeed;
        Debug.Log("move后" + gameObject.transform.position);
        
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

    }

    public virtual void SpecialAttack()
    {

    }

    public virtual void UseRaceSkill()
    {

    }

    void Start()
    {
        state = 0;
        moveSpeed = 0.1f;
    }

    public virtual void Update()
    {
        Debug.Log("update进入");
        if(state==1)
        {
            Debug.Log("update移动");
            Move();
        }
    }
}

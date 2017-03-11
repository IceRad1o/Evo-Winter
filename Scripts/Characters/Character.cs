using UnityEngine;
using System.Collections;

public class Character : ExSubject
{
    //音频
    public AudioClip attackingSound;
    public AudioClip movingSound;
    public AudioClip dyingSound;
    public AudioClip damagingSound;

    Animator anim;

    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }

    private int characterID;

    public int CharacterID
    {
        get { return characterID; }
        set { characterID = value; }
    }
    //Player基本属性
    private float health;   //生命
    private float moveSpeed;    //移速
    private int moveSpeedTmp;    //移速
    private float attackSpeed;  //攻速
    private int attackSpeedTmp; //攻速
    private float attackRange;  //攻击范围
    private float attackDamage; //攻击伤害
    private float hitRecover;//硬直,即受击回复，影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短
    private float spasticity;//僵直,自身僵直度越高，那么对手收到攻击后的呆滞时间就越长
    private int luck; //幸运 影响技能触发几率和道具掉落概率

    public float Health
    {
        get { return health; }
        set
        {
            float temp = health;
            if (value < health)
            {
                actionStateMachine.Push(6);
            }
            health = value;
            if (health == 0)
            {
                Die();
            }
            Notify("HealthChanged");

        }
    }
 
    public float MoveSpeedIn
    {
        
        get { return moveSpeed; }
        set
        {
            moveSpeed = value;
            //AnimationController ac = GetComponent<AnimationController>();
            //ac.ChangeAnimationSpeed("Move", moveSpeed * 20);
            Notify("MoveSpeedChanged");
        }
    }


    public int MoveSpeed
    {
        get 
        {
            return moveSpeedTmp;
        }
        set 
        {
            moveSpeedTmp=value;
            float temp = 0;
            if (value == 1)
                temp = 0.05f;
            if (value == 2)
                temp = 0.08f;
            if (value == 3)
                temp = 0.1f;
            if (value == 4)
                temp = 0.12f;
            if (value >= 5)
                temp = 0.15f;
            MoveSpeedIn = temp ;
        }
    }

    public float AttackSpeedIn
    {
        get { return attackSpeed; }
        set
        {
            attackSpeed = value;
            //actionStateMachine.IntervalTime = f;
            //AnimationController ac = GetComponent<AnimationController>();
            //ac.ChangeAttackAnimationsSpeed(attackSpeed);
            Notify("AttackSpeedChanged");
        }
    }
    public int AttackSpeed
    {
        get
        {
            return attackSpeedTmp;
        }
        set
        {
            float temp = 0;
            if (value == 1)
                temp = 0.5f;
            if (value == 2)
                temp = 0.8f;
            if (value == 3)
                temp = 1f;
            if (value == 4)
                temp = 1.2f;
            if (value >= 5)
                temp = 1.4f;
            moveSpeedTmp = value;
            AttackSpeedIn = temp;
        }
    }


    public float AttackRange
    {
        get { return attackRange; }
        set
        {
            attackRange = value;
            Notify("AttackRangeChanged");
        }
    }


    public float AttackDamage
    {
        get { return attackDamage; }
        set
        {
            attackDamage = value;
            Notify("AttackDamageChanged");
        }
    }
 

    public float HitRecover
    {
        get { return hitRecover; }
        set
        {
            hitRecover = value;
            Notify("HitRecoverChanged");
        }
    }
   

    public float Spasticity
    {
        get { return spasticity; }
        set
        {
            spasticity = value;
            Notify("SpasticityChanged");
        }
    }

    private int race;   //种族

    public int Race
    {
        get { return race; }
        set
        {
            race = value;
            Notify("RaceChanged");
        }
    }
    private int weapon; //武器类型

    public int Weapon
    {
        get { return weapon; }
        set
        {
            weapon = value;
            Notify("WeaponChanged");
        }
    }

    private int sight;  //视野 影响可见范围,若玩家处于怪物的视野外则不会遭受攻击

    public int Sight
    {
        get { return sight; }
        set
        {
            sight = value;
            Notify("SightChanged");
        }
    }

   

    public int Luck
    {
        get { return luck; }
        set
        {
            luck = value;
            Notify("LuckChanged");
        }
    }

    //NEED private SkillManager skillManager;
    //NEED private BuffManager buffManager;

    private int isAlive;//<0 死透 =0 正在死 >0 活着

    public int IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;

        }
    }
    private int camp;   //阵营 0=友方 1=敌方

    public int Camp
    {
        get { return camp; }
        set
        {
            camp = value;
            Notify("CampChanged");

        }
    }

    private ActionStateMachine actionStateMachine;

    public ActionStateMachine ActionStateMachine
    {
        get { return actionStateMachine; }
        set { actionStateMachine = value; }
    }

    private int canMove;    //能否移动

    //PROBLEM 值不停的在改变
    public int CanMove
    {
        get { return canMove; }
        set
        {
            canMove = value;
            Notify("CanMoveChanged");
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
                //Debug.Log("current state:" + state + " to " + value);
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
        transform.position += direction * moveSpeed;
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

   public virtual void Start()
    {

        state = 0;
        MoveSpeed = 1;
        AttackSpeed = 1;
        health = 3;
        isAlive = 1;
        canMove = 1;
        anim = this.GetComponent<Animator>();
    }

    public virtual void FixedUpdate()
    {
        if (state == 1)
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


    public void Disappear()
    {
        Destroy(this.gameObject);
    }
    /// <summary>
    /// 发送生成发射物的通知
    /// </summary>
    public void NotifyMissile()
    {
        Notify("GenerateMissile;" + Direction.x + ";" + Direction.y + ";"+ Direction.z + ";" + 1);
    }

    /// <summary>
    /// 更新动画速度
    /// </summary>
    public void UpdateAnimSpeed()
    {
        AnimatorStateInfo asi = Anim.GetCurrentAnimatorStateInfo(0);

        if (asi.IsName("AttackJ") || asi.IsName("AttackJJ") || asi.IsName("AttackJJJ") || asi.IsName("AttackK") || asi.IsName("AttackL"))
        {
            Anim.speed = AttackSpeedIn;
        }
        if (asi.IsName("Move"))
        {
            Anim.speed = moveSpeed*10;
            //character.Anim.speed = character.MoveSpeed;
        }
        if (asi.IsName("Idle") )
        {
            Anim.speed = 1;
        }
    }

}

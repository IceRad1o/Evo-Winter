using UnityEngine;
using System.Collections;

public class Character : RoomElement
{
    //音频
    public AudioClip attackingSound;
    public AudioClip attackingSound2;
    public AudioClip attackingSound3;
    public AudioClip movingSound;
    public AudioClip dyingSound;
    public AudioClip damagingSound;

    Animator anim;
    GameObject weaponObj;
    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }



    public int CharacterID
    {
        get { return characterID; }
        set { characterID = value; }
    }
    //Player基本属性
    private int characterID;
    private float health;   //0.生命
    private int healthTmp;   //0.生命
    private float moveSpeed;    //1.移速
    private int moveSpeedTmp;    //移速-int
    private float attackSpeed;  //2.攻速
    private int attackSpeedTmp; //攻速-int
    private float attackRange;  //3.攻击范围
    private int attackRangeTmp;//攻击范围-int
    private float attackDamage; //4.攻击伤害
    private int attackDamageTmp; //攻击伤害-int
    private float hitRecover;//5.硬直,即受击回复，影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短
    private int hitRecoverTmp;//
    private float luck;
    private int luckTmp; //6.幸运 影响技能触发几率和道具掉落概率


    //扩展属性
    int invincible;
    int faceDirection;

    public int FaceDirection
    {
        get { return faceDirection; }
        set { faceDirection = value; }
    }
    //附加属性
    private float spasticity;//僵直,自身僵直度越高，那么对手收到攻击后的呆滞时间就越长


    //init属性
    public int initialHealth;
    public int initialMoveSpeed;
    public int initialAttackSpeed;
    public int initialAttackRange;
    public int initialAttackDamage;
    public int initialHitRecover;
    public int initialLuck;


   

    public int Invincible
    {
        get { return invincible; }
        set 
        { 
            invincible = value;
            Notify("InvincibleChanged;" + invincible);
        }
    }

    public float HealthIn
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
            if (health <= 0&&IsAlive!=-1)
            {
                //gameObject.GetComponent<HitAwary>().BeHitAwary();
                IsAlive = 0;
            }
            Notify("HealthInChanged;"+temp+";"+health+";"+this.tag);

        }
    }

    public int Health
    {
        get { return healthTmp; }
        set
        {
            //若无敌且收到伤害
            if (Invincible == 1 && value < Health)
            {
                Notify("WithStand:" + (Health - value));
                return;
            } 

            int temp = healthTmp;
            healthTmp = value;
            if (Health < 0)
                HealthIn = value;
            else if (Health > 10)
                HealthIn = 10;
            else
                HealthIn = value;
            Notify("HealthChanged;" + temp + ";" + healthTmp + ";"+this.tag);

        }
    }

 
    public float MoveSpeedIn
    {
        
        get { return moveSpeed; }
        set
        {
            float temp=moveSpeed;
            moveSpeed = value;
            Notify("MoveSpeedInChanged;" + temp + ";" + moveSpeed);
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
            int tmp=moveSpeedTmp;
            moveSpeedTmp=value;
            float temp = 0;
            
            if (value <= 0)
                temp = 0f;
            else if (value == 1)
                temp = 0.05f;
            else if (value == 2)
                temp = 0.08f;
            else if (value == 3)
                temp = 0.1f;
            else if (value == 4)
                temp = 0.12f;
            else if (value >= 5)
                temp = 0.15f;
            MoveSpeedIn = temp ;
            Notify("MoveSpeedChanged;" + tmp + ";" + moveSpeedTmp);
        }
    }

    public float AttackSpeedIn
    {
        get { return attackSpeed; }
        set
        {
            float temp = attackSpeed;
            attackSpeed = value;
            Notify("AttackSpeedInChanged;"+temp+";"+attackSpeed);
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
            if (value <= 0)
                temp = 0f;
            else  if (value == 1)
                temp = 0.5f;
            else if (value == 2)
                temp = 0.8f;
            else if (value == 3)
                temp = 1f;
            else if (value == 4)
                temp = 1.2f;
            else if (value >= 5)
                temp = 1.4f;
            attackSpeedTmp = value;
            AttackSpeedIn = temp;
            Notify("AttackSpeedChanged;" + temp + ";" + attackSpeed);
        }
    }


    public float AttackRangeIn
    {
        get { return attackRange; }
        set
        {
            float tmp = attackRange;
            attackRange = value;
            ChangeWeaponRange();
            Notify("AttackRangeInChanged;"+tmp+";"+attackRange);
        }
    }
    public int AttackRange
    {
        get { return attackRangeTmp; }
        set
        {
            //TODO 效果
            int tmp = attackRangeTmp;
            attackRangeTmp = value;
            if (value <= 0)
                AttackRangeIn = 1f;
            else if (value == 1)
                AttackRangeIn = 1.05f;
            else if (value == 2)
                AttackRangeIn = 1.1f;
            else if (value == 3)
                AttackRangeIn = 1.15f;
            else if (value == 4)
                AttackRangeIn = 1.2f;
            else if (value >= 5)
                AttackRangeIn = 1.25f;
    
            Notify("AttackRangeChanged;" + tmp + ";" + attackRangeTmp);
        }
    }

    public float AttackDamageIn
    {
        get { return attackDamage; }
        set
        {
            float tmp = attackDamage;
            attackDamage = value;
            Notify("AttackDamageInChanged;"+tmp+";"+attackDamage);
        }
    }
    public int AttackDamage
    {
        get { return attackDamageTmp; }
        set
        {
             int tmp = attackDamageTmp;
            attackDamageTmp = value;
            AttackDamageIn = attackRangeTmp;
            Notify("AttackDamageChanged;" + tmp + ";" + attackDamageTmp);
        }
    }

    public float HitRecoverIn
    {
        get { return hitRecover; }
        set
        {
            float tmp = hitRecover;
            hitRecover = value;
            Notify("HitRecoverInChanged;"+tmp+";"+hitRecover);
        }
    }
    public int HitRecover
    {
        get { return hitRecoverTmp; }
        set
        {
            int tmp = hitRecoverTmp;
            hitRecoverTmp = value;
            
            if (value <= 0)
                HitRecoverIn = 1f;
            else if (value == 1)
                HitRecoverIn = 1.5f;
            else if (value == 2)
                HitRecoverIn = 2f;
            else if (value == 3)
                HitRecoverIn = 2.5f;
            else if (value == 4)
                HitRecoverIn = 3f;
            else if (value >= 5)
                HitRecoverIn = 3.5f;
    
            Notify("HitRecoverChanged;" + tmp + ";" + hitRecoverTmp);
        }
    }

    public int Luck
    {
        get { return luckTmp; }
        set
        {
            int tmp = luckTmp;
            luckTmp = value;
            if (value <= 0)
                LuckIn = 0;
            else if (value == 1)
                LuckIn = 0.05f;
            else if (value == 2)
                LuckIn = 0.09f;
            else if (value == 3)
                LuckIn = 0.13f;
            else if (value == 4)
                LuckIn = 0.17f;
            else if (value >= 5)
                LuckIn = 0.20f;
            Notify("LuckChanged;"+tmp+";"+luckTmp);
        }
    }

    public float LuckIn
    {
        get { return luck; }
        set 
        {
            float tmp = luck;
            luck = value;
            Notify("LuckInChanged;" + tmp + ";" + luck);
        }
    }


    public float Spasticity
    {
        get { return spasticity; }
        set
        {
            float tmp = spasticity;
            spasticity = value;
            Notify("SpasticityChanged"+tmp+";"+spasticity);
        }
    }

    private int race;   //种族

    public int Race
    {
        get { return race; }
        set
        {
            int tmp = race;
            race = value;
            Notify("RaceChanged"+tmp+";"+race);
        }
    }
    private int weapon; //武器类型

    public int Weapon
    {
        get { return weapon; }
        set
        {
            int tmp = weapon;
            weapon = value;
            Notify("WeaponChanged;"+tmp+";"+weapon);
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

   


    //NEED private SkillManager skillManager;
    //NEED private BuffManager buffManager;

    private int isAlive;//<0 死透 =0 正在死 >0 活着
    private int deadTime;
    public int IsAlive
    {
        get { return isAlive; }
        set
        {
          
            isAlive = value;
            if (isAlive == 0)
                deadTime = 50;
            if(isAlive<0)
            {
                Die();
            }

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
            {
                weaponObj.transform.Find("Weapon").GetComponent<BoxCollider>().enabled = false;
                Notify("WeaponDontDmg");
            }
               
            else
            {
                weaponObj.transform.Find("Weapon").GetComponent<BoxCollider>().enabled = true;
                Notify("WeaponDmg");
            }
             
        }
    }

    private int isWeaponHitAwary;//武器是否有击飞效果

    public int IsWeaponHitAwary
    {
        get { return isWeaponHitAwary; }
        set { isWeaponHitAwary = value; }
    }

    private int controllable;//是否受控制

    public int Controllable
    {
        get { return controllable; }
        set { controllable = value; }
    }




    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            if (controllable == 0)
                return;
            Vector3 temp = gameObject.transform.FindChild("BodyNode").gameObject.GetComponent<Transform>().localScale;
            //Vector3 temp = gameObject.GetComponent<Transform>().localScale;
            if (value.x * temp.x > 0)
                temp.x = -temp.x;
            //gameObject.GetComponent<Transform>().localScale = temp;
            gameObject.transform.FindChild("BodyNode").gameObject.GetComponent<Transform>().localScale = temp;
            //Vector3 temp = gameObject.GetComponent<Transform>().localScale;
            //if (value.x * temp.x > 0)
            //    temp.x = -temp.x;
            //gameObject.GetComponent<Transform>().localScale = temp;

            direction = value;
            if (direction.x > 0)
                faceDirection = 1;
            else if (direction.x < 0)
                faceDirection = -1;
                
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
        //isAlive = -1;
        CharacterManager.Instance.CharacterList.Remove(this);
        Notify("Die;"+this.tag);

    }

    bool CheckSurvivalTime()
    {
        return false;
    }

    public virtual void NormalAttack()
    {
        if (controllable == 0)
            return;

        state = 0;
        CanMove = 0;
        actionStateMachine.Push(1);
    }

    public virtual void SpecialAttack()
    {
        if (controllable == 0)
            return;
        actionStateMachine.Push(2);
    }

    public virtual void UseRaceSkill()
    {
        if (controllable == 0)
            return;

        actionStateMachine.Push(3);

    }

   public virtual void Start()
    {
      
        state = 0;
        IsAlive = 1;
        canMove = 1;
        invincible = 0;
        weapon = 0;
        deadTime =50;
        controllable = 1;
        Health = initialHealth;
        MoveSpeed = initialMoveSpeed;
        AttackSpeed = initialAttackSpeed;
        AttackDamage = initialAttackDamage;
        Luck = initialLuck;
        HitRecover = initialHitRecover;
        weaponObj = this.GetComponent<Transform>().Find("BodyNode").Find("Body").Find("RightArmNode").Find("RightArm").Find("RightHandNode").Find("RightHand").Find("WeaponNode").gameObject;
        AttackRange = initialAttackRange;
        anim = this.GetComponent<Animator>();
       

    }


   void Update()
   {
       if (isAlive == 0)
       {
           deadTime--;
           //Debug.Log(deadTime);
       }

       if (deadTime == 0)
       {
           IsAlive = -1;
           deadTime = -1;
       } 
   }

    public virtual void FixedUpdate()
    {
        if (state == 1&&controllable==1)
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
        CharacterManager.Instance.CharacterList.Add(this);

        Transform bodyNode = gameObject.transform.FindChild("BodyNode");
        Transform body = gameObject.transform.FindChild("Body");
        body.SetParent(bodyNode);

        gameObject.AddComponent<HitAwary>();
    }


    public void Disappear()
    {
        if (tag != "Player")
            Destroy(this.gameObject);
    }
    /// <summary>
    /// 发送生成发射物的通知
    /// </summary>
    public void NotifyMissile()
    {
        Notify("GenerateMissile;" + Direction.x + ";" + Direction.y + ";"+ Direction.z + ";" + 1+";"+AttackRange);
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
        else if (asi.IsName("Move"))
        {
            Anim.speed = moveSpeed*10;
            //character.Anim.speed = character.MoveSpeed;
        }
        else if (asi.IsName("Idle") )
        {
            Anim.speed = 1;
        }
        else if(asi.IsName("Hurt"))
        {
            Anim.speed = hitRecover;
        }
    }


    public void ChangeWeaponRange()
    {
        if (weapon == 0)
        {
            weaponObj.transform.localScale = new Vector3(attackRange, attackRange, attackRange);
        }

    }

    int lastFrames;
    public void MoveBy(int lastFrames)
    {
  

       this.gameObject.transform.position += direction*moveSpeed;
    }





}

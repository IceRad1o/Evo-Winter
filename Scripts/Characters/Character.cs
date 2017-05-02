using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Character : RoomElement
{
    //音频
    public AudioClip attackingSound;
    public AudioClip attackingSound2;
    public AudioClip attackingSound3;
    public AudioClip movingSound;
    public AudioClip dyingSound;
    public AudioClip damagingSound;

    //发射物
    public GameObject[] missiles;

    //武器
    public GameObject[] weapons;


    //引用对象
    Animator anim;
    GameObject weaponObj;
    GameObject weaponObj2;
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
    int faceDirection;//面朝向

    int isConfused = 0;//是否混乱



    private int isAlive;//<0 死透 =0 正在死 >0 活着
    private int deadTime;


    int beatDownBuff = 0;//击飞buff

    public int BeatDownBuff
    {
        get { return beatDownBuff; }
        set { beatDownBuff = value; }
    }
    int beatBackBuff = 0;//击退buff

    public int BeatBackBuff
    {
        get { return beatBackBuff; }
        set { beatBackBuff = value; }
    }

    public int FaceDirection
    {
        get { return faceDirection; }
    }

    public int IsConfused
    {
        get { return isConfused; }
        set { isConfused = value; }
    }
    //附加属性
    private float spasticity;//僵直,自身僵直度越高，那么对手收到攻击后的呆滞时间就越长
    private int race;   //种族
    private int weapon; //武器类型
    private int sight;  //视野 影响可见范围,若玩家处于怪物的视野外则不会遭受攻击
    private int camp;   //阵营 0=友方 1=敌方
    //init属性
    public int initialHealth;
    public int initialMoveSpeed;
    public int initialAttackSpeed;
    public int initialAttackRange;
    public int initialAttackDamage;
    public int initialHitRecover;
    public int initialLuck;

    private ActionStateMachine actionStateMachine;
    private int canMove;    //能否移动
    private int state;// 0=静止 1=移动
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
                state = 0;
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

    public virtual int Health 
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
            //if (Health < 0)
            //    HealthIn = value;
            //else if (Health > 10)
            //    HealthIn = 10;
            //else
            //    HealthIn = value;
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
                temp = 0.025f;
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
                temp = 0.025f;
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
            foreach (GameObject weapon in weapons)
                weapon.GetComponent<HurtByContract>().damage = (int)attackDamage;
            //GetComponent<CharacterSkin>().Weapon.GetComponent<HurtByContract>().damage =(int) attackDamage;
            //if(weapon==1&&race==0)
               // GetComponent<CharacterSkin>().Weapon2.GetComponent<HurtByContract>().damage = (int)attackDamage;
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
         
            AttackDamageIn = attackDamageTmp;
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
                HitRecoverIn = 0.5f;
            else if (value == 1)
                HitRecoverIn = 1f;
            else if (value == 2)
                HitRecoverIn = 1.7f;
            else if (value == 3)
                HitRecoverIn = 2.4f;
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
                LuckIn = 0.10f;
            else if (value == 2)
                LuckIn = 0.20f;
            else if (value == 3)
                LuckIn = 0.30f;
            else if (value == 4)
                LuckIn = 0.40f;
            else if (value >= 5)
                LuckIn = 0.50f;
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



    public int Sight
    {
        get { return sight; }
        set
        {
            sight = value;
            Notify("SightChanged");
        }
    }



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


    public int Camp
    {
        get { return camp; }
        set
        {
            camp = value;
            Notify("CampChanged");

        }
    }



    public ActionStateMachine ActionStateMachine
    {
        get { return actionStateMachine; }
        set { actionStateMachine = value; }
    }



    //PROBLEM 值不停的在改变
    public int CanMove
    {
        get { return canMove; }
        set
        {
            canMove = value;
            State = 0;
            Notify("CanMoveChanged");
        }
    }




    public int State
    {
        get { return state; }
        set
        {

          
            if (state != value)
            {

                if (CanMove == 0 && value == 1)
                    return;
                //Debug.Log("current state:" + state + " to " + value);
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
                foreach (GameObject weapon in weapons)
                    weapon.GetComponent<BoxCollider>().enabled =false;

                Notify("WeaponDontDmg");
            }
               
            else
            {
                foreach (GameObject weapon in weapons)
                    weapon.GetComponent<BoxCollider>().enabled = true;

                Notify("WeaponDmg");
            }
             
        }
    }

    private int beatDownLevelX;//武器是否有击飞效果

    public int BeatDownLevelX
    {
        get { return beatDownLevelX; }
        set 
        {
            beatDownLevelX = value;
           // weaponObj.transform.Find("Weapon").GetComponent<HurtByContract>().beatDownLevelX = beatDownLevelX+beatDownBuff;

            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].GetComponent<HurtByContract>().beatDownLevelX = beatDownLevelX + beatDownBuff;
            }
        }
    }
    private int beatDownLevelY;//武器是否有击飞效果

    public int BeatDownLevelY
    {
        get { return beatDownLevelY; }
        set
        {
            beatDownLevelY = value;
            //weaponObj.transform.Find("Weapon").GetComponent<HurtByContract>().beatDownLevelY = beatDownLevelY+beatDownBuff;

            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].GetComponent<HurtByContract>().beatDownLevelY = beatDownLevelY + beatDownBuff;
            }
        }
    }



    private int beatBackLevel;//武器是否有击退效果

    public int BeatBackLevel
    {
        get { return beatBackLevel; }
        set 
        {
            beatBackLevel = value;

            for(int i=0;i<weapons.Length;i++)
            {
                weapons[i].GetComponent<HurtByContract>().beatBackLevel = beatBackLevel + beatBackBuff;
            }
        }
    }



    private int controllable;//是否受控制

    public int Controllable
    {
        get { return controllable; }
        set { controllable = value; }
    }


    private Vector3 direction;

    private Vector3 directionAttempt;//试图的方向

    public Vector3 DirectionAttempt
    {
        get { return directionAttempt; }
        set { directionAttempt = value; }
    }



    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            if (controllable == 0 || canMove == 0)
            {
                DirectionAttempt = value;
                return;
            }
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
            DirectionAttempt = value;
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
        //Notify("Move");

    }

    public virtual void Fall()
    {
        state = 0;
        actionStateMachine.Push(7);
    }

    public virtual void Die()
    {
        state = 0;
        actionStateMachine.Push(5);
        //isAlive = -1;
        
        Notify("Die;"+this.tag);
        StartCoroutine(Disappear());
       // Destroy(this.gameObject);

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
        actionStateMachine.Push(1);
    }

    public virtual void SpecialAttack()
    {
        if (controllable == 0)
            return;
        state = 0;
        actionStateMachine.Push(2);
    }

    public virtual void UseRaceSkill()
    {
        if (controllable == 0)
            return;
        State = 0;
        actionStateMachine.Push(3);

    }

   public virtual void Start()
    {

      

    

    }
   void init()
   {
       //初始化
       state = 0;//静止
       IsAlive = 1;//活着
       canMove = 1;//可以移动
       controllable = 1;//可以被控制
       invincible = 0;//不无敌
       //weapon = 0;//默认近战武器
       deadTime = 50;//死亡延迟时间
       faceDirection = -1;
       direction = new Vector3(-1, 0, 0);

       anim = this.GetComponent<Animator>();

       //初始化基本属性
       Health = initialHealth;
       MoveSpeed = initialMoveSpeed;
       AttackSpeed = initialAttackSpeed;
       AttackDamage = initialAttackDamage;
       Luck = initialLuck;
       HitRecover = initialHitRecover;


       AttackRange = initialAttackRange;
   }

   void Update()
   {
       if (isAlive == 0)
       {
           deadTime--;
       }

       if (deadTime == 0)
       {
           IsAlive = -1;
           deadTime = -1;
       } 
   }

    public virtual void FixedUpdate()
    {
        //Debug.Log("state:" + state);
        if (controllable==1&&canMove==1&&actionStateMachine.CurState=="Move")
        {
            Move();
        }

        else if(actionStateMachine.CurState=="Idle"&&State==1)
        {
            ActionStateMachine.Push(4);
        }


    }


    public void PlaySound(AudioClip clip)
    {
        SoundManager.Instance.PlaySoundEffect(clip);
    }

    public void Awake()
    {
        //RoomElementID = 2001;

        actionStateMachine = new ActionStateMachine();
        actionStateMachine.Character = this;
        CharacterManager.Instance.CharacterList.Add(this);
        weapon = RoomElementID % 10;
   
        race = RoomElementID % 100 / 10;
        init();
        //Transform bodyNode = gameObject.transform.FindChild("BodyNode");
        //Transform body = gameObject.transform.FindChild("Body");
        //body.SetParent(bodyNode);

        //gameObject.AddComponent<HitAwary>();
    }


    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        if (tag != "Player")
        {
            
            CharacterManager.Instance.CharacterList.Remove(this);  
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// 发送生成发射物的通知 X X XX
    /// </summary>
    public void NotifyMissile(int type)
    {
        //Notify("GenerateMissile;" + Direction.x + ";" + Direction.y + ";"+ Direction.z + ";" + type+";"+AttackRange);
       // Notify("GenerateMissile;" + CharacterManager.Instance.CharacterList.IndexOf(this) + ";" + type );
        int missileIndex = type / 1000;
        int num = type / 100%10;
        type = type % 100;
        //Debug.Log(missileIndex + ":" + num);
         GameObject missileInstance ;
        if(weapons.Length!=0)
                missileInstance = Instantiate(missiles[missileIndex],weapons[num].transform.Find("WeaponPoint").position, Quaternion.identity) as GameObject;
        else
                missileInstance = Instantiate(missiles[missileIndex], transform.position, Quaternion.identity) as GameObject;
        missileInstance.GetComponent<HurtByContract>().Init(AttackDamage, beatBackLevel, beatDownLevelX, beatDownLevelY, this);
        missileInstance.GetComponent<Missiles>().direction = faceDirection;
        missileInstance.GetComponent<Missiles>().flyPath = type;
        missileInstance.GetComponent<Missiles>().InitMissiles(attackRange, attackSpeed);
  
    }

    /// <summary>
    /// 更新动画速度
    /// </summary>
    public void UpdateAnimSpeed()
    {
     
        actionStateMachine.UpdateAnimSpeed(Anim);

    }


    public void ChangeWeaponRange()
    {
        //if (weapon == 0)
        //{
          
        //    this.GetComponent<CharacterSkin>().WeaponNode.transform.localScale = new Vector3(attackRange, attackRange, attackRange);
        //}
        //if(weapon==1)
        //{
        //    weaponObj.transform.localScale = new Vector3(attackRange, attackRange, attackRange);
        //    //weaponObj2.transform.localScale = new Vector3(attackRange, attackRange, attackRange);
        //}
        for(int i=0;i<weapons.Length;i++)
        {
            weapons[i].transform.parent.localScale = new Vector3(attackRange, attackRange, attackRange);
        }

    }

    //运动函数
    int lastFrames;
    int moveRate;
    public void MoveBy(int lastFramesAndRate)
    {
        this.moveRate = lastFramesAndRate / 1000;
        if (lastFramesAndRate < 0)
            lastFramesAndRate = -lastFramesAndRate;
        this.lastFrames = lastFramesAndRate % 1000;
      
        //移速修正,因为攻速可能会导致动画变短
        StartCoroutine(MoveByCoroutine());
       
    }

    IEnumerator MoveByCoroutine()
    {
        while (lastFrames!=0)
        {    
            this.gameObject.transform.position += new Vector3(faceDirection,0,0) * moveSpeed*0.1f*moveRate;
            lastFrames--;
            yield return null;
        }

    }

    public void FlashBy(int lastFramesAndRate)
    {

        this.moveRate = lastFramesAndRate / 1000;
        if (lastFramesAndRate < 0)
            lastFramesAndRate = -lastFramesAndRate;
        this.lastFrames = lastFramesAndRate % 1000;
      
        StartCoroutine(FlashByCoroutine());

    }

    IEnumerator FlashByCoroutine()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        while (lastFrames != 0)
        {

            this.gameObject.transform.position += new Vector3((faceDirection*2 + DirectionAttempt.x) / 3, DirectionAttempt.y, DirectionAttempt.z) * moveSpeed * 0.1f * moveRate;
            lastFrames--;
            yield return null;
        }
        this.gameObject.GetComponent<BoxCollider>().enabled =true;
    }

    public void AttackStart(string name)
    {
        CanMove = 0;
        IsWeaponDmg = 1;
        Notify("AttackStart;" + name);


    }

    public void AttackEnd(string name)
    {
        CanMove = 1;
        IsWeaponDmg = 0;
        BeatDownLevelX = 0;
        BeatDownLevelY = 0;
        
        Notify("AttackEnd;" + name);

    }


    /// <summary>
    /// 当执行死亡动画开始时调用,以防诈尸
    /// </summary>
    public void StopPushState()
    {
        actionStateMachine.isStoped = true;
    }

    public int[] GetAttris()
    {
        List<int> attrilist = new List<int>();
        attrilist.Add(Health);
        attrilist.Add(AttackDamage);
        attrilist.Add(AttackSpeed);
        attrilist.Add(AttackRange);
        attrilist.Add(MoveSpeed);
        attrilist.Add(HitRecover);
        attrilist.Add(Luck);
        attrilist.Add(FaceDirection);
        return attrilist.ToArray();
    }

    public void LoadAttris(int[] attris)
    {
        Health = attris[0];
        AttackDamage = attris[1];
        AttackSpeed = attris[2];
        AttackRange = attris[3];
        MoveSpeed = attris[4];
        HitRecover = attris[5];
        Luck = attris[6];

        Direction = new Vector3(attris[7], 0, 0);
    }
    


}

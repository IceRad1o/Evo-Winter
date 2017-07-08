using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// Character
/// Brief:Succeeding class roomElement,the entity of roomElement objects alive;
/// Author:IfYan
/// Latest Update Time:2017.5.9
/// </summary>
public class Character : RoomElement
{
    #region Varibles

    #region Other Prefab
    public GameObject frozenIce;
    public GameObject burningFire;
    GameObject frozenIceIns;
    GameObject burningFireIns;
    #endregion

    #region AudioClips
    [Header("Sounds")]
    public AudioClip[] sounds;
    public enum CharacterSound
    {
        Hurt,
        Die,
        Attack1,
        Attack2,
        Attack3
        
    }
    //public AudioClip attackingSound;
    //public AudioClip attackingSound2;
    //public AudioClip attackingSound3;
    //public AudioClip movingSound;
    //public AudioClip dyingSound;
    //public AudioClip damagingSound;
    #endregion

    #region Cached Components
    //Cached Animator Component
    Animator anim;
    //Cached ActionStateMachine
    ActionStateMachine actionStateMachine;
    //Cached CharacterSkin
    CharacterSkin characterSkin;

    #endregion

    #region Attributes
    /*标识性属性*/
    #region Iconic Attris
    //种族
    RaceType race;
    //武器类型
    CareerType career;

    /// <summary>
    /// 种族类型
    /// </summary>
    public enum RaceType
    {
        Gnome,
        Pygmy,
        Vampire,
        Lycan
    }
    /// <summary>
    /// 职业类型
    /// </summary>
    public enum CareerType
    {
        Warrior,
        Rogue,
        Mage,
        Archer

    }

    public enum CampType
    {
        Player,
        Friend,
        Monster,
        Boss
    }

    #endregion

    /*基础属性*/
    #region Basic Attris

    //1.攻击力,影响攻击造成的伤害
    static float[] atkValues={0.8f,1f,1.6f,2.1f,2.5f,2.8f}; 
    int atk;
    //2.攻速,影响攻击速度
    static float[] spdValues = {0.4f, 0.5f, 0.8f, 1.05f, 1.25f, 1.4f };  
    int spd;
    //3.攻击范围,影响近战攻击范围和远程攻击距离
    static float[] rngValues={0.5f,0.8f,1.2f,1.6f,1.9f,2.2f}; 
    int rng;
    //4.移速,影响移动速度
    static float[] movValues = { 0.04f,0.05f, 0.08f, 0.105f, 0.125f, 0.14f };  
    int mov;
    //OLD 5.硬直,即受击回复,影响受到攻击后的无法移动无法攻击时间，硬直越高时此时间越短;
    //NEW 5.精神,影响精力恢复速度
    static float[] sprValues = { 0.05f, 0.1f, 0.16f, 0.21f, 0.25f, 0.28f };  
    int spr;
    //6.幸运 影响技能触发几率和道具掉落概率
    static float[] lukValues={0.8f,1.0f,1.2f,1.35f,1.45f,1.5f};
    int luk; 
    #endregion

    /*附加属性*/
    #region Additional Attris
    //视野 影响可见范围,若玩家处于怪物的视野外则不会遭受攻击,对玩家不起作用
    static float[] sightValues = { 0, 0.5f, 2.8f, 5f, 7.83f, 10.3f };
    int sight=3;
    //死亡延迟帧数 从生命为0到真正死亡的倒计时
    int deadTime=50;

    float energy = 100f;
    float maxEnergy = 100f;



    #endregion

    #endregion

    #region Directions
    //当前方向(normalized)
    Vector3 direction=new Vector3(-1,0,0);
    //试图的方向
    Vector3 attemptDirection = new Vector3(-1, 0, 0);
    //面朝的方向
    int faceDirection=-1;
    #endregion

    #region States
    //能否移动
    int canMove=1;
    //是否正在移动 0=静止 1=移动
    int isMove=0;
    //是否活着 -1= 死透 0= 正在死 1= 活着
    int isAlive=1;
    //是否无敌
    int isInvincible=0;
    //是否霸体
    int isSuperArmor = 0;
    //是否可控
    int isControllable=1;
    //是否混乱
    int isConfused = 0;
    //是否燃烧
    int isBurning = 0;
    //是否冰冻
    int isFrozen = 0;
    //是否致盲
    int isBlind = 0;
    #endregion

    //TODO 重新写脚本
    #region AboutWeapons
    int isWeaponDmg; //0=无伤害 1=武器有伤害

    int beatDownBuff = 0;//击飞buff
    int beatBackBuff = 0;//击退buff

    private int beatBackLevel;//武器是否有击退效果
    private int beatDownLevelX;//武器是否有击飞效果
    private int beatDownLevelY;//武器是否有击飞效果
    #endregion

    #region Init Attris
    //init属性
    //public int maxHp=10;
    public int oHp=3;
    public int oMov=2;
    public int oSpd=2;
    public int oRng=1;
    public int oAtk=1;
    public int oFhr=1;
    public int oLuk=1;

    #endregion
    #endregion

    #region Methods
    /*字段封装函数*/
    #region Getter&Setter

    #region Iconic Attris Getter&Setter

    /// <summary>
    /// 种族
    /// </summary>
    public RaceType Race
    {
        get { return race; }
        set
        {
            int tmp = (int)race;
            race = value;
            Notify(new StringBuilder(30).Append("RaceChanged").Append(tmp).Append((int)race).ToString());
            //Notify("RaceChanged" + tmp + ";" + (int)race);
        }
    }
    /// <summary>
    /// 职业
    /// </summary>
    public CareerType Career
    {
        get { return career; }
        set
        {
            int tmp = (int)career;
            career = value;
            Notify(new StringBuilder(30).Append("WeaponChanged").Append(tmp).Append((int)career).ToString());
            //Notify("WeaponChanged;" + tmp + ";" + (int)career);
        }
    }
    #endregion

    #region Basic Attris Getter&Setter

    /// <summary>
    /// 生命值
    /// </summary>
    public override float Hp
    {
        get { return base.Hp; }
        set
        {
           
            if(value<Hp)
            {
                //若无敌且收到伤害
                if (IsInvincible == 1 )
                {
                    Notify("WithStand:" + (Hp - value));
                    return;
                }
          
                if (IsSuperArmor == 0 )
                {
                    //此处用isMove,不用IsMove
                    isMove = 0;
                    actionStateMachine.Push(6);
                } 
            }

            base.Hp = value;
            if (Hp <= 0 && IsAlive != -1)
            {
                //此处用IsAlive,不用isAlive,实现鞭尸系统
                IsAlive = 0;
            }
            //HealthPercent = Hp / maxHp;
          
        }
    }
    /// <summary>
    /// 攻击力数值
    /// </summary>
    public float AtkValue
    {
        get { return atkValues[BoundaryAdjust(Atk)]; }
    }
    /// <summary>
    /// 攻击力等级
    /// </summary>
    public int Atk
    {
        get { return atk; }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("AttackDamageChanged;").Append(atk).Append(";");
            atk = value;
            for (int i = 0; i < CharacterSkin.weapons.Length; i++)
            {
                var c = CharacterSkin.weapons[i].GetComponent<HurtByContract>();
                if (c != null)
                    c.damage = AtkValue;
            } 
            Notify(s.Append(atk).ToString());
        }
    }
    /// <summary>
    /// 攻击速度值
    /// </summary>
    public float SpdValue
    {
        get { return  spdValues[BoundaryAdjust(Spd)]; }
    }
    /// <summary>
    /// 攻击速度等级
    /// </summary>
    public int Spd
    {
        get
        {
            return spd;
        }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("AttackSpeedChanged;").Append(spd).Append(";");
            spd = value;
            Notify(s.Append(spd).ToString());
        }
    }
    /// <summary>
    /// 攻击范围值
    /// </summary>
    public float RngValue
    {
        get { return rngValues[BoundaryAdjust(Rng)]; }
    }
    /// <summary>
    /// 攻击范围等级
    /// </summary>
    public int Rng
    {
        get { return rng; }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("AttackRangeChanged;").Append(rng).Append(";");
            rng = value;
            ChangeWeaponRange();
            Notify(s.Append(rng).ToString());
        }
    }
    /// <summary>
    /// 移速值
    /// </summary>
    public float MovValue
    {
        get { return movValues[BoundaryAdjust(Mov)]; }
    }

    /// <summary>
    /// 移速等级
    /// </summary>
    public int Mov
    {
        get
        {
            return mov;
        }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("MoveSpeedChanged;").Append(mov).Append(";");
            mov = value;
            Notify(s.Append(mov).ToString());
        }
    }
    /// <summary>
    /// 硬直值
    /// </summary>
    public float FhrValue
    {
        get { return sprValues[BoundaryAdjust(Fhr)]; }
    }
    /// <summary>
    /// 硬直等级
    /// </summary>
    public int Fhr
    {
        get { return spr; }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("HitRecoverChanged;").Append(spr).Append(";");
            spr = value;
            Notify(s.Append(spr).ToString());
        }
    }
    /// <summary>
    /// 幸运值
    /// </summary>
    public float LukValue
    {
        get { return lukValues[Luk]; }
    }
    /// <summary>
    /// 幸运等级
    /// </summary>
    public int Luk
    {
        get { return luk; }
        set
        {
            StringBuilder s = new StringBuilder(30).Append("LuckChanged;").Append(luk).Append(";");
            luk = value;
            Notify(s.Append(luk).ToString());
        }
    }
    /// <summary>
    /// 视野等级
    /// </summary>

    public float SightValue
    {
        get { return sightValues[Sight]; }
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
    public float Energy
    {
        get { return energy; }
        set 
        { 
            energy = value;
            Notify("EnergyChanged");
        }
    }

    public float MaxEnergy
    {
        get { return maxEnergy; }
        set { maxEnergy = value; }
    }
    #endregion

    #region States Getter&Setter
    /// <summary>
    /// 是否可控
    /// </summary>
    public int IsControllable
    {
        get { return isControllable; }
        set { isControllable = value; }
    }
    /// <summary>
    /// 是否无敌
    /// </summary>
    public int IsInvincible
    {
        get { return isInvincible; }
        set
        {
            isInvincible = value;
            Notify("InvincibleChanged;" + isInvincible);
        }
    }
    /// <summary>
    /// 是否混乱
    /// </summary>
    public int IsConfused
    {
        get { return isConfused; }
        set { isConfused = value; }
    }
    /// <summary>
    /// 是否霸体,霸体则无击退击倒硬直效果
    /// </summary>
    public int IsSuperArmor
    {
        get { return isSuperArmor; }
        set { isSuperArmor = value; }
    }
    /// <summary>
    /// 是否活着
    /// </summary>
    public int IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
            if (isAlive == 0)
                deadTime = 50;
            if (isAlive < 0)
            {
                Die();
            }

        }
    }
    /// <summary>
    /// 能否移动
    /// </summary>
    public int CanMove
    {
        get { return canMove; }
        set
        {
            canMove = value;
            if(canMove==0)
                IsMove = 0;
        }
    }
    /// <summary>
    /// 是否在移动
    /// </summary>
    public int IsMove
    {
        get { return isMove; }
        set
        {
            if (isMove != value)
            {
                if (CanMove == 0 && value == 1)
                    return;
                //Debug.Log("current state:" + state + " to " + value);
                isMove = value;
                actionStateMachine.Push(4 * isMove);
            }
        }
    }
    public int IsBurning
    {
        get { return isBurning; }
        set { isBurning = value; }
    }
    public int IsFrozen
    {
        get { return isFrozen; }
        set 
        {
            if (isFrozen != value)
            {
                isFrozen = value;
                if (isFrozen == 1)
                {
                    anim.speed = 0;
                    frozenIceIns= Instantiate(frozenIce, this.transform,false) as GameObject;
                    frozenIceIns.transform.localScale = new Vector3(1.09f, 1.98f, 1);
                
                   
                }
                else if (isFrozen == 0)
                {
                    //gameObject.AddComponent<BeatDown>().Init(-this.FaceDirection, 1, 2);

                    Destroy(frozenIceIns);
                }
            }
            
        }
    }
    public int IsBlind
    {
        get { return isBlind; }
        set { isBlind = value; }
    }
    #endregion 

    #region Directions Getter&Setter
    /// <summary>
    /// Character Current Normalized Direction 
    /// </summary>
    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            //如果无法移动方向则将方向给予AttemptDirection
            if (IsControllable == 0 || CanMove == 0||isFrozen==1)
            {
                AttemptDirection = value;
                return;
            }
            //Vector3 temp = gameObject.transform.FindChild("BodyNode").gameObject.GetComponent<Transform>().localScale;
            //Debug.Log("1:" + CharacterSkin);
            //Debug.Log("2:" + CharacterSkin.bodyNode);
            Vector3 temp = CharacterSkin.bodyNode.transform.localScale;
            if (value.x * temp.x > 0)
                temp.x = -temp.x;
            CharacterSkin.bodyNode.transform.localScale = temp;
            direction = value;
            AttemptDirection = value;
            if (direction.x >0)
                faceDirection = 1;
            else if (direction.x < 0)
                faceDirection = -1;
            Notify("DirectionChanged");
        }
    }

    public Vector3 Direction2
    {
        get { return direction; }
        set
        {
            //如果无法移动方向则将方向给予AttemptDirection
            if (IsControllable == 0 || CanMove == 0 || isFrozen == 1)
            {
                AttemptDirection = value;
                return;
            }
            //Vector3 temp = gameObject.transform.FindChild("BodyNode").gameObject.GetComponent<Transform>().localScale;
            //Debug.Log("1:" + CharacterSkin);
            //Debug.Log("2:" + CharacterSkin.bodyNode);
            //Vector3 temp = CharacterSkin.bodyNode.transform.localScale;
            //if (value.x * temp.x > 0)
            //    temp.x = -temp.x;
            //CharacterSkin.bodyNode.transform.localScale = temp;
            SpriteRenderer [] a = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < a.Length; i++)
                a[i].flipX = !a[i].flipX;


            direction = value;
            AttemptDirection = value;
            if (direction.x > 0)
                faceDirection = 1;
            else if (direction.x < 0)
                faceDirection = -1;
            Notify("DirectionChanged");
        }
    }

    /// <summary>
    /// Direction the character is attempted to. 
    /// </summary>
    public Vector3 AttemptDirection
    {
        get { return attemptDirection; }
        set { attemptDirection = value; }
    }
    /// <summary>
    /// Character Facing Direction -1 is left,1 is right
    /// </summary>
    public int FaceDirection
    {
        get { return faceDirection; }
    }

    #endregion

    #region Cache Components Getter&Setter
    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }
    public ActionStateMachine ActionStateMachine
    {
        get { return actionStateMachine; }
        set { actionStateMachine = value; }
    }
    public CharacterSkin CharacterSkin
    {
        get {
            if (!characterSkin)
                characterSkin = GetComponent<CharacterSkin>();
            return characterSkin; }
        set { characterSkin = value; }
    }
    #endregion

    #region Weapons Getter&Setter
    public int IsWeaponDmg
    {
        get { return isWeaponDmg; }
        set
        {
            isWeaponDmg = value;
            if (value == 0)
            {
                foreach (GameObject weapon in CharacterSkin.weapons)
                    weapon.GetComponent<BoxCollider>().enabled = false;

                Notify("WeaponDontDmg");
            }

            else
            {
                foreach (GameObject weapon in CharacterSkin.weapons)
                    weapon.GetComponent<BoxCollider>().enabled = true;

                Notify("WeaponDmg");
            }

        }
    }

    /// <summary>
    /// 击倒level加成,0~无限大
    /// </summary>
    public int BeatDownBuff
    {
        get { return beatDownBuff; }
        set { beatDownBuff = value; }
    }
    /// <summary>
    /// 击退level加成,0~无限大
    /// </summary>
    public int BeatBackBuff
    {
        get { return beatBackBuff; }
        set { beatBackBuff = value; }
    }

    public int BeatDownLevelX
    {
        get { return beatDownLevelX; }
        set
        {
            beatDownLevelX = value;
            // weaponObj.transform.Find("Weapon").GetComponent<HurtByContract>().beatDownLevelX = beatDownLevelX+beatDownBuff;

            for (int i = 0; i < CharacterSkin.weapons.Length; i++)
            {
                CharacterSkin.weapons[i].GetComponent<HurtByContract>().beatDownLevelX = beatDownLevelX + beatDownBuff;
            }
        }
    }


    public int BeatDownLevelY
    {
        get { return beatDownLevelY; }
        set
        {
            beatDownLevelY = value;
            //weaponObj.transform.Find("Weapon").GetComponent<HurtByContract>().beatDownLevelY = beatDownLevelY+beatDownBuff;

            for (int i = 0; i < CharacterSkin.weapons.Length; i++)
            {
                CharacterSkin.weapons[i].GetComponent<HurtByContract>().beatDownLevelY = beatDownLevelY + beatDownBuff;
            }
        }
    }


    public int BeatBackLevel
    {
        get { return beatBackLevel; }
        set
        {
            beatBackLevel = value;

            for (int i = 0; i < CharacterSkin.weapons.Length; i++)
            {
                CharacterSkin.weapons[i].GetComponent<HurtByContract>().beatBackLevel = beatBackLevel + beatBackBuff;
            }
        }
    }



 #endregion
    #endregion
    /*Character的行为*/
    #region Behaviors
    /// <summary>
    /// 初始化Character
    /// </summary>
    public void Init()
    {
      
        //初始化
        career = (CareerType)((int)RoomElementID % 10);
        race = (RaceType)((int)RoomElementID % 100 / 10);
        anim = this.GetComponent<Animator>();
        actionStateMachine = new ActionStateMachine();
        actionStateMachine.Character = this;
        characterSkin = this.GetComponent<CharacterSkin>();

        //初始化基本属性
        Hp = oHp;
        if (oHp > maxHp)
            maxHp = oHp;
        Atk = oAtk;
        Spd = oSpd;
        Rng = oRng;
        Mov = oMov;
        Fhr = oFhr;
        Luk = oLuk;

        if (gameObject.CompareTag("Boss"))
            GetBossEquips();

    
    }
    /// <summary>
    /// 移动,当处于移动状态,由update每帧调用
    /// </summary>
    public virtual void Move()
    {
        if (isConfused == 0)
            transform.position += Direction * MovValue;
        else
            transform.position -= Direction * MovValue;

    }
    /// <summary>
    /// 普攻,J
    /// </summary>
    public virtual void NormalAttack()
    {
        if (isControllable == 0||isFrozen==1)
            return;

        isMove = 0;
        actionStateMachine.Push(1);
    }
    /// <summary>
    /// 特攻,K
    /// </summary>
    public virtual void SpecialAttack()
    {
        if (isControllable == 0)
            return;
        isMove = 0;
        actionStateMachine.Push(2);
    }
    /// <summary>
    /// 种族技能,L
    /// </summary>
    public virtual void UseRaceSkill()
    {
        if (isControllable == 0)
            return;
        isMove = 0;
        actionStateMachine.Push(3);

    }
    /// <summary>
    /// 自然流失体力,不会触发受伤动画
    /// </summary>
    /// <param name="value"></param>
    public virtual void LoseHp(float value=1f)
    {
        base.Hp -= value;
        if (Hp <= 0)
            Die();
    }

    /// <summary>
    /// 摔倒
    /// </summary>
    public virtual void Fall()
    {
        isMove = 0;
        actionStateMachine.Push(7);
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public override void Die()
    {
        isMove = 0;
        actionStateMachine.Push(5);


        Notify("Die;" + this.tag);
        KillServants();
        StartCoroutine(Disappear());


    }
    /// <summary>
    /// 消失
    /// </summary>
    /// <returns></returns>
    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);

        if (tag != "Player")
        {
            Destroy();
        }
    }
    #endregion
    /*重写的方法*/
    #region Mono Override Methods
    public override void Awake()
    {
        base.Awake();
        CharacterManager.Instance.Add(this);
        Init();

    }

    public virtual void Start()
    {
        if(!CharacterSkin)
          CharacterSkin = GetComponent<CharacterSkin>();
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
        if (Energy < 100f)
             Energy += FhrValue;

    }
    public virtual void FixedUpdate()
    {

        //Move
        if (isControllable == 1 && canMove == 1 && actionStateMachine.CurState == "Move")
        {

            Move();
        }

        //如果状态与状态机不一致
        else if (actionStateMachine.CurState == "Idle" && IsMove == 1)
        {
            ActionStateMachine.Push(4);
        }


    }
    public override void Destroy()
    {
        CharacterManager.Instance.Remove(this);
        base.Destroy();
    }
    #endregion
    /*运动方法*/
    #region Move Methods
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
        while (lastFrames != 0)
        {
            this.gameObject.transform.position += new Vector3(FaceDirection, 0, 0) * MovValue * 0.1f * moveRate;
            lastFrames--;
            yield return null;
        }

    }
    /// <summary>
    /// 忽略碰撞体
    /// </summary>
    /// <param name="lastFramesAndRate"></param>
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

            this.gameObject.transform.position += new Vector3((faceDirection * 2 + AttemptDirection.x) / 3, AttemptDirection.y, AttemptDirection.z) * MovValue * 0.1f * moveRate;
            lastFrames--;
            yield return null;
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    #endregion
    /*其他方法*/
    #region Other Methods

    /// <summary>
    /// 发射发射物
    /// </summary>
    public void NotifyMissile(int type)
    {
        //Notify("GenerateMissile;" + Direction.x + ";" + Direction.y + ";"+ Direction.z + ";" + type+";"+AttackRange);
        // Notify("GenerateMissile;" + CharacterManager.Instance.CharacterList.IndexOf(this) + ";" + type );
        int missileIndex = type / 1000;
        int num = type / 100 % 10;
        type = type % 100;
        //Debug.Log(missileIndex + ":" + num);
        GameObject missileInstance;
        if (characterSkin.missilePoints.Length != 0)
            missileInstance = Instantiate(characterSkin.missiles[missileIndex],characterSkin.missilePoints[num].transform.position, Quaternion.identity) as GameObject;
        else
            missileInstance = Instantiate(characterSkin.missiles[missileIndex], transform.position, Quaternion.identity) as GameObject;
        missileInstance.GetComponent<HurtByContract>().Init(AtkValue, beatBackLevel, beatDownLevelX, beatDownLevelY, this);
        missileInstance.GetComponent<Missiles>().direction = faceDirection;
        missileInstance.GetComponent<Missiles>().flyPath = type;
        missileInstance.GetComponent<Missiles>().InitMissiles(RngValue, SpdValue);
        missileInstance.GetComponent<RoomElement>().Master = this;

    }

    public void GetBossEquips()
    {
        this.IsSuperArmor = 1;
        this.Sight = 5;
        this.AddObserver(BossHealthBar.Instance);
        Notify("BossAppear;" + (RoomElementID - 2050));
    }


    /// <summary>
    /// 更新动画速度
    /// </summary>
    public void UpdateAnimSpeed()
    {
        actionStateMachine.UpdateAnimSpeed(Anim);

    }

    /// <summary>
    /// 改变武器大小以改变攻击范围
    /// </summary>
    void ChangeWeaponRange()
    {
        var correctRng = (RngValue - 1) / 2+1;
        for (int i = 0; i < CharacterSkin.weapons.Length; i++)
        {
            CharacterSkin.weapons[i].transform.parent.localScale = new Vector3(correctRng, correctRng, correctRng);
        }

    }


    public void AttackStart(string name)
    {
        CanMove = 0;
        //IsWeaponDmg = 1;
        Notify("AttackStart;" + name);


    }

    public void AttackEnd(string name)
    {
        CanMove = 1;
        //IsWeaponDmg = 0;
        BeatDownLevelX = 0;
        BeatDownLevelY = 0;
        BeatBackLevel =1;
        Notify("AttackEnd;" + name);

    }


    public void ConsumeEnergy(float consumedValue)
    {
        Energy -= consumedValue;
    }

    /// <summary>
    /// 当执行死亡动画开始时调用,以防诈尸
    /// </summary>
    public void StopPushState()
    {
        actionStateMachine.isStoped = true;
    }
    /// <summary>
    /// 存储基本属性
    /// </summary>
    /// <returns></returns>
    public int[] GetAttris()
    {
        List<int> attrilist = new List<int>();
        attrilist.Add((int)Hp);
        attrilist.Add(Atk);
        attrilist.Add(Spd);
        attrilist.Add(Rng);
        attrilist.Add(Mov);
        attrilist.Add(Fhr);
        attrilist.Add(Luk);
        attrilist.Add(FaceDirection);
        return attrilist.ToArray();
    }
    /// <summary>
    /// 加载基本属性
    /// </summary>
    /// <param name="attris"></param>
    public void LoadAttris(int[] attris)
    {
        Hp = attris[0];
        Atk = attris[1];
        Spd = attris[2];
        Rng = attris[3];
        Mov = attris[4];
        Fhr = attris[5];
        Luk = attris[6];

        Direction = new Vector3(attris[7], 0, 0);
    }

    public void PlayCharacterSound(Character.CharacterSound sound)
    {
        if(sounds.Length>(int)sound)
            SoundManager.Instance.PlaySoundEffect(sounds[(int)sound]);
    }


    int BoundaryAdjust(int value)
    {
        if (value < 0)
            return 0;
        else if (value > 5)
            return 5;
        else
            return value;
    }




    #endregion

    #endregion

}

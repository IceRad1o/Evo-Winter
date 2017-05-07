using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : ExSubject
{
    string SkillManagerTag;
    /// <summary>
    /// false表示进入了冷却
    /// </summary>
    bool cd = true;
    bool skill_L_Up = true;
    /// <summary>
    /// 种族技能的升级
    /// </summary>
    public bool Skill_L_Up
    {
        get { return skill_L_Up; }
        set { skill_L_Up = value; }
    }

    List<Skill> skillList = new List<Skill>();
    public List<Skill> SkillList
    {
        get { return skillList; }
        set { skillList = value; }
    } 

    public void CreateSkill(int ID) {
        if (ID == 1)
        {
            Meteorite newSkill = this.gameObject.AddComponent<Meteorite>();
            newSkill.Create(ID);
            skillList.Add(newSkill);
            return;
        }
        if (ID >= 2 && ID <= 5)
        {
            new Elemix().CreateSkill(ID,this.gameObject);        
        }
        if (ID == 6)
        {
            WholeDamage newSkill = this.gameObject.AddComponent<WholeDamage>();
            return;
        }
        if (ID == 7)
        {
            NamikazeMinato newSkill;
            if (this.gameObject.GetComponent<NamikazeMinato>()==null)
                newSkill = this.gameObject.AddComponent<NamikazeMinato>();
            else
                this.gameObject.GetComponent<NamikazeMinato>().Trigger();
            return;
        }
        if (ID == 8)
        {
            Twinkle newSkill;
            if (this.gameObject.GetComponent<Twinkle>() == null)
                newSkill = this.gameObject.AddComponent<Twinkle>();
            else
                this.gameObject.GetComponent<Twinkle>().Trigger();
            return;
        }
        if (ID == 9)
        {
            AllStatic newSkill;
            if (this.gameObject.GetComponent<AllStatic>() == null)
                newSkill = this.gameObject.AddComponent<AllStatic>();
            else
                this.gameObject.GetComponent<AllStatic>().Trigger();
            return;
        }
        if (ID == 10)
        {
            GroundMelody newSkill;
            if (this.gameObject.GetComponent<GroundMelody>() == null)
                newSkill = this.gameObject.AddComponent<GroundMelody>();
            else
                this.gameObject.GetComponent<GroundMelody>().Trigger();
            return;
        }
        if (ID == 11)
        {
            DoubleEsscence newSkill;
            if (this.gameObject.GetComponent<DoubleEsscence>() == null)
                newSkill = this.gameObject.AddComponent<DoubleEsscence>();
            else
                this.gameObject.GetComponent<DoubleEsscence>().Trigger();
            return;
        }

        if (ID == 501)
        { 
            RaceSkillUp newSkill;
            if (this.gameObject.GetComponent<RaceSkillUp>() == null)
                newSkill = this.gameObject.AddComponent<RaceSkillUp>();
            else
                this.gameObject.GetComponent<RaceSkillUp>().Trigger();
            return; 
        }

        /***************************************************************/
        //矮人的精华技能
        if (ID == 201)
        {
            Sleep newSkill;
            if (this.gameObject.GetComponent<Sleep>() == null)
                newSkill = this.gameObject.AddComponent<Sleep>();

            return;
        }
        if (ID == 203)
        {
            AllSleep newSkill;
            if (this.gameObject.GetComponent<AllSleep>() == null)
                newSkill = this.gameObject.AddComponent<AllSleep>();

            return;
        }
        if (ID == 205)
        {
            GiveShield newSkill;
            if (this.gameObject.GetComponent<GiveShield>() == null)
                newSkill = this.gameObject.AddComponent<GiveShield>();

            return;
        }
        /***************************************************************/
        //狼人的精华技能
        if (ID == 401)
        {
            Bloodthirsty newSkill;
            if (this.gameObject.GetComponent<Bloodthirsty>() == null)
                newSkill = this.gameObject.AddComponent<Bloodthirsty>();

            return;
        }
        if (ID == 403)
        {
            Rage newSkill;
            if (this.gameObject.GetComponent<Rage>() == null)
                newSkill = this.gameObject.AddComponent<Rage>();

            return;
        }
        if (ID == 405)
        {
            WindinAnger newSkill;
            if (this.gameObject.GetComponent<WindinAnger>() == null)
                newSkill = this.gameObject.AddComponent<WindinAnger>();

            return;
        }
        /***************************************************************/
        //吸血鬼的精华技能
        if (ID == 301)
        {
            this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(07100);
            return;
        }
        if (ID == 302)
        {
            this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(10001100);
            return;
        }
        /***************************************************************/
        //地精的精华技能
        if (ID == 102)
        {
            EnergyIncrease newSkill;
            if (this.gameObject.GetComponent<EnergyIncrease>() == null)
                newSkill = this.gameObject.AddComponent<EnergyIncrease>();
            
            return;
        }
        if (ID == 103)
        {
            Greedy newSkill;
            if (this.gameObject.GetComponent<Greedy>() == null)
                newSkill = this.gameObject.AddComponent<Greedy>();

            return;
        }
        if (ID == 104)
        {
            Occupy newSkill;
            if (this.gameObject.GetComponent<Occupy>() == null)
                newSkill = this.gameObject.AddComponent<Occupy>();

            return;
        }
    }



    public void RemoveSkill(int ID)
    {
        /***************************************************************/
        //矮人的精华技能
        if (ID == 201)
        {
            if (this.gameObject.GetComponent<Sleep>() != null)
                this.gameObject.AddComponent<Sleep>().skillDestory();

            return;
        }
        if (ID == 203)
        {
            if (this.gameObject.GetComponent<AllSleep>() != null)
                this.gameObject.AddComponent<AllSleep>().skillDestory();

            return;
        }
        if (ID == 205)
        {

            if (this.gameObject.GetComponent<GiveShield>() != null)
                this.gameObject.AddComponent<GiveShield>().skillDestory();

            return;
        }
        /***************************************************************/
        //狼人的精华技能
        if (ID == 401)
        {
            if (this.gameObject.GetComponent<Bloodthirsty>() == null)
                this.gameObject.AddComponent<Bloodthirsty>().skillDestory();

            return;
        }
        if (ID == 403)
        {
            if (this.gameObject.GetComponent<Rage>() == null)
                this.gameObject.AddComponent<Rage>().skillDestory();

            return;
        }
        if (ID == 405)
        {
            if (this.gameObject.GetComponent<WindinAnger>() == null)
                this.gameObject.AddComponent<WindinAnger>().skillDestory();

            return;
        }
        /***************************************************************/
        //吸血鬼的精华技能
        if (ID == 301)
        {
            foreach (var item in this.gameObject.GetComponents<AttackPoison>())
            {
                if (item != null)
                    item.DestroyBuff();
            }
            return;
        }
        if (ID == 302)
        {
            foreach (var item in this.gameObject.GetComponents<BuffVampire>())
            {
                if (item != null)
                    item.DestroyBuff();
            }
            return;
        }
        /***************************************************************/
        //地精的精华技能
        if (ID == 102)
        {
            if (this.gameObject.GetComponent<EnergyIncrease>() == null)
                this.gameObject.AddComponent<EnergyIncrease>().skillDestory();

            return;
        }
        if (ID == 103)
        {
            if (this.gameObject.GetComponent<Greedy>() == null)
                this.gameObject.AddComponent<Greedy>().skillDestory();

            return;
        }
        if (ID == 104)
        {
            if (this.gameObject.GetComponent<Occupy>() == null)
                this.gameObject.AddComponent<Occupy>().skillDestory();

            return;
        }
        
    }


    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Skill_ID", msg, 0);
        if (bID != "Fail" && bID!="Error")
            CreateSkill(int.Parse(bID));

        bID = UtilManager.Instance.MatchFiledFormMsg("AddEsscenceSkill", msg, 0);
        if (bID != "Fail" && bID != "Error")
        {
            Debug.Log("AddEsscenceSkill :" + bID);
            CreateSkill(int.Parse(bID));
        }
        bID = UtilManager.Instance.MatchFiledFormMsg("RemoveEsscenceSkill", msg, 0);
        if (bID != "Fail" && bID != "Error")
            RemoveSkill(int.Parse(bID));

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackStart", msg, 0);
        if (bID == "L")
            UseSkill_L();


    }

    /// <summary>
    /// skillManager负责初始化人物\怪物的技能
    /// </summary>
    void Start()
    {
        if (this.tag == "Player")
        {
            ItemManager.Instance.AddObserver(this);
            this.GetComponent<Character>().AddObserver(this);
            EsscenceManager.Instance.AddObserver(this);
        }
        if (this.tag == "Boss"||this.tag=="FakeBoss")
        {
            this.gameObject.AddComponent<BossSkillManager>();
        }
    }

    public void DestoryManager()
    {
        if (this.tag == "Player")
        {
            ItemManager.Instance.RemoveObserver(this);
            this.GetComponent<Character>().RemoveObserver(this);
            EsscenceManager.Instance.RemoveObserver(this);
        }
        //Destroy(this);
    }


    /// <summary>
    /// 使用种族技能，0贪婪，1懒惰，2傲慢，3暴怒
    /// </summary>
    public void UseSkill_L()
    {
        //Debug.Log("UseSkill_L    " + SkillManagerTag);
        if (this.gameObject.tag == "Player" && cd)
        {
            switch (this.gameObject.GetComponent<Character>().Race)
            {
                case 0:
                    if (skill_L_Up)
                    {
                        //扣血
                        GiveBuff newSkill = this.gameObject.AddComponent<GiveBuff>();
                        newSkill.Create(110001, 40);
                        //攻击+1
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1052001110);
                        //幸运-1
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1092002110);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(200));
                    }
                    else
                    {
                        //扣血
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1100010);
                        //创建一个技能
                        ItemManager.Instance.itemsTransform = this.transform;
                        ItemManager.Instance.CreateItemType(true, true, true);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(10));
                    }
                    break;

                case 1:
                    if (skill_L_Up)
                    {
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(20003300);
                        //攻速-1
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1032002110);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(200));                        
                    }
                    else
                    {
                        //扣血
                        GiveBuff newSkill = this.gameObject.AddComponent<GiveBuff>();
                        newSkill.Create(110001, 20);
                        //创建一个技能
                        ItemManager.Instance.itemsTransform = this.transform;
                        ItemManager.Instance.CreateItemType(true, true, true);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(10));
                    }
                    break;

                case 2:
                    if (skill_L_Up)
                    {
                        //全体减速
                        foreach (var item in CharacterManager.Instance.CharacterList.ToArray())
                        {
                            if (item != null && item.tag == "Monster")
                            {
                                                                                                                                 //1021002111
                                item.GetComponent<BuffManager>().CreateDifferenceBuff((item.GetComponent<Character>().MoveSpeed/2)*1000000000+21002111);
                            }
                        }
                        //收到伤害翻倍
                        this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(2006110);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(200));
                    }
                    else
                    {
                        //扣血
                        GiveBuff newSkill = this.gameObject.AddComponent<GiveBuff>();
                        newSkill.Create(110001, 20);
                        //创建一个技能
                        ItemManager.Instance.itemsTransform = this.transform;
                        ItemManager.Instance.CreateItemType(true, true, true);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(10));
                    }
                    break;

                case 3:
                    if (skill_L_Up)
                    {
                        //晕眩
                        GiveBuff newSkill = this.gameObject.AddComponent<GiveBuff>();
                        newSkill.Create(60411, 100);
                        //速度+1
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1021001110);
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(130));

                        
                    }
                    else
                    {
                        //晕眩
                        GiveBuff newSkill = this.gameObject.AddComponent<GiveBuff>();
                        newSkill.Create(60411, 100);
                        //速度+1
                        this.GetComponent<BuffManager>().CreateDifferenceBuff(1021001110);
                        //隐身
                        TintBy new1=this.gameObject.AddComponent<TintBy>();
                        new1.deltaColor=new Vector4(0, 0, 0, -0.5f);
                        new1.duration = 0.5f;
                        TintBy new2 = this.gameObject.AddComponent<TintBy>();
                        new2.deltaColor = new Vector4(0, 0, 0, 0.5f);
                        new2.duration = 0.5f;
                        new2.isDelay = true;
                        new2.delayTime = 10f;
                        //进入Cd
                        cd = !cd;
                        StartCoroutine(Cd(130));

                    }
                    break;
                default:
                    break;
            }

        }

    }



    IEnumerator Cd(int time)
    {
        yield return new WaitForSeconds(time * 0.1f);
        cd = !cd;
    }

    void Awake()
    {
        SkillManagerTag = ""+this.gameObject.tag;
        //EsscenceManager.Instance.AddObserver(this);
    }
}

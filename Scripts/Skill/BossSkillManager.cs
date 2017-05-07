using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossSkillManager : ExSubject{

    string SkillManagerTag;
    int BossID;

    List<Skill> skillList = new List<Skill>();
    public List<Skill> SkillList
    {
        get { return skillList; }
        set { skillList = value; }
    }

    public void CreateSkill(int ID)
    {
        Debug.Log("ID   :" + ID);

        //科学怪人的技能生成，触发
        if (ID == 500)
        {
            CreateLaser newSkill;
            if (this.gameObject.GetComponent<CreateLaser>() == null)
            {
                newSkill = this.gameObject.AddComponent<CreateLaser>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateLaser>().Trigger();
            return;
        }

        if (ID == 501)
        {
            CreateChemistry newSkill;
            if (this.gameObject.GetComponent<CreateChemistry>() == null)
            {
                newSkill = this.gameObject.AddComponent<CreateChemistry>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateChemistry>().Trigger();
            return;
        }

        if (ID == 502)
        {
            CreateScratch newSkill;
            if (this.gameObject.GetComponent<CreateScratch>() == null)
            {
                newSkill = this.gameObject.AddComponent<CreateScratch>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateScratch>().Trigger();
            return;
        }
        if (ID == 503)
        {
            Distortion newSkill;
            if (this.gameObject.GetComponent<Distortion>() == null)
            {
                newSkill = this.gameObject.AddComponent<Distortion>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<Distortion>().Trigger();
            return;
        }
        if (ID == 504)
        {
            Blast newSkill;
            if (this.gameObject.GetComponent<Blast>() == null)
            {
                newSkill = this.gameObject.AddComponent<Blast>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<Blast>().Trigger();
            return;
        }
        if (ID == 506)
        {
            Mud newSkill;
            if (this.gameObject.GetComponent<Mud>() == null)
            {
                newSkill = this.gameObject.AddComponent<Mud>();
                newSkill.Create(ID);
            }
            else
                this.gameObject.GetComponent<Mud>().Trigger();
            return;
        }


        //贪婪的技能生成，触发
        if (ID == 571)
        {

            if (this.gameObject.GetComponent<CreateCorruptWater>() == null)
            {
                this.gameObject.AddComponent<CreateCorruptWater>().Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateCorruptWater>().Trigger();
            return;
        }

        if (ID == 572)
        {
            if (this.gameObject.GetComponent<CreateGiftWater>() == null)
            {
                this.gameObject.AddComponent<CreateGiftWater>().Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateGiftWater>().Trigger();
            return;
        }

        if (ID == 573)
        {
            if (this.gameObject.GetComponent<CreateWhirlpool>() == null)
            {
                this.gameObject.AddComponent<CreateWhirlpool>().Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateWhirlpool>().Trigger();
            return;
        }
        if (ID == 574)
        {
            if (this.gameObject.GetComponent<CreateScratch>() == null)
            {
                this.gameObject.AddComponent<CreateScratch>().Create(ID);
            }
            else
                this.gameObject.GetComponent<CreateScratch>().Trigger();
            return;
        }
        if (ID == 575)
        {
            //Debug.Log(1230);
            if (this.gameObject.GetComponent<CreatePhantom>() == null)
            {
                this.gameObject.AddComponent<CreatePhantom>().Create(ID);
            }
            else
                this.gameObject.GetComponent<CreatePhantom>().Trigger();
            return;
        }

    }



    public void RemoveSkill(int ID)
    {
    }


    public override void OnNotify(string msg)
    {
        //Debug.Log(msg);

        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("BossSkill", msg, 0);
        if (bID != "Fail" && bID != "Error")
            CreateSkill(int.Parse(bID)+BossID*10+500);

    }

    /// <summary>
    /// 负责初始化人物\怪物的技能
    /// </summary>
    void Start()
    {
        this.gameObject.GetComponent<Character>().AddObserver(this);
        BossID = (this.gameObject.GetComponent<Character>().RoomElementID - 2050)%100;

    }

    public void DestoryManager()
    {
        this.gameObject.GetComponent<Character>().RemoveObserver(this);
    }

    void Awake()
    {
        SkillManagerTag = "" + this.gameObject.tag;
        //EsscenceManager.Instance.AddObserver(this);
    }
}

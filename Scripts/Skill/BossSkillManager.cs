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
        //科学怪人的技能生成，触发
        if (ID == 500)
        {
            CreateLaser newSkill;
            if (this.gameObject.GetComponent<CreateLaser>() == null)
                newSkill = this.gameObject.AddComponent<CreateLaser>();
            else
                this.gameObject.GetComponent<CreateLaser>().Trigger();
            return;
        }

        if (ID == 501)
        {
            CreateChemistry newSkill;
            if (this.gameObject.GetComponent<CreateChemistry>() == null)
                newSkill = this.gameObject.AddComponent<CreateChemistry>();
            else
                this.gameObject.GetComponent<CreateChemistry>().Trigger();
            return;
        }

        if (ID == 502)
        {
            CreateScratch newSkill;
            if (this.gameObject.GetComponent<CreateScratch>() == null)
                newSkill = this.gameObject.AddComponent<CreateScratch>();
            else
                this.gameObject.GetComponent<CreateScratch>().Trigger();
            return;
        }


    }



    public void RemoveSkill(int ID)
    {
    }


    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("BossSkill", msg, 0);
        if (bID != "Fail" && bID != "Error")
            CreateSkill(int.Parse(bID)+BossID*100);

    }

    /// <summary>
    /// 负责初始化人物\怪物的技能
    /// </summary>
    void Start()
    {
        Player.Instance.GetComponent<Character>().AddObserver(this);
        BossID = this.gameObject.GetComponent<Character>().RoomElementID - 250;

    }

    public void DestoryManager()
    {
        Player.Instance.GetComponent<Character>().RemoveObserver(this);
    }

    void Awake()
    {
        SkillManagerTag = "" + this.gameObject.tag;
        //EsscenceManager.Instance.AddObserver(this);
    }
}

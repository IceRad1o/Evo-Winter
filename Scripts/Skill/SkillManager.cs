using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : ExSubject
{
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
    }

    public void UseSkill_L() { 
    
    
    }


    public override void OnNotify(string msg)
    {
        string bID = "";


        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Skill_ID", msg, 0);
        if (bID != "Fail" && bID!="Error")
            CreateSkill(int.Parse(bID));

    }

    /// <summary>
    /// skillManager负责初始化人物\怪物的技能
    /// </summary>
    void Start()
    {
        if (this.tag=="Player")
            ItemManager.Instance.AddObserver(this);
        if (this.gameObject.tag=="Player") 
        {
            switch (this.gameObject.GetComponent<Character>().Race)
            {
                case 0:
                    SpeedUp newSkill = this.gameObject.AddComponent<SpeedUp>();
                    newSkill.Create(this.gameObject.GetComponent<Character>().Race);
                    skillList.Add(newSkill);
                    break;
                default:
                    break;
            }
                 
        }
	
    }

}

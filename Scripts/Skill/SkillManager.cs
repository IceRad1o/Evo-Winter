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
        }
        
    }

    public void UseSkill_L() { 
    
    
    }


    public override void OnNotify(string msg)
    {
        string bID = "";


        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Skill_ID", msg, 1);
        if (bID != "Error")
            CreateSkill(int.Parse(bID));

    }

    /// <summary>
    /// skillManager负责初始化人物\怪物的技能
    /// </summary>
    void Start()
    {
        if (this.gameObject.tag=="Player") 
        {
            LSkill newSkill = this.gameObject.AddComponent<LSkill>();
            newSkill.Create(this.gameObject.GetComponent<Character>().Race);
            skillList.Add(newSkill);        
        }
	
    }
}

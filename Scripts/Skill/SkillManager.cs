using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : ExSubject
{
    List<Skill> skillList = new List<Skill>(); 

    public void CreateSkill(int ID) { 
    
        
    }



    public override void OnNotify(string msg)
    {
        string bID = "";


        bID = UtilManager.Instance.MatchFiledFormMsg("UseItem_Buff_ID", msg, 1);
        if (bID != "Error")
            CreateSkill(int.Parse(bID));

    }
}

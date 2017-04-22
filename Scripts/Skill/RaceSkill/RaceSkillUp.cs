using UnityEngine;
using System.Collections;

public class RaceSkillUp : Skill {

    public override void Create(int ID)
    {
        Trigger();
    }

    public override void Trigger()
    {
        this.GetComponent<SkillManager>().Skill_L_Up = !this.GetComponent<SkillManager>().Skill_L_Up;  
    }

    public override void skillDestory()
    {
        this.GetComponent<SkillManager>().Skill_L_Up = !this.GetComponent<SkillManager>().Skill_L_Up;
        Destroy(this);
    }


	
	
}

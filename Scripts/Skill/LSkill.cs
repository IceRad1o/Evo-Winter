using UnityEngine;
using System.Collections;

public class LSkill : Skill {

    public override void Create(int ID)
    {
        base.Create(ID);
        switch (ID)
        {
            case 1:
                Cd = 10.0f;
                break;

            default:
                break;
        }

    }

	void Start () {
	
	}
}

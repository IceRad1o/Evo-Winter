using UnityEngine;
using System.Collections;

public class CreateScratch : Skill {

    public override void Trigger()
    {
        base.Trigger();
        Cd = 1;

        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Scratch", Player.Instance.transform.position);
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

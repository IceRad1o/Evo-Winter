using UnityEngine;
using System.Collections;

public class CreateLaser : Skill {

    public override void Trigger()
    {
        base.Trigger();
        Cd = 4;

        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Laser", this.gameObject.transform.position);
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

using UnityEngine;
using System.Collections;

public class Mud : Skill {

    public override void Trigger()
    {
        base.Trigger();
        Cd = 5;

        UtilManager.Instance.CreateEffcet("Prefabs/Skill/Skill4", this.gameObject.transform.position);

    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

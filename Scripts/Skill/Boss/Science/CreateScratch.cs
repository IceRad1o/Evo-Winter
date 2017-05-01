using UnityEngine;
using System.Collections;

public class CreateScratch : Skill {

    public override void Trigger()
    {
        base.Trigger();
        Cd = 1;

        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Scratch", transform.position+new Vector3(GetComponent<Character>().FaceDirection,0,0));
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

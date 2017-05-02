using UnityEngine;
using System.Collections;

public class Distortion : Skill {

    public override void Trigger()
    {
        base.Trigger();
        Cd = 1;

        this.GetComponent<BuffManager>().CreateDifferenceBuff((this.GetComponent<Character>().MoveSpeed/2)*1000000000+020001112);
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

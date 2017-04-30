using UnityEngine;
using System.Collections;

public class CreateChemistry : Skill {


    public override void Trigger()
    {
        base.Trigger();
        Cd = 5;
        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Chemistry", this.gameObject.transform.position);       
    }
    

    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

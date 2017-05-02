using UnityEngine;
using System.Collections;

public class CreateLaser : Skill {

    public float CdBuff = 1;
    public override void Trigger()
    {
      
        Cd = 8*CdBuff;
        base.Trigger();
        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Laser", this.gameObject.transform.position+new Vector3(0,0.5f,0));
        
        
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

﻿using UnityEngine;
using System.Collections;

public class CreateChemistry2 : CreateChemistry {

    public override void Trigger()
    {
       
        Cd = 5;
        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Chemistry2", this.gameObject.transform.position);
       
    }


    public override void Create(int ID)
    {
        base.Create(ID);
  
    }
}

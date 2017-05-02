using UnityEngine;
using System.Collections;

public class CreateScratch : Skill {

    public float CdBuff = 1;
    public override void Trigger()
    {
        base.Trigger();
        Cd = 1*CdBuff;

        GameObject a=UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Scratch", transform.position+new Vector3(GetComponent<Character>().FaceDirection,0.6f,0));
        if (GetComponent<Character>().FaceDirection == 1)
            a.GetComponent<SpriteRenderer>().flipX = true;
    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

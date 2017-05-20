using UnityEngine;
using System.Collections;

public class CreateLaser : Skill {

    public float CdBuff = 1;
    public GameObject point;
    public override void Trigger()
    {
      
        Cd = 8*CdBuff;
        base.Trigger();
        StartCoroutine(Func());
      
        
        
    }

    public IEnumerator Func()
    {

        //Vector3 targetPos = Player.Instance.transform.position;
       GameObject a= UtilManager.Instance.CreateEffcet("Skill/Boss/Science/LaserRect", transform.position);
       if (GetComponent<Character>().FaceDirection == 1)
           a.GetComponent<ScaleTo>().destValue *= -1;

        yield return new WaitForSeconds(1.5f);

        UtilManager.Instance.CreateEffcet("Skill/Boss/Science/Laser", point.transform.position);
   


    }

    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

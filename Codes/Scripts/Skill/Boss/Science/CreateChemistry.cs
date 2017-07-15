using UnityEngine;
using System.Collections;

public class CreateChemistry : Skill {

    public float CdBuff=1;
    public override void Trigger()
    {
        Cd = 5*CdBuff;
        base.Trigger();
        StartCoroutine(Func());

       
        
       
    }
    
    public IEnumerator Func()
    {

        Vector3 targetPos = Player.Instance.transform.position;
        UtilManager.Instance.CreateEffcet("Prefabs/Skill/Boss/Science/ChemistryAim", targetPos);  


        yield return new WaitForSeconds(0.5f);

        GameObject a=UtilManager.Instance.CreateEffcet("Prefabs/Skill/Boss/Science/Chemistry2", this.gameObject.transform.position);
        a.GetComponent<Chemistry>().targetPos = targetPos;


    }



    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

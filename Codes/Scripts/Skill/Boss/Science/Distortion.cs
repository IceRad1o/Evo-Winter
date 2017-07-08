using UnityEngine;
using System.Collections;
/// <summary>
/// 行动速度加快
/// </summary>
public class Distortion : Skill {

    public GameObject[] particles;

    public override void Trigger()
    {
 
        Cd = 999;
        base.Trigger();
        this.GetComponent<BuffManager>().CreateDifferenceBuff((this.GetComponent<Character>().Mov/2)*1000000000+020001112);

        this.GetComponent<CreateChemistry>().CdBuff = 0.67f;
        this.GetComponent<CreateScratch>().CdBuff = 0.67f;
        this.GetComponent<CreateLaser>().CdBuff = 0.67f;
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(true);
        }

    }


    public override void Create(int ID)
    {
        base.Create(ID);
        Trigger();
    }
}

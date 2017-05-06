﻿using UnityEngine;
using System.Collections;
/// <summary>
/// 创建幻象
/// </summary>
public class CreatePhantom : Skill {


    public GameObject faker;

    public override void Trigger()
    {
        Cd = 100;
        base.Trigger();
        StartCoroutine(SkillTrigger());
    }

    private IEnumerator SkillTrigger()
    {

        yield return new WaitForSeconds(0.3f);
        Instantiate(faker).GetComponent<Character>().Health=GetComponent<Character>().Health/2;
        Instantiate(faker).GetComponent<Character>().Health = GetComponent<Character>().Health / 2;
    }
	
}

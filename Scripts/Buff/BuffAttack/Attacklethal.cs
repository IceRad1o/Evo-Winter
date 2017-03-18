﻿using UnityEngine;
using System.Collections;

public class Attacklethal : BuffAttack
{

    int enemyID;

    protected override void Trigger()
    {
        if (JudgeTrigger())
        {
            CharacterManager.Instance.CharacterList[enemyID].Health = 0;
        }

    }
    protected override void Create(int ID)
    {
        base.Create(ID);
        Probability = 100;
    }

    // Use this for initialization
    void Start()
    {

    }

    public override void OnNotify(string msg)
    {
        string bID = "";

        bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 0);
        if (bID == "Enemy")
        {
            bID = UtilManager.Instance.MatchFiledFormMsg("AttackHit", msg, 1);
            enemyID = int.Parse(bID);
            Trigger();
        }
    }
}

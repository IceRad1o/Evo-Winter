using UnityEngine;
using System.Collections;

public class Monster : Enemy{

    public override void Start()
    {
        base.Start();
        this.tag = "Monster";
        //EnemyManager.Instance.EnemyList.Add(this);
    }



}

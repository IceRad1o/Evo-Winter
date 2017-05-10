using UnityEngine;
using System.Collections;

public class Monster : Enemy{

    public override void Awake()
    {
        base.Awake();
        this.tag = "Monster";
        //EnemyManager.Instance.EnemyList.Add(this);
    }



}

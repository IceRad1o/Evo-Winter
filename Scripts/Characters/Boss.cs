using UnityEngine;
using System.Collections;

public class Boss :Enemy{

    public override void Start()
    {
        base.Start();
        this.tag = "Boss";
        //EnemyManager.Instance.EnemyList.Add(this);
    }

}

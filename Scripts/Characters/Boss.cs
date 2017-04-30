using UnityEngine;
using System.Collections;

public class Boss :Enemy{

    int stage=1;
   // int maxHealth=50;
    float healthPercent=1f;

    public float HealthPercent
    {
        get { return healthPercent; }
        set { 
            healthPercent = value;
            Notify("HealthPercent;" + healthPercent);
        }
    }
    public override void Start()
    {
        base.Start();
        this.tag = "Boss";
        this.AddObserver(BossHealthBar.Instance);
        Notify("BossAppear");
        //EnemyManager.Instance.EnemyList.Add(this);
    }


    public override int Health
    {
        get
        {
            return base.Health;
        }
        set
        {
            base.Health = value;
            HealthPercent =1.0f* Health / initialHealth;


        }
    }
}

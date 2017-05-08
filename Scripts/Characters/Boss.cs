using UnityEngine;
using System.Collections;

public class Boss :Enemy{

    int stage=1;
   // int maxHealth=50;
    float healthPercent=1f;
    public GameObject box;

    public float HealthPercent
    {
        get { return healthPercent; }
        set {
            float tmp = healthPercent;
            healthPercent = value;
            Notify("HealthPercent;" + healthPercent+";"+tmp);
        }
    }
    public override void Start()
    {
        base.Start();
        this.tag = "Boss";
        this.IsSuperArmor = 1;
        this.AddObserver(BossHealthBar.Instance);
        Notify("BossAppear;"+(RoomElementID-2050));
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

    public override void Die()
    {
        Vector3 bossPos = this.transform.position;
        Vector3 startPoint = bossPos + new Vector3(0, 2, 0);
        int num = Random.Range(2, 4);
        for (int i = 0; i < num; i++)
        {
            Vector3 deltaPos = new Vector3((Random.value-0.5f) * 5, (Random.value-0.5f) * 5);
            GameObject ins = Instantiate(box, startPoint, Quaternion.identity) as GameObject;
            Vector3[] paths = new Vector3[3];
            paths[0] = startPoint;
            paths[1] = startPoint + deltaPos / 3 + new Vector3(0, 1.5f, 0);
            paths[2] = bossPos + deltaPos;
            iTween.MoveTo(ins, iTween.Hash("path", paths, "speed", 30f, "easeType", iTween.EaseType.easeInQuad));
        }
        base.Die();
    }

}

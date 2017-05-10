using UnityEngine;
using System.Collections;

public class FakeBoss : Monster
{

    public GameObject trueBoss;
    public override void Awake()
    {
        base.Awake();
        this.tag = "FakeBoss";
        this.IsSuperArmor = 1;
    }



}

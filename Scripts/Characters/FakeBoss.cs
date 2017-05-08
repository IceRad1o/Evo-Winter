using UnityEngine;
using System.Collections;

public class FakeBoss : Monster {

    public GameObject trueBoss;
	void Start () {
        base.Start();
        this.tag = "FakeBoss";
        this.IsSuperArmor = 1;
	}
	

}

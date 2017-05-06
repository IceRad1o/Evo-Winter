using UnityEngine;
using System.Collections;

public class FakeBoss : Monster {


	void Start () {
        base.Start();
        this.tag = "FakeBoss";
        this.IsSuperArmor = 1;
	}
	

}

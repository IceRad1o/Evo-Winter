using UnityEngine;
using System.Collections;

public class HardArmor : BuffTiming {


    public override void Create(int ID, string spTag = "")
    {
        
    }
	// Update is called once per frame
	void Update () {
        foreach (var item in this.GetComponents<BeatBack>())
        {
            Destroy(item);
        }
	}
}

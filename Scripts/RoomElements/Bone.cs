using UnityEngine;
using System.Collections;
/// <summary>
/// 骨头
/// </summary>
public class Bone : RoomElement {

    public override void Awake()
    {
        base.Awake();
        RoomElementID = 12;
        this.tag = "DynamicGroundElement";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// </summary>
public class Bottle2 : RoomElement
{

    public override void Awake()
    {
        base.Awake();
        RoomElementID = 11;
        this.tag = "DynamicGroundElement";
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
using System.Collections;

public class Plate : RoomElement {

	public override void Awake()
	{
		base.Awake();
		RoomElementID = 20;
	}
}

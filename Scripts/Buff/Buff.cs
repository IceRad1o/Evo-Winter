using UnityEngine;
using System.Collections;
/// <summary>
/// 包括改变属性（回合/永久），特殊攻击特效等
/// </summary>
public class Buff : MonoBehaviour {

    private int buffID;

    public int BuffID
    {
        get { return buffID; }
    }


    public void Create(int ID)
    {
        buffID = ID;     
    
    }




	// Use this for initialization
	void Start () {
	
	}
	
}

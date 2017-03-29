using UnityEngine;
using System.Collections;

public class BuffTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
       StartCoroutine(Test());
       
	}
    IEnumerator Test() 
    {
        yield return new WaitForSeconds(1.0f);
        //this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(710001200);
        this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(700110);
        this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(7100);
        //ItemManager.Instance.SendMsg("UseItem_Buff_ID;400011200");
    
    }
	
}

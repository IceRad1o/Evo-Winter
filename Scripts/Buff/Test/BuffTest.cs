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
        this.gameObject.GetComponent<BuffManager>().CreateBuff(1000001);
    
    
    }
	
}

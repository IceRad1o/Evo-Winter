using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

    public GameObject pfb;

	void Start () {
        if(this.tag=="Player")
            StartCoroutine(Test());
        
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        //this.gameObject.GetComponent<Character>().Atk = 9;
        //UtilManager.Instance.CreateEffcet(pfb);
        //this.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(704100);
        //CoinManager.Instance.CreateCoin(1);
        Debug.Log("hhhhhhhhhhhhhhhhh");
        ItemManager.Instance.CreateItemID(1002, new Vector3(3, -1, -1));
        ItemManager.Instance.CreateItemID(1002, new Vector3(2, -1, -1));
        ItemManager.Instance.CreateItemID(1002, new Vector3(-4, -1, -1));
        ItemManager.Instance.CreateItemID(1002, new Vector3(-3, -1, -1));
        ItemManager.Instance.CreateItemID(1002, new Vector3(-2, -1, -1));
        ItemManager.Instance.CreateItemID(1002, new Vector3(-1, -1, -1));
        ItemManager.Instance.CreateItemID(1502, new Vector3(1, -1, -1));

    }
	
}

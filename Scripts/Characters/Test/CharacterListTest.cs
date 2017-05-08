using UnityEngine;
using System.Collections;

public class CharacterListTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        while(true)
        {
            Debug.Log("List Count:"+CharacterManager.Instance.CharacterList.Count);
            int i = 0;
            foreach (Character item in CharacterManager.Instance.CharacterList)
                Debug.Log("List Item"+i+++" Tag:"+item.tag);
            yield return new WaitForSeconds(1f);
        }
 
    }
}

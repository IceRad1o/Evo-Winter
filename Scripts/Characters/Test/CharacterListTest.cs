using UnityEngine;
using System.Collections;
using System.Text;
public class CharacterListTest : MonoBehaviour {
    public enum Kd
    {
        normal,
        hard
    }
    Kd ra=Kd.normal;
	// Use this for initialization
	void Start () {
        int tmp = 1;
        StringBuilder s = new StringBuilder(32);
        s.Append("RaceChanged").Append(tmp).Append(ra);
        Debug.Log(s);
        StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        while(true)
        {
            Debug.Log("List Count:"+CharacterManager.Instance.CharacterList.Count);
            int i = 0;
            foreach (Character item in CharacterManager.Instance.CharacterList)
                Debug.Log("List Item"+i+++" Tag:"+item.tag);//+",Position:"+item.transform.position);
            yield return new WaitForSeconds(1f);
        }
 
    }
}

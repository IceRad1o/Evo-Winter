using UnityEngine;
using System.Collections;

public class PygmyMageSkill : MonoBehaviour {

    public GameObject[]effects;
    public GameObject[] objs;
    int type;
	// Use this for initialization
	void Start () {
       
	}


    IEnumerator IEnumSkill()
    {
        Vector3 pos = this.transform.position;
        Instantiate(effects[type], pos, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(objs[type], pos, Quaternion.identity);
    }

    void InstantiateObj(int type)
    {
        this.type = type;
        StartCoroutine(IEnumSkill());
       

    }
}

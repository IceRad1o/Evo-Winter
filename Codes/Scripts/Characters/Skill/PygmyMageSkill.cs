using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PygmyMageSkill : MonoBehaviour {

    public GameObject[]effects;
    public GameObject[] objs;

    List<GameObject> instances=new List<GameObject>();

    int type;
	// Use this for initialization
	void Start () {
       
	}


    IEnumerator IEnumSkill()
    {
        Vector3 pos = this.transform.position;
        Instantiate(effects[0], pos, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ClearDeadPuppets();
        instances.Add(UtilManager.Instantiate(objs[type], pos));

        RemainLimitedPuppets(3);
    }

    void InstantiateObj(int type)
    {
        this.type = type;
        StartCoroutine(IEnumSkill());
       

    }

    void ClearDeadPuppets()
    {
        for(int i=instances.Count-1;i>=0;i--)
        {
            if(instances[i]==null)
            {
                instances.RemoveAt(i);
            }

        }
    }

    void RemainLimitedPuppets(int num)
    {
        while (instances.Count > num)
        {
            instances[0].GetComponent<RoomElement>().Destroy();
            instances.RemoveAt(0);
        }
    }


}

using UnityEngine;
using System.Collections;

public class MyHook : MonoBehaviour {

    public string[] destTags;

    public bool isWork = false;
    Vector3 offset;
    GameObject tar;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("tag    :" + other.tag);

        if (isWork)
            return;
        string destTag=other.tag;

        for (int i = 0; i < destTags.Length; i++)
        {
            if (destTag == destTags[i])
            {
                isWork = true;
                tar = other.gameObject;
                other.GetComponent<RoomElement>().Hp--;
                offset = tar.transform.position - this.transform.position;
            }
        }
    }

    void Update()
    {
        if (isWork)
        {
            if(tar!=null)
                tar.transform.position = this.transform.position + offset;
        } 
    }
}

using UnityEngine;
using System.Collections;

public class Twinkle : Skill {

    bool isSecond = false;
    GameObject prefabInstance;

    public override void Trigger()
    {

        GameObject pfb = Resources.Load("Prefabs/Skill/Twinkle") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;

        this.gameObject.transform.position = new Vector3(this.gameObject.GetComponent<Character>().Direction.x *2.0f+ this.gameObject.transform.position.x , this.gameObject.GetComponent<Character>().Direction.y*2.0f+this.gameObject.transform.position.y, this.gameObject.GetComponent<Character>().Direction.y*2.0f+this.gameObject.transform.position.y);

        
    }


    // Use this for initialization
    void Start()
    {
        Trigger();
    }
	

}

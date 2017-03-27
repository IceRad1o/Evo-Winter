using UnityEngine;
using System.Collections;

public class NamikazeMinato : Skill {

    bool isSecond=false;
    GameObject prefabInstance;

    public override void Trigger()
    {
        if (!isSecond)
        {
            GameObject pfb = Resources.Load("Skill/Kunai") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            prefabInstance = Instantiate(pfb);
            prefabInstance.transform.position = s;
            isSecond = true;
        }
        else
        {
            this.gameObject.transform.position = prefabInstance.transform.position;
            Destroy(prefabInstance);
            isSecond = false;
        }
    }


	// Use this for initialization
	void Start () {
        Trigger();
	}

}

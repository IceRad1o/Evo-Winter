using UnityEngine;
using System.Collections;

public class DoubleEsscence : Skill {

    bool isSecond = false;
    GameObject prefabInstance;

    public override void Trigger()
    {
        EsscenceManager.Instance.doubleEsscence = true;

        GameObject pfb = Resources.Load("Prefabs/Buffs/devil") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        GameObject prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;
    }


    // Use this for initialization
    void Start()
    {
        Trigger();
    }
}

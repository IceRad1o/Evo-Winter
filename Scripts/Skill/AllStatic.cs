using UnityEngine;
using System.Collections;

public class AllStatic : Skill {

    public override void Trigger()
    {
        Debug.Log("Number : " + CharacterManager.Instance.CharacterList.ToArray().Length);

        foreach (var item in CharacterManager.Instance.CharacterList.ToArray())
        {
            if (item != null)
            {
                item.GetComponent<BuffManager>().CreateDifferenceBuff(704111);
            
            }
        }

        GameObject pfb = Resources.Load("Skill/AllStatic") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);
        GameObject prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;

        Destroy(this);
    }



    // Use this for initialization
    void Start()
    {
        Trigger();
    }
}

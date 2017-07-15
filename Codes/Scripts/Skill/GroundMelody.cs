using UnityEngine;
using System.Collections;

public class GroundMelody : Skill {

    public override void Trigger()
    {
        Debug.Log("Number : " + CharacterManager.Instance.CharacterList.ToArray().Length);

        foreach (var item in CharacterManager.Instance.CharacterList.ToArray())
        {
            if (item != null && item.tag=="Monster")
            {
                Debug.Log("sas");
                BeatBack b=item.gameObject.AddComponent<BeatBack>();
                b.level = 10;
                b.direction = item.transform.position.x >= this.transform.position.x ? 1 : -1;

            }
        }

        GameObject pfb = Resources.Load("Prefabs/Skill/GroundMelody") as GameObject;
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

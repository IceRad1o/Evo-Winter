using UnityEngine;
using System.Collections;

public class WholeDamage : Skill {


    public override void Trigger()
    {
        Debug.Log("Number : " + CharacterManager.Instance.CharacterList.ToArray().Length);

        foreach (var item in CharacterManager.Instance.CharacterList.ToArray())
	    {
            item.GetComponent<Character>().Hp -= item.GetComponent<Character>().Hp / 3;
	    }

        Destroy(this);
    }



    // Use this for initialization
    void Start()
    {
        Trigger();
    }
	
}

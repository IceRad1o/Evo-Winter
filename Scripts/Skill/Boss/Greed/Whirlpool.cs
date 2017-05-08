using UnityEngine;
using System.Collections;

public class Whirlpool : MonoBehaviour {

    float destroyTime = 10.0f;


    /*每隔几秒造成伤害*/
    void OnTriggerEnter(Collider other)
    {

        Character ch = other.GetComponent<Character>();
    }



    void Start()
    {



    }


    void FixedUpdate()
    {
        foreach(Character ch in CharacterManager.Instance.CharacterList)
        {
            //Debug.Log("tag:" + ch.tag);
            if (ch.tag == "Boss"||ch.tag=="FakeBoss")
                return;
            if (ch == null)
                return;
            Vector3 delta =  transform.position-ch.transform.position ;
            float distance = delta.magnitude;
            if (distance < 1)
                continue;
            float speed=0.015f+0.02f/distance;//speed与(k/distance+b)正比
            ch.transform.position+=delta.normalized*speed;

        }
    }

}

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


    void Update()
    {
        foreach(Character ch in CharacterManager.Instance.CharacterList)
        {
            Vector3 delta =  transform.position-ch.transform.position ;
            float distance = delta.sqrMagnitude;
            if (distance < 1)
                continue;
            float speed=1.0f/distance;
            ch.transform.position+=delta.normalized*speed;

        }
    }

}

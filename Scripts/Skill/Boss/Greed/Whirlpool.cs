using UnityEngine;
using System.Collections;

public class Whirlpool : MonoBehaviour {

    /*每隔几秒造成伤害*/
    void OnTriggerEnter(Collider other)
    {

        Character ch = other.GetComponent<Character>();
    }



    void Start()
    {

    }

}

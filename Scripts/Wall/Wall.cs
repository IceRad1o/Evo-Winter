using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    Vector3 point;
    void OnTriggerEnter2D(Collider2D other)
    {
        //other.transform.po
        //other.GetComponent<Transform>()

        point = other.transform.position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.transform.position=point;
    }
}

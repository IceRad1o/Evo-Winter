using UnityEngine;
using System.Collections;

public class DontDestroyObject : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}

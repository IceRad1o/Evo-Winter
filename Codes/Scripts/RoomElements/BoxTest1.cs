using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxTest1 : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Test()
    {
        Box box = GetComponent<Box>();
        while (true)
        {
            int open = (int)Input.GetAxisRaw("Fire1");
            if (open != 0)
            {
                box.OpenBox();
                break;
            }
            else 
                yield return null;
        }
    }
}
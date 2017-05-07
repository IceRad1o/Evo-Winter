using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShowRange : MonoBehaviour {

   public  GameObject a;
   public  float range = 5;
    List<GameObject> list=new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject ins = Instantiate(a) as GameObject;
            list.Add(ins);
        }
    }

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            float x = Mathf.Cos(18 * i) * range;
            float y = Mathf.Sin(18 * i) * range;
            list[i].transform.position = transform.position + new Vector3(x, y/2, y/2);

        }
    }


}

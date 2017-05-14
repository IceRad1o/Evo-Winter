using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShowRange : MonoBehaviour {

   public  GameObject a;
   public  float range = 5;
    List<GameObject> list=new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject ins = Instantiate(a) as GameObject;
            list.Add(ins);
        }
      
    }

    void Update()
    {
        for (int i = 0; i < 30; i++)
        {
            float x = Mathf.Cos((12 * i/180.0f*Mathf.PI)) * range;
            float y = Mathf.Sin((12 * i / 180.0f * Mathf.PI)) * range;
            list[i].transform.position = transform.position + UtilManager.Trans(x, y);
            

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}

using UnityEngine;
using System.Collections;

public class GiftWater : MonoBehaviour {

    public int type;//0-5
    int[] attributeList = { 5, 2, 4, 3, 6,9 };
    public bool isRandom = true;
    GameObject boss;

    public GameObject Boss
    {
        get { return boss; }
        set { boss = value; }
    }
    void Start()
    {
        if (isRandom)
            type = Random.Range(0, 6);
    }

     void OnTriggerEnter(Collider other)

    {

        if(other.tag=="Player")
        {
           
            Player.Instance.GetComponent<BuffManager>().CreateDifferenceBuff((100 + attributeList[type]) * 10000000 + 1001110);

            if (Boss!=null&&Boss.GetComponent<GreedValue>().Value<10)
                 Boss.GetComponent<GreedValue>().Value++;
            //Debug.Log(Boss.GetComponent<GreedValue>().Value);
            Destroy(gameObject);
        }
        if(other.tag=="Monster")
        {
            other.GetComponent<BuffManager>().CreateDifferenceBuff((100 + attributeList[type]) * 10000000 + 1001110);
            Destroy(gameObject);
        }

    }
}

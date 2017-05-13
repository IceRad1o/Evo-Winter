using UnityEngine;
using System.Collections;

public class Scratch : MonoBehaviour {

    public string attackTag;
    public GameObject prefabInstanceHit;
    public GameObject prefabInstanceRecovery;




    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter    :" + other.tag);
        if (other.tag == attackTag)
        {
            
            UtilManager.Instance.CreateEffcet(prefabInstanceHit, other.gameObject);

            //other.gameObject.GetComponent<Character>().Health--;
            foreach (var item in EnemyManager.Instance.EnemyList.ToArray())
            {
                if (item != null && item.tag == "Boss")
                {
                    if(item.Hp>=item.oHp)
                        item.GetComponent<Character>().Hp++;
                    UtilManager.Instance.CreateEffcet(prefabInstanceRecovery, other.gameObject);
                }
            }
        }

    }
}

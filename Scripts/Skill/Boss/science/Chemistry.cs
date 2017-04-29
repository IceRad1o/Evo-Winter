using UnityEngine;
using System.Collections;

public class Chemistry : MonoBehaviour {

    public int[] effect;
    public string attackTag;
    GameObject[] pfb;
    Enemy pfb_enemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter    :" + other.tag);
        if (other.tag == attackTag)
        {
            int result = (int)(Random.value * 5);
            //判断人物与化合物爆炸的距离
            Vector3 pos = this.gameObject.transform.position;
            Vector3 posJudge = Player.Instance.gameObject.transform.position;
            var i = (pos.x - posJudge.x) * (pos.x - posJudge.x) + (pos.y - posJudge.y) * (pos.y - posJudge.y);
            //爆炸
            if (result == 0)
            {
                UtilManager.Instance.CreateEffcet(pfb[0], other.gameObject.transform.position);                
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<Character>().Health--;            
            }
            //减速
            if (result==1)
            {
                UtilManager.Instance.CreateEffcet(pfb[1], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            //致盲 （未做）
            if (result == 2)
            {
                UtilManager.Instance.CreateEffcet(pfb[2], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            //迟钝
            if (result == 3)
            {
                UtilManager.Instance.CreateEffcet(pfb[3], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1031502110);
            }
            //混乱 （未做）
            if (result == 4)
            {
                UtilManager.Instance.CreateEffcet(pfb[4], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            if (result == 5)
            {
                UtilManager.Instance.CreateEffcet(pfb[5], other.gameObject.transform.position);
                Enemy em = Instantiate(pfb_enemy) as Enemy;
            
            }
        }

    }
}

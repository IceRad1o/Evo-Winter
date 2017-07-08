using UnityEngine;
using System.Collections;

public class Chemistry : MonoBehaviour {

    public int[] effect;
    public string attackTag;
    GameObject[] pfb = new GameObject[6];
    public GameObject pfb_enemy;
    public Vector3 targetPos;
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Enter    :" + other.tag);

        if (other.tag == attackTag)
        {
            var random=new System.Random((int)System.DateTime.Now.Second);
            int result = (int)(random.Next(6));
            //判断人物与化合物爆炸的距离
            Vector3 pos = this.gameObject.transform.position;
            Vector3 posJudge = targetPos;
            var i = (pos.x - posJudge.x) * (pos.x - posJudge.x) + (pos.y - posJudge.y) * (pos.y - posJudge.y);
            //爆炸
            if (result == 0)
            {
                if (pfb[0]!=null)
                    UtilManager.Instance.CreateEffcet(pfb[0], other.gameObject.transform.position);                
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<Character>().Hp--;            
            }
            //减速
            if (result==1)
            {
                if (pfb[1] != null)
                    UtilManager.Instance.CreateEffcet(pfb[1], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            //致盲 （未做）
            if (result == 2)
            {
                if (pfb[2] != null)    
                    UtilManager.Instance.CreateEffcet(pfb[2], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            //迟钝
            if (result == 3)
            {
                if (pfb[3] != null)
                    UtilManager.Instance.CreateEffcet(pfb[3], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1031502110);
            }
            //混乱 （未做）
            if (result == 4)
            {
                if (pfb[4] != null)
                    UtilManager.Instance.CreateEffcet(pfb[4], other.gameObject.transform.position);
                if (i <= 16)
                    Player.Instance.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(1021502110);
            }
            if (result == 5)
            {
                if (pfb[5] != null)
                    UtilManager.Instance.CreateEffcet(pfb[5], other.gameObject.transform.position);
                Instantiate(pfb_enemy,transform.position,Quaternion.identity);
            
            }


            Debug.Log("Result    :" + result);
            Destroy(this.gameObject);
        }

    }

    public virtual void Start()
    {
        this.gameObject.AddComponent<MoveTo>().destPosition = targetPos;

    }
}

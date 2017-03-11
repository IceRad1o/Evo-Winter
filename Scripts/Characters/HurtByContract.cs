using UnityEngine;
using System.Collections;

public class HurtByContract : MonoBehaviour
{

    public int camp;
    /// <summary>
    /// 造成伤害后是否销毁
    /// </summary>
    public int isDestory=0;
    public GameObject HitPrefab;
    private Vector3 tempPosition;
    private Vector3 lastPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //记录下之前的位置
        lastPosition = tempPosition;
        tempPosition = transform.position;
    }

    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.tag == "EnemyRB2D" && camp == 0) || (other.tag == "PlayerRB2D" && camp == 1))
        {
            //Debug.Log("Enemy hurt!" + other.GetComponent<Character>().Health);
            other.GetComponentInParent<Character>().Health--;
            
        }

        if (isDestory != 0)
            Destroy(gameObject);
    }



}

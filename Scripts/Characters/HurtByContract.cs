using UnityEngine;
using System.Collections;
/// <summary>
/// 碰撞产生伤害脚本.
/// </summary>
public class HurtByContract : MonoBehaviour
{
    /// <summary>
    /// 被伤害的对象
    /// </summary>
    public string[] destTags;
    /// <summary>
    /// 伤害:>=0
    /// </summary>
    public int damage = 1;
    /// <summary>
    /// 击退效果等级:>=0
    /// </summary>
    public int beatBackLevel = 0;
    /// <summary>
    /// 击倒效果等级:>=0
    /// </summary>
    public int beatDownLevel = 0;
    /// <summary>
    /// 造成伤害后是否销毁
    /// </summary>
    public int isDestory = 0;
    /// <summary>
    /// 造成伤害时产生的特效
    /// </summary>
    public GameObject hitPrefab;


    /// <summary>
    /// 3D碰撞检测,对于不同物体有
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {
        string destTag=other.tag;

        for (int i = 0; i < destTags.Length;i++ )
        {
            if(destTag==destTags[i])
            {
                Character ch = other.GetComponent<Character>();
                if (ch.IsAlive < 0 || ch.Invincible == 1)
                    return;
                ch.Health -= damage;
                if (beatBackLevel > 0)
                {
              
                    BeatBack b=ch.gameObject.AddComponent<BeatBack>();
                    b.level = beatBackLevel;
                    b.direction = ch.transform.position.x >= this.transform.position.x ? 1 : -1;
                }
                if (beatDownLevel > 0)
                {
                    
                    BeatDown b = ch.gameObject.AddComponent<BeatDown>();
                    b.level = beatDownLevel;
                    b.direction = ch.transform.position.x >= this.transform.position.x ? 1 : -1;
                }
                if(hitPrefab!=null)
                {
                    Instantiate(hitPrefab, this.transform.position, Quaternion.identity);
                }
                if (isDestory != 0)
                    Destroy(gameObject);
            }
        }

        return;




 
    }



}

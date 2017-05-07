using UnityEngine;
using System.Collections;
/// <summary>
/// 碰撞产生伤害脚本.
/// </summary>
public class HurtByContract : MonoBehaviour
{
    /// <summary>
    /// 碰撞体从属角色
    /// </summary>
    public Character ch1;
    /// <summary>
    /// 是否是武器
    /// </summary>
    public bool isWeapon;
    /// <summary>
    /// 是否自动生成标签
    /// </summary>
    public bool autoTag=true;
    /// <summary>
    /// 被伤害的对象的标签
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
    public int beatDownLevelX = 0;
    /// <summary>
    /// 击倒效果等级:>=0
    /// </summary>
    public int beatDownLevelY = 0;
    /// <summary>
    /// 造成伤害后是否销毁
    /// </summary>
    public int isDestory = 0;
    /// <summary>
    /// 造成伤害时产生的特效
    /// </summary>
    public GameObject hitPrefab;


    void Start()
    {
        if(isWeapon)
            ch1 = this.GetComponentInParent<Character>();
        if(autoTag&&ch1!=null)
        {
            if(ch1.tag=="Player")
            {
                destTags=new string[]{"Enemy","Monster","Boss","RoomElement","FakeBoss"};
            }
            else if (ch1.tag == "Friend")
            {
                destTags = new string[] { "Enemy", "Monster", "Boss", "RoomElement" };
            }
            else if(ch1.tag=="Enemy")
            {
                destTags = new string[] { "Player", "Friend"};
            }
            else if(ch1.tag=="Monster")
            {
                destTags = new string[] { "Player", "Friend" };
            }
            else if(ch1.tag=="Boss")
            {
                destTags = new string[] { "Player", "Friend" };
            }
        }
    }


    public void Init(int damage,int beatBackLevel,int beatDownLevelX,int beatDownLevelY,Character ch)
    {
        this.damage = damage;
        this.beatBackLevel=beatBackLevel;
        this.beatDownLevelX = beatDownLevelX;
        this.beatDownLevelY = beatDownLevelY;
        this.ch1 = ch;

    }


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
                bool isCh;
                if (ch != null)
                {
                    isCh = true;
                    if (ch.IsAlive < 0 || ch.Invincible == 1)
                        return;
                    //强制朝向受击方向
                    if (isWeapon&&ch!=null&&ch1!=null)
                        ch.Direction = -ch1.Direction;

                    //减血
                    ch.Health -= damage;
                    Debug.Log("Health:" + ch.Health);
                }
                else
                    isCh = false;
          
        

                //击倒
                if (beatDownLevelX > 0||beatDownLevelY>0)
                {
                    if (isCh&&ch.IsSuperArmor == 1)
                        break;
                    if(isCh)
                         ch.Fall();
                    BeatDown b = other.gameObject.AddComponent<BeatDown>();
                    b.levelX = beatDownLevelX;
                    b.levelY = beatDownLevelY;
                    b.direction = other.transform.position.x >= this.transform.position.x ? 1 : -1;
                    //ch2.ActionStateMachine.Push(7);
                }
                //击退
                else if (beatBackLevel > 0)
                {

                    BeatBack b = other.gameObject.AddComponent<BeatBack>();
                    b.level = beatBackLevel;
                    b.direction = other.transform.position.x >= this.transform.position.x ? 1 : -1;
                }
    
                //产生受击特效
                if(hitPrefab!=null)
                {
                    if(isWeapon==false)
                        Instantiate(hitPrefab, this.transform.position, Quaternion.identity);
                    else
                        Instantiate(hitPrefab, this.transform.Find("WeaponPoint").position, Quaternion.identity);
                }
                CameraShake.Instance.shakeLevelX = 1;
                CameraShake.Instance.shakeLevelY = 0;
                CameraShake.Instance.time = 0.15f;
                CameraShake.Instance.Shake();
        

                //发送消息
                if(ch1!=null&&isCh)
                    ch1.Notify("AttackHit;" + other.tag + ";" + CharacterManager.Instance.CharacterList.IndexOf(other.GetComponent<Character>()) + ";" + ch1.tag + ";" + CharacterManager.Instance.CharacterList.IndexOf(ch1));

                //销毁
                if (isDestory != 0)
                {

                    Destroy(gameObject);
                }
            }
        }

        return;




 
    }



}

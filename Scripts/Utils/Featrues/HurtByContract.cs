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
    public Character master;
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
    public float damage = 1;
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
            master = this.GetComponentInParent<Character>();
        if(autoTag&&master!=null)
        {
            destTags = AutoTag.Instance.GetTargetTags(master.tag);
            
        }
    }


    public void Init(float damage,int beatBackLevel,int beatDownLevelX,int beatDownLevelY,Character ch)
    {
        this.damage = damage;
        this.beatBackLevel=beatBackLevel;
        this.beatDownLevelX = beatDownLevelX;
        this.beatDownLevelY = beatDownLevelY;
        this.master = ch;

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
                Character targetCharacter = other.GetComponent<Character>();
                bool isCh;
                if (targetCharacter != null)
                {
                    isCh = true;
                    if (targetCharacter.IsAlive < 0 || targetCharacter.IsInvincible == 1)
                        return;
                    //强制朝向受击方向
                    if (isWeapon&&targetCharacter!=null&&master!=null)
                        targetCharacter.Direction = -master.Direction;

                    //减血
                    targetCharacter.Hp -= damage;
                   // Debug.Log("Health:" + ch.Health);
                }
                else
                    isCh = false;

        

                //击倒
                if (beatDownLevelX > 0||beatDownLevelY>0)
                {
                    if (isCh&&targetCharacter.IsSuperArmor == 1)
                        break;
                    if(isCh)
                         targetCharacter.Fall();
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
                CameraShake.Instance.Shake(0.15f,1,0);
        

                //发送消息
                if(master!=null&&isCh)
                    master.Notify("AttackHit;" + other.tag + ";" + CharacterManager.Instance.CharacterList.IndexOf(other.GetComponent<Character>()) + ";" + master.tag + ";" + CharacterManager.Instance.CharacterList.IndexOf(master));

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

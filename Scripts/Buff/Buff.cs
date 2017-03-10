using UnityEngine;
using System.Collections;
/// <summary>
/// 包括改变属性（回合/永久），特殊攻击特效等
/// </summary>
public class Buff : ExSubject
{
    public GameObject effectPrefeb;

    protected string buffTag;
    private int buffID;
    public int BuffID
    {
        get { return buffID; }
        set { buffID = value; }
    }
   

    /// <summary>
    /// 效果类型，1为增益，0为减益
    /// </summary>
    protected int effectType;
    public int EffectType
    {
        get { return effectType; }
        set { effectType = value; }
    }
       
    /// <summary>
    /// 持续时间，暂定只能以房间为准
    /// </summary>
    protected int buffDuration;
    public int BuffDuration
    {
      get { return buffDuration; }
      set { buffDuration = value; }
    }
    /// <summary>
    /// 效果持续时间，1位永久，0位临时
    /// </summary>
    protected int effectDuration;
    public int EffectDuration
    {
        get { return effectDuration; }
        set { effectDuration = value; }
    }



    protected Sprite buffSprite;
    protected SpriteRenderer spriteRenderer;

    public void DestroyBuff()
    {
        this.gameObject.GetComponent<BuffManager>().BuffList.Remove(this);
        Destroy(this);  
    }



	// Use this for initialization
	void Start () {
	
	}
	
}

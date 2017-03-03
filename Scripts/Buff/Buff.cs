using UnityEngine;
using System.Collections;
/// <summary>
/// 包括改变属性（回合/永久），特殊攻击特效等
/// </summary>
public class Buff : MonoBehaviour {

    protected int buffID;
    public int BuffID
    {
        get { return buffID; }
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
    /// 持续时间，暂定只能以房间为准，0为触发效果后消失，1为永久，2位一个房间
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

    public void Create(int ID)
    {           
    }





	// Use this for initialization
	void Start () {
	
	}
	
}

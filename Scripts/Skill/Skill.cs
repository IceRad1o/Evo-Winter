using UnityEngine;
using System.Collections;

public class Skill : ExSubject
{
    protected GameObject prefabInstance;

    /// <summary>
    /// 技能的ID
    /// </summary>
    protected int skillID;
    public int SkillID
    {
        get { return skillID; }
        set { skillID = value; }
    }
    /// <summary>
    /// 引导时间
    /// </summary>
    protected float leadingTime;
    public float LeadingTime
    {
        get { return leadingTime; }
        set { leadingTime = value; }
    }
    /// <summary>
    /// 冷却时间
    /// </summary>
    protected float cd;
    public float Cd
    {
        get { return cd; }
        set { cd = value; }
    }
    /// <summary>
    /// skill触发的概率
    /// </summary>
    protected int probability;
    public int Probability
    {
        get { return probability; }
        set { probability = value; }
    }
    /// <summary>
    /// 技能状态，表示是否进入冷却,0表示在CD,1表示未进CD
    /// </summary>
    private int state;
    public int State
    {
        get { return state; }
        set { state = value; }
    }
    /// <summary>
    /// 表示技能是否是一次性的，0否，1是
    /// </summary>
    private int disposable=0;
    public int Disposable
    {
        get { return disposable; }
        set { disposable = value; }
    }
    /// <summary>
    /// 判断是否触发（概率触发，彩蛋触发）
    /// </summary>
    /// <returns></returns>
    protected bool JudgeTrigger()
    {
        //创建random的实例
        System.Random random = new System.Random();
        if (random.Next(100) >= probability)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 技能的触发
    /// </summary>
    virtual public void Trigger() 
    {
        //概率，判断是否满足，如果非概率触发，因为probability=0，一定触发
        if (!JudgeTrigger())
            return;
        //判断是否进入cd
        if (state==0)
            return;
        //进入cd，若是无cd，则cd=0，state立即=1，等于未进
        state = 0;
        StartCoroutine(InCd());
    }

    virtual public void Create(int ID) { SkillID = ID; this.gameObject.GetComponent<SkillManager>().SkillList.Add(this); }
    /// <summary>
    /// 延迟，用于技能的冷却等
    /// </summary>
    /// <param name="time">延迟的时间</param>
    /// <returns></returns>
    virtual protected IEnumerator DelayTrigger(float time)
    {
        yield return new WaitForSeconds(time);
        Trigger();
    }
    /// <summary>
    /// 进入CD
    /// </summary>
    /// <returns></returns>
    virtual public IEnumerator InCd()
    {
        yield return new WaitForSeconds(Cd);
        state = 1;
    }
    /// <summary>
    /// 技能脚本的销毁
    /// </summary>
    virtual public void skillDestory(){
        this.gameObject.GetComponent<SkillManager>().SkillList.Remove(this);
        Destroy(this); 
    
    }
}

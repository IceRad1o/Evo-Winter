using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour
{

    /// <summary>
    /// 是否为UI元素,默认false
    /// </summary>
    public bool isOnCanvas = false;

    /// <summary>
    /// 持续时间,运动开始后不可变更,默认1
    /// </summary>
    public float duration = 1.0f;

    public Vector4 destValue;

    /*Reset*/

    /// <summary>
    /// 是否重置初始值,默认false
    /// </summary>
    [Header("Reset")]
    public bool isReset = false;


    /// <summary>
    /// 是否将初始值设为0,默认false
    /// </summary>
    [ConditionalHide("isReset", true)]
    public bool resetToZero = false;
    /// <summary>
    /// 是否将初始值设为1,默认false
    /// </summary>
    [ConditionalHide("isReset", true)]
    public bool resetToFull = false;

    /// <summary>
    /// 是否将初始值设为1,默认false
    /// </summary>
    [ConditionalHide("isReset", true)]
    public bool resetToValue = false;
    /// <summary>
    /// 重置值
    /// </summary>
    [ConditionalHide("resetToValue", true)]
    public Vector4 resetValue;


    /*Reverse*/

    /// <summary>
    /// 是否反转,默认false
    /// </summary>
    [Header("Reverse")]
    public bool isReverse = false;

    /// <summary>
    /// 是否延迟反转,默认false
    /// </summary>
    [ConditionalHide("isReverse", true)]
    public bool isReverseDelay = false;

    /// <summary>
    /// 反转延迟时间
    /// </summary>
    [ConditionalHide("isReverseDelay", true)]
    public float reverseDelayTime;




    /// <summary>
    /// 是否循环,默认false
    /// </summary>
    [Header("Loop")]
    public bool isLoop = false;

    /// <summary>
    /// 是否循环指定次数,默认false
    /// </summary>
    [ConditionalHide("isLoop", true)]
    public bool loopForever = false;
    [ConditionalHide("isLoop", true)]
    public bool loopLimitedTimes = false;
    /// <summary>
    /// 循环次数
    /// </summary>
    [ConditionalHide("loopLimitedTimes", true)]
    public int loopTimes;

    /// <summary>
    /// 是否延迟循环,默认false
    /// </summary>
    [ConditionalHide("isLoop", true)]
    public bool isLoopDelay = false;

    /// <summary>
    /// 循环延迟时间
    /// </summary>
    [ConditionalHide("isLoopDelay", true)]
    public float loopDelayTime;


    /// <summary>
    /// 是否延迟
    /// </summary>
    [Header("Delay")]
    public bool isDelay = false;

    /// <summary>
    /// 延迟时间
    /// </summary>
    [ConditionalHide("isDelay", true)]
    public float delayTime = 0f;

    /// <summary>
    /// 结束后是否销毁脚本
    /// </summary>
    [Header("Other Setting")]
    public bool isDestroyScript = true;
    public bool isDestroyGameObject = false;


    /// <summary>
    /// 是否一开始就运行
    /// </summary>
    public bool runOnStart = true;


    /// <summary>
    /// 持续帧数
    /// </summary>
    protected int count;

    /// <summary>
    /// 速度
    /// </summary>
    protected Vector4 speed;

    /// <summary>
    /// 重置初始值
    /// </summary>
    /// <param name="value">初始值</param>
    public virtual void ResetValue(Vector4 value)
    {

    }

    /// <summary>
    /// 改变值
    /// </summary>
    /// <param name="direction"></param>
    public virtual void ChangeValue(bool direction)
    {

    }

    /// <summary>
    /// 获取所需组件
    /// </summary>
    /// <returns>是否获取成功</returns>
    public virtual bool GetNormalComponents() { return true; }
    /// <summary>
    /// 获取所需组件-ui版本
    /// </summary>
    /// <returns>是否获取成功</returns>
    public virtual bool GetUIComponents() { return true; }

    /// <summary>
    /// 预处理
    /// </summary>
    public virtual void PreHandle()
    {
        if (!isOnCanvas)
        {
            if (!GetNormalComponents())
                return;

        }

        else
        {
            if (!GetUIComponents())
                return;
        }
        if (resetToZero)
            ResetValue(Vector4.zero);

        else if (resetToFull)
            ResetValue(Vector4.one);
        else if (resetToValue)
            ResetValue(resetValue);




    }

    /// <summary>
    /// 后处理
    /// </summary>
    public virtual void SubHandle() { }

    /// <summary>
    /// c重新计算值
    /// </summary>
    protected virtual void ReCalCount()
    {
        count = (int)(duration * 60);
        if (count == 0)
            count = 1;
      
    }
       protected virtual void ReCalSpeed()
       {
           speed = destValue / count;
       }
      
    IEnumerator IEumAction()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        do
        {

            ReCalCount();
            ReCalSpeed();
            while (count-- != 0)
            {
                ChangeValue(true);
                yield return null;
            }

            if (isReverseDelay)
                yield return new WaitForSeconds(reverseDelayTime);

            if (isReverse)
            {
                ReCalCount();

                while (count-- != 0)
                {
                    ChangeValue(false);
                    yield return null;
                }
            }

            if (isLoopDelay)
                yield return new WaitForSeconds(loopDelayTime);

        } while (isLoop && (--loopTimes > 0 || !loopLimitedTimes));

        SubHandle();

        if (isDestroyScript)
            Destroy(this);
        if (isDestroyGameObject)
            Destroy(gameObject);
    }




    public virtual void PerformAction()
    {

        StartCoroutine(IEumAction());

    }

    public void Run()
    {
        PreHandle();
        PerformAction();
    }

    void Start()
    {
        if (runOnStart)
            Run();
    }


}

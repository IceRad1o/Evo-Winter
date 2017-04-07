using UnityEngine;
using System.Collections;
/// <summary>
/// RotateBy
/// 控制物体旋转指定角度,本地坐标系
/// 运动完毕后自动销毁
/// YYF 17.3.30
/// </summary>
public class RotateBy : Action
{
   

    /// <summary>
    /// 旋转差值
    /// </summary>
    public Vector3 deltaRotation= new Vector3();


    /// <summary>
    /// 初始化位移Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">差值</param>
    /// <param name="isReverse">是否反转,即至目标值后是否回原来值</param>
    /// <param name="isLoop"> 是否循环</param>
    /// <param name="isOnCanvas">对象是否为UI元素</param>
    void Init(float duration, Vector3 deltaRotation, bool isReverse = true, bool isLoop = false, bool isOnCanvas = false)
    {
        this.duration = duration;
        this.deltaRotation = deltaRotation;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }


    void Start()
    {

        if (!isOnCanvas)
        {
            if (isReset)
                this.transform.localEulerAngles = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if (resetToZero)
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
            StartCoroutine(IEnumRotateBy());
        }

        else
        {
            if (isReset)
                this.GetComponent<RectTransform>().localEulerAngles = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if (resetToZero)
                this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, 0);
            StartCoroutine(IEnumUIRotateBy());
        }
 
    }

    IEnumerator IEnumRotateBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;

        do
        {
            count = (int)duration * 60 + 1;
            speed = deltaRotation / count;
            while (count-- != 0)
            {
                this.transform.localEulerAngles += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = deltaRotation / count;
                while (count-- != 0)
                {
                    this.transform.localEulerAngles -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));

        Destroy(this);



    }

    /// <summary>
    /// UI元素版本
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumUIRotateBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;

         do
        {
            count = (int)duration * 60 + 1;
            speed = deltaRotation / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localEulerAngles  += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = deltaRotation / count;
                while (count-- != 0)
                {
                    this.GetComponent<RectTransform>().localEulerAngles  -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever)) ;
        Destroy(this);
    }
}

using UnityEngine;
using System.Collections;
/// <summary>
/// MoveBy
/// 控制物体位移指定距离,本地坐标系
/// 运动完毕后自动销毁
/// YYF 17.3.30
/// </summary>
public class MoveBy : Action
{


    /// <summary>
    /// 距离
    /// </summary>
    public Vector3 deltaPosition;




    /// <summary>
    /// 初始化位移Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">差值</param>
    /// <param name="isReverse">是否反转,即至目标值后是否回原来值</param>
    /// <param name="isLoop"> 是否循环</param>
    /// <param name="isOnCanvas">对象是否为UI元素</param>
    public void Init(float duration, Vector3 deltaPosition, bool isReverse = true, bool isLoop = false, bool isOnCanvas = false)
    {
        this.duration = duration;
        this.deltaPosition = deltaPosition;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }


    void Start()
    {


        if (!isOnCanvas)
            StartCoroutine(IEnumMoveBy());
        else
            StartCoroutine(IEnumUIMoveBy());
    }

    IEnumerator IEnumMoveBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;


        do
        {
            count = (int)(duration * 60) ;
            if (count == 0)
                count = 1;
            speed = deltaPosition / count;
            while (count-- != 0)
            {
                this.transform.localPosition += speed;
                yield return null;
            }
            if (isReverse)
            {
                if (isReverseDelay)
                    yield return new WaitForSeconds(reverseDelayTime);

                count = (int)(duration * 60) ;
                if (count == 0)
                    count = 1;
                speed = deltaPosition / count;
                while (count-- != 0)
                {
                    this.transform.localPosition -= speed;
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
    IEnumerator IEnumUIMoveBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;


        do
        {
            count = (int)(duration * 60) ;
            if (count == 0)
                count = 1;
            speed = deltaPosition / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localPosition += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)(duration * 60) ;
                if (count == 0)
                    count = 1;
                speed = deltaPosition / count;
                while (count-- != 0)
                {
                    this.GetComponent<RectTransform>().localPosition -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }
}

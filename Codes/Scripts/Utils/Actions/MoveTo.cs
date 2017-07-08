using UnityEngine;
using System.Collections;
/// <summary>
/// MoveTo
/// 控制物体移动到目标位置,本地坐标系
/// 运动完毕后自动销毁
/// YYF 17.3.30
/// </summary>
public class MoveTo : Action
{


    /// <summary>
    /// 目标位置
    /// </summary>
    public Vector3 destPosition = new Vector3();



    /// <summary>
    /// 初始化位移Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">目标位置</param>
    /// <param name="isReverse">是否反转,即位移至目标值后是否位移回原来位置</param>
    /// <param name="isLoop"> 是否循环位移</param>
    /// <param name="isOnCanvas">对象是否为UI元素</param>
    void Init(float duration, Vector3 destPosition, bool isReverse = true, bool isLoop = false, bool isOnCanvas = false)
    {
        this.duration = duration;
        this.destPosition = destPosition;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }
    void Start()
    {

        if (isReverse == false && isLoop == true)
            isLoop = false;
        if (!isOnCanvas)
            StartCoroutine(IEnumMoveTo());
        else
            StartCoroutine(IEnumUIMoveTo());
    }

    IEnumerator IEnumMoveTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;

        do
        {
            count = (int)(duration * 60) ;
            if (count == 0)
                count = 1;
            speed = (destPosition - this.transform.localPosition) / count;
            while (count-- != 0)
            {
                this.transform.localPosition += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)(duration * 60) ;
                if (count == 0)
                    count = 1;
                while (count-- != 0)
                {
                    this.transform.localPosition -= speed;
                    yield return null;
                }
            }
        }  while (isLoop && (--loopTimes > 0 || loopForever));
     

        Destroy(this);



    }

    /// <summary>
    /// UI元素版本
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumUIMoveTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);
        Vector3 speed;

        do
        {
            count = (int)(duration * 60) ;
            if (count == 0)
                count = 1;
            speed = (destPosition - this.GetComponent<RectTransform>().localPosition) / count;
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

                while (count-- != 0)
                {
                    this.GetComponent<RectTransform>().localPosition -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever)) ;

        Destroy(this);



    }




}

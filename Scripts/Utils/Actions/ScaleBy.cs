using UnityEngine;
using System.Collections;
/// <summary>
/// ScaleBy
/// 控制物体缩放多少比例
/// 运动完毕后自动销毁
/// YYF 17.3.29
/// </summary>
public class ScaleBy : Action
{


    /// <summary>
    /// 缩放差值
    /// </summary>
    public Vector3 deltaScale = new Vector3();




    /// <summary>
    /// 初始化缩放Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">缩放差值</param>
    /// <param name="isReverse">是否反转,即缩放至目标值后是否缩放回原来值</param>
    /// <param name="isLoop"> 是否循环缩放</param>
    /// <param name="isOnCanvas">缩放对象是否为UI元素</param>
    public void Init(float duration, Vector3 deltaScale, bool isReverse = true, bool isLoop = false, bool isOnCanvas = false)
    {
        this.duration = duration;
        this.deltaScale = deltaScale;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }


    void Start()
    {


        if (!isOnCanvas)
        {
            if (isReset)
                this.transform.localScale = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if (resetToZero)
                this.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(IEnumScaleBy());
        }

        else
        {
            if (isReset)
                this.GetComponent<RectTransform>().localScale = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if (resetToZero)
                this.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            StartCoroutine(IEnumUIScaleBy());
        }

    }

    IEnumerator IEnumScaleBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;

        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.transform.localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60;
                if (count == 0)
                    count = 1;
                speed = deltaScale / count;
                while (count-- != 0)
                {
                    this.transform.localScale -= speed;
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
    IEnumerator IEnumUIScaleBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;

        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60;
                if (count == 0)
                    count = 1;
                speed = deltaScale / count;
                while (count-- != 0)
                {
                    this.GetComponent<RectTransform>().localScale -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));

        Destroy(this);



    }




}

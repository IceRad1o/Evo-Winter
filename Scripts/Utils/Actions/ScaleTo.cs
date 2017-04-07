using UnityEngine;
using System.Collections;
/// <summary>
/// ScaleTo
/// 控制物体缩放到多少
/// 运动完毕后自动销毁
/// YYF 17.3.29
/// </summary>
public class ScaleTo : Action
{


    /// <summary>
    /// 缩放目标值
    /// </summary>
    public Vector3 destScale = new Vector3();




    /// <summary>
    /// 初始化缩放Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">缩放目标值</param>
    /// <param name="isReverse">是否反转,即缩放至目标值后是否缩放回原来值</param>
    /// <param name="isLoop"> 是否循环缩放</param>
    /// <param name="isOnCanvas">缩放对象是否为UI元素</param>
    void Init(float duration,Vector3 destScale,bool isReverse=true,bool isLoop=false,bool isOnCanvas=false)
    {
        this.duration = duration;
        this.destScale = destScale;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }
    void Start()
    {

        if (isReverse == false && isLoop == true)
            isLoop = false;

        if (!isOnCanvas)
        {
            if (isReset)
                this.transform.localScale = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if(resetToZero)
                this.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(IEnumScaleTo());
            
        }
        else
        {
            if (isReset)
                this.GetComponent<RectTransform>().localScale = new Vector3(resetValue.x, resetValue.y, resetValue.z);
            if (resetToZero)
                this.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            StartCoroutine(IEnumUIScaleTo());
        }
            
    }

    IEnumerator IEnumScaleTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;
       

        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            speed = (destScale - this.transform.localScale) / count;
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

                while (count-- != 0)
                {
                    this.transform.localScale -= speed;
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever)) ;

        Destroy(this);



    }

    /// <summary>
    /// UI元素版本
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumUIScaleTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        Vector3 speed;



        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            speed = (destScale - this.GetComponent<RectTransform>().localScale) / count;
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

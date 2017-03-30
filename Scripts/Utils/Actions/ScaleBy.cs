using UnityEngine;
using System.Collections;
/// <summary>
/// ScaleBy
/// 控制物体缩放多少比例
/// 运动完毕后自动销毁
/// YYF 17.3.29
/// </summary>
public class ScaleBy : MonoBehaviour
{
    /// <summary>
    /// 持续时间,运动开始后不可变更
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// 缩放差值
    /// </summary>
    public Vector3 deltaScale = new Vector3();

    /// <summary>
    /// 是否反转
    /// </summary>
    public bool isReverse = true;

    /// <summary>
    /// 是否循环
    /// </summary>
    public bool isLoop = false;

    /// <summary>
    /// 是否为UI元素
    /// </summary>
    public bool isOnCanvas = false;


    /// <summary>
    /// 初始化缩放Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">缩放差值</param>
    /// <param name="isReverse">是否反转,即缩放至目标值后是否缩放回原来值</param>
    /// <param name="isLoop"> 是否循环缩放</param>
    /// <param name="isOnCanvas">缩放对象是否为UI元素</param>
    void Init(float duration, Vector3 deltaScale, bool isReverse = true, bool isLoop = false, bool isOnCanvas = false)
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
            StartCoroutine(IEnumScaleBy());
        else
            StartCoroutine(IEnumUIScaleBy());
    }

    IEnumerator IEnumScaleBy()
    {
        Vector3 speed;
        int count = (int)duration * 60 + 1;
        speed = deltaScale / count;
        while (count-- != 0)
        {
            this.transform.localScale += speed;
            yield return null;
        }
        if (isReverse)
        {
            count = (int)duration * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.transform.localScale -= speed;
                yield return null;
            }
        }

        while (isLoop )
        {
            count = (int)duration * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.transform.localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = deltaScale / count;
                while (count-- != 0)
                {
                    this.transform.localScale -= speed;
                    yield return null;
                }
            }
        }

        Destroy(this);



    }

    /// <summary>
    /// UI元素版本
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumUIScaleBy()
    {
        Vector3 speed;
        int count = (int)duration * 60 + 1;
        speed = deltaScale / count;
        while (count-- != 0)
        {
            this.GetComponent<RectTransform>().localScale += speed;
            yield return null;
        }
        if (isReverse)
        {
            count = (int)duration * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localScale -= speed;
                yield return null;
            }
        }

        while (isLoop && isReverse)
        {
            count = (int)duration * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = deltaScale / count;
                while (count-- != 0)
                {
                    this.GetComponent<RectTransform>().localScale -= speed;
                    yield return null;
                }
            }
        }

        Destroy(this);



    }




}

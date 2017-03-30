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
    public float time = 1.0f;

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
        int count = (int)time * 60 + 1;
        speed = deltaScale / count;
        while (count-- != 0)
        {
            this.transform.localScale += speed;
            yield return null;
        }
        if (isReverse)
        {
            count = (int)time * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.transform.localScale -= speed;
                yield return null;
            }
        }

        while (isLoop )
        {
            count = (int)time * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.transform.localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)time * 60 + 1;
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
        int count = (int)time * 60 + 1;
        speed = deltaScale / count;
        while (count-- != 0)
        {
            this.GetComponent<RectTransform>().localScale += speed;
            yield return null;
        }
        if (isReverse)
        {
            count = (int)time * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localScale -= speed;
                yield return null;
            }
        }

        while (isLoop && isReverse)
        {
            count = (int)time * 60 + 1;
            speed = deltaScale / count;
            while (count-- != 0)
            {
                this.GetComponent<RectTransform>().localScale += speed;
                yield return null;
            }
            if (isReverse)
            {
                count = (int)time * 60 + 1;
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

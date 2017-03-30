using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// TintBy 染色
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class TintBy: MonoBehaviour
{

    /// <summary>
    /// 持续时间,运动开始后不可变更
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// 是否将颜色设为0;
    /// </summary>
    public bool resetToZero = false;

    /// <summary>
    /// 差值
    /// </summary>
    public Vector4 deltaColor;

    /// <summary>
    /// 是否反转
    /// </summary>
    public bool isReverse = false;

    /// <summary>
    /// 是否循环
    /// </summary>
    public bool isLoop = false;


    /// <summary>
    /// 是否为UI元素
    /// </summary>
    public bool isOnCanvas = false;


    int count;
    
    SpriteRenderer[] renders;
    Image[] images;
    void Start()
    {
        if (isReverse == false && isLoop == true)
            isLoop = false;

        if (!isOnCanvas)
        {
            renders = this.GetComponentsInChildren<SpriteRenderer>();
            if (renders == null)
                return;

            if (resetToZero)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(0, 0, 0, 1);
                }


            StartCoroutine(IEumTintBy());
        }

        else
        {
            images = this.GetComponentsInChildren<Image>();
            if (resetToZero)
                foreach (Image r in images)
                {
                    r.color = new Color(0, 0, 0, 1);
                }
            StartCoroutine(IEumUITintBy());
        }

    }

    IEnumerator IEumTintBy()
    {
       Vector4 speed;


        do
        {
            count = (int)duration * 60 ;
            if (count == 0)
                count = 1;
            speed = deltaColor/ count;
            while (count-- != 0)
            {
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(f(r.color.r + speed.x, speed.x), f(r.color.g + speed.y, speed.y), f(r.color.b + speed.z, speed.z), f(r.color.a + speed.w, speed.w));
                    //Debug.Log("color:"+r.color);
                }
                yield return null;
            }
          
            if (isReverse)
            {
                count = (int)duration * 60 ;
                if (count == 0)
                    count = 1;
                speed = deltaColor / count;

                while (count-- != 0)
                {
                    foreach (SpriteRenderer r in renders)
                    {
                        r.color = new Color(f(r.color.r - speed.x,speed.x), f(r.color.g - speed.y,speed.y), f(r.color.b - speed.z,speed.z), f(r.color.a - speed.w,speed.w));
                        //Debug.Log("color:" + r.color);
                    }
                    yield return null;
                }
            }
        } while (isLoop && isReverse);
        Destroy(this);
    }


    IEnumerator IEumUITintBy()
    {
        Vector4 speed;


        do
        {
            count = (int)duration * 60 ;
            if (count == 0)
                count = 1;
            speed = deltaColor / count;
            while (count-- != 0)
            {
                foreach (Image r in images)
                {
                    r.color = new Color(f(r.color.r + speed.x, speed.x), f(r.color.g + speed.y, speed.y), f(r.color.b + speed.z, speed.z), f(r.color.a + speed.w, speed.w));

                }
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 ;
                if (count == 0)
                    count = 1;
                speed = deltaColor / count;

                while (count-- != 0)
                {
                    foreach (Image r in images)
                    {
                        r.color = new Color(f(r.color.r - speed.x, speed.x), f(r.color.g - speed.y, speed.y), f(r.color.b - speed.z, speed.z), f(r.color.a - speed.w, speed.w));

                    }
                    yield return null;
                }
            }
        } while (isLoop && isReverse);
        Destroy(this);
    }


    float f(float src,float speed)
    {
        if (speed < 0)
            speed = -speed;

        if (src > 1.0f+speed)
            src -= 1;
        else if (src < -speed)
            src += 1;

        return src;
    }
}

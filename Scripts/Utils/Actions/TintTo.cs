using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// TintTo 染色至
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class TintTo : MonoBehaviour
{

    /// <summary>
    /// 持续时间,运动开始后不可变更
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// 是否将颜色设为0;
    /// </summary>
    public bool resetToZero = false;

    public bool useResetColor=false;
    public Vector4 resetColor =new Vector4(0, 0, 0, 0);

    /// <summary>
    /// 差值
    /// </summary>
    public Vector4 destColor;

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

            if (useResetColor)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(resetColor.x, resetColor.y, resetColor.z, resetColor.w);
                }
            StartCoroutine(IEumTintTo());
        }

        else
        {
            images = this.GetComponentsInChildren<Image>();
            if (resetToZero)
                foreach (Image r in images)
                {
                    r.color = new Color(0, 0, 0, 1);
                }
            if (useResetColor)
                foreach (Image r in images)
                {
                    r.color = new Color(resetColor.x, resetColor.y, resetColor.z, resetColor.w);
                }
            StartCoroutine(IEumUITintTo());
        }

    }

    IEnumerator IEumTintTo()
    {

        count = (int)duration * 60;
        if (count == 0)
            count = 1;
         List<Vector4> speed=new List<Vector4>();
         foreach (SpriteRenderer r in renders)
         {
             speed.Add((destColor - (Vector4)r.color) / count);
         }
        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            while (count-- != 0)
            {
                int i = 0;
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r + speed[i].x, r.color.g + speed[i].y, r.color.b + speed[i].z, r.color.a + speed[i].w);
               
                    i++;
                    //Debug.Log("sp:" + speed[i] + " color:" + r.color);
                }
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60;
                if (count == 0)
                    count = 1;
                while (count-- != 0)
                {
                    int i = 0;
                    foreach (SpriteRenderer r in renders)
                    {

                        r.color = new Color(r.color.r - speed[i].x, r.color.g - speed[i].y, r.color.b - speed[i].z, r.color.a - speed[i].w);
                        i++;
                        //Debug.Log("sp:" + speed[i] + " color:" + r.color);
                    }
                    yield return null;
                }
            }
        } while (isLoop && isReverse);
        Destroy(this);
    }


    IEnumerator IEumUITintTo()
    {
        count = (int)duration * 60;
        if (count == 0)
            count = 1;
        List<Vector4> speed = new List<Vector4>();
        foreach (SpriteRenderer r in renders)
        {
            speed.Add((destColor - (Vector4)r.color) / count);
        }
        do
        {
            count = (int)duration * 60;
            if (count == 0)
                count = 1;
            while (count-- != 0)
            {
                int i = 0;
                foreach (Image r in images)
                {

                    r.color = new Color( r.color.r + speed[i].x,  r.color.g + speed[i].y,  r.color.b + speed[i].z,  r.color.a + speed[i].w);
                    i++;
                    //Debug.Log("sp:" + speed[i] + " color:" + r.color);
                }
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60;
                if (count == 0)
                    count = 1;
                while (count-- != 0)
                {
                    int i = 0;
                    foreach (Image r in images)
                    {
                        r.color = new Color(r.color.r - speed[i].x, r.color.g - speed[i].y, r.color.b - speed[i].z, r.color.a - speed[i].w);
                        i++;
                        //Debug.Log("sp:" + speed[i] + " color:" + r.color);
                    }
                    yield return null;
                }
            }
        } while (isLoop && isReverse);
        Destroy(this);
    }


}

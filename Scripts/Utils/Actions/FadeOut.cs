using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// FadeOut 淡出
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class FadeOut : MonoBehaviour
{

    /// <summary>
    /// 持续时间,运动开始后不可变更
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// 是否将透明度设为1;
    /// </summary>
    public bool resetToFull = true;

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

            if (resetToFull)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
                }


            StartCoroutine(IEumFadeOut());
        }

        else
        {
            images = this.GetComponentsInChildren<Image>();
            if (resetToFull)
                foreach (Image r in images)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
                }
            StartCoroutine(IEumUIFadeOut());
        }

    }

    IEnumerator IEumFadeOut()
    {
        float speed;


        do
        {
            count = (int)duration * 60 + 1;
            speed = 1.0f / count;
            while (count-- != 0)
            {
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a - speed);

                }
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = 1.0f / count;

                while (count-- != 0)
                {
                    foreach (SpriteRenderer r in renders)
                    {
                        r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);

                    }
                    yield return null;
                }
            }
        } while (isLoop&&isReverse);
        Destroy(this);
    }


    IEnumerator IEumUIFadeOut()
    {
        float speed;


        do
        {
            count = (int)duration * 60 + 1;
            speed = 1.0f / count;
            while (count-- != 0)
            {
                foreach (Image r in images)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a - speed);

                }
                yield return null;
            }
            if (isReverse)
            {
                count = (int)duration * 60 + 1;
                speed = 1.0f / count;

                while (count-- != 0)
                {
                    foreach (Image r in images)
                    {
                        r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);

                    }
                    yield return null;
                }
            }
        } while (isLoop&&isReverse);
        Destroy(this);
    }



}

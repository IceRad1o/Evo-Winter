using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// BlinkBy 闪烁
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class BlinkBy : Action
{


    /// <summary>
    /// 闪烁次数
    /// </summary>
    public float times;

    /// <summary>
    /// 0为闪烁状态,1为真实状态
    /// </summary>
    bool flag = false;


    SpriteRenderer[] renders;
    Image[] images;
    void Start()
    {

        if (!isOnCanvas)
        {
            renders = this.GetComponentsInChildren<SpriteRenderer>();
            if (renders == null)
                return;
            StartCoroutine(IEumBlinkBy());
        }

        else
        {
            images = this.GetComponentsInChildren<Image>();
            if (images == null)
                return;
            StartCoroutine(IEumUIBlinkBy());
        }

    }

    IEnumerator IEumBlinkBy()
    {
        if(isDelay)
             yield return new WaitForSeconds(delayTime);

        int speed;
        count = (int)duration * 60;
        if (count == 0)
            count = 1;
        speed = (int)(count / times);
        if (speed == 0)
            speed = 1;
        do
        {
            while (count-- != 0)
            {
                if (count % speed == 0)
                {
                    if (flag)
                    {
                        foreach (SpriteRenderer r in renders)
                        {
                            r.color = new Color(r.color.r, r.color.g, r.color.b, 0);
                        }
                    }
                    else
                        foreach (SpriteRenderer r in renders)
                        {
                            r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
                        }

                    flag = !flag;
                }

                yield return null;
            }
        } while (isLoop&&(--loopTimes>0||loopForever));

        yield return null;
        foreach (SpriteRenderer r in renders)
        {
            r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
        }

        Destroy(this);
    }


    IEnumerator IEumUIBlinkBy()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        int speed;
        count = (int)duration * 60;
        if (count == 0)
            count = 1;
        speed = (int)(count / times);
        if (speed == 0)
            speed = 1;
        do
        {
            while (count-- != 0)
            {
                if (count % speed == 0)
                {
                    if (flag)
                    {
                        foreach (Image r in images)
                        {
                            r.color = new Color(r.color.r, r.color.g, r.color.b, 0);
                        }
                    }
                    else
                        foreach (Image r in images)
                        {
                            r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
                        }

                    flag = !flag;
                }

                yield return null;
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));

        yield return null;
        foreach (Image r in images)
        {
            r.color = new Color(r.color.r, r.color.g, r.color.b, 1);
        }
        Destroy(this);
    }



}


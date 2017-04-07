using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// FadeOut 淡出
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class FadeOut : Action
{



    /// <summary>
    /// 是否将透明度设为1;
    /// </summary>
    public bool resetToFull =false;



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
            if(resetToZero)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, 0);
                }
            if (isReset)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, resetValue.x);
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
            if (resetToZero)
                foreach (Image r in images)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, 0);
                }
            if (isReset)
                foreach (Image r in images)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, resetValue.x);
                }
            StartCoroutine(IEumUIFadeOut());
        }

    }

    IEnumerator IEumFadeOut()
    {

        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        float speed;


        do
        {
            count = (int)((duration * 60) ) + 1;
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
                count = (int)((duration * 60) ) + 1;
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
        } while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }


    IEnumerator IEumUIFadeOut()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        float speed;


        do
        {
            count = (int)(duration * 60) ;
            if (count == 0)
                count = 1;
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
                count = (int)(duration * 60) ;
                if (count == 0)
                    count = 1;
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
        } while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }



}

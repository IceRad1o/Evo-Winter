using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// FadeIn 淡入
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class FadeIn : Action
{     



    Text  [] texts;

    Renderer[] renders;
    Image[] images;

    float[] speeds;
    //void Start()
    //{
    //    if (isReverse == false && isLoop == true)
    //        isLoop = false;

    //    if (!isOnCanvas)
    //    {
    //        renders = this.GetComponentsInChildren<SpriteRenderer>();

    //        if (renders == null)
    //            return;

    //        if (resetToZero)
    //            foreach (SpriteRenderer r in renders)
    //            {
    //                r.color = new Color(r.color.r, r.color.g, r.color.b, 0);
    //            }

    //        if(isReset)
    //            foreach (SpriteRenderer r in renders)
    //            {
    //                r.color = new Color(r.color.r, r.color.g, r.color.b, resetValue.x);
    //            }


    //        StartCoroutine(IEumFadeIn());
    //    }

    //    else
    //    {
    //        images = this.GetComponentsInChildren<Image>();
    //        texts = this.GetComponentsInChildren<Text>();
    //        if (resetToZero)
    //        {

    //            resetValue.x = 0;
    //            isReset = true;
    //        }
    //        if (isReset)
    //        {
    //            foreach (Image r in images)
    //            {
    //                r.color = new Color(r.color.r, r.color.g, r.color.b, resetValue.x);
    //            }
    //            foreach (Text r in texts)
    //            {
    //                r.color = new Color(r.color.r, r.color.g, r.color.b, resetValue.x);
    //            }
    //        }
    //        StartCoroutine(IEumUIFadeIn());
    //    }

    //}

    IEnumerator IEumFadeIn()
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
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);

                }
                yield return null;
            } 
            if (isReverseDelay)
                yield return new WaitForSeconds(reverseDelayTime);
            if (isReverse)
            {
                count = (int)(duration * 60) ;
                if (count == 0)
                    count = 1;
                speed = 1.0f / count;

                while (count-- != 0)
                {
                    foreach (SpriteRenderer r in renders)
                    {
                        r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a - speed);

                    }
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }


    IEnumerator IEumUIFadeIn()
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
                    r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);

                }
                foreach (Text r in texts)
                {
                    r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + speed);
                }
                yield return null;
            }
            if (isReverseDelay)
                yield return new WaitForSeconds(reverseDelayTime);
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
                        r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a - speed);

                    }
                    foreach (Text r in texts)
                    {
                        r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a - speed);
                    }
                    yield return null;
                }
            }
        } while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }

    public override bool GetNormalComponents()
    {
        renders = this.GetComponentsInChildren<Renderer>();

        if (renders == null)
            return false;
        else
        {
            speeds = new float[renders.Length];
            return true;
        }
            
    }

    public override bool GetUIComponents()
    {
        images = this.GetComponentsInChildren<Image>();
        texts = this.GetComponentsInChildren<Text>();

        if (images == null && texts == null)
            return false;
        else
        {
            speeds = new float[images.Length+texts.Length];
            return true;
        }
          
    }

    public override void ResetValue(Vector4 value)
    {
        if(isOnCanvas)
        {
            Debug.Log("a:"+value.x);
            foreach (Image r in images)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b,value.x);

            }
            foreach (Text r in texts)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b,value.x);
            }
        }
        else
        {
            foreach (SpriteRenderer r in renders)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b,value.x);

            }
        }

    }

    public override void ChangeValue(bool direction)
    {
        int dir = direction ? 1 : -1;
        int i = 0;
        if (isOnCanvas)
        {
            foreach (Image r in images)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + dir * speeds[i]);
                i++;
            }
            foreach (Text r in texts)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + dir * speeds[i]);
                i++;
            }
        }
        else
        {
            foreach (SpriteRenderer r in renders)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a +dir* speeds[i]);
                i++;

            }
        }
    }

    protected override void ReCalSpeed()
    {
        base.ReCalSpeed();
        int i = 0;
        if(isOnCanvas)
        {
            foreach (Image r in images)
            {
                speeds[i] = (destValue.x - r.color.a)/count;
                i++;

            }
            foreach (Text r in texts)
            {
                speeds[i] = (destValue.x - r.color.a)/count;
                i++;
            }
        }
        else
        {
            foreach (SpriteRenderer r in renders)
            {
                speeds[i] = (destValue.x - r.color.a) / count;
                i++;

            }
        }
    }

}

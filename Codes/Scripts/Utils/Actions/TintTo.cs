using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// TintTo 染色至
/// 运动完毕后自动销毁
/// YYF 3.30
/// </summary>
public class TintTo : Action
{

  

    /// <summary>
    /// 差值
    /// </summary>
    public Vector4 destColor;

   


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

            if (isReset)
                foreach (SpriteRenderer r in renders)
                {
                    r.color = new Color(resetValue.x, resetValue.y, resetValue.z, resetValue.w);
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
            if (isReset)
                foreach (Image r in images)
                {
                    r.color = new Color(resetValue.x, resetValue.y, resetValue.z, resetValue.w);
                }
            StartCoroutine(IEumUITintTo());
        }

    }

    IEnumerator IEumTintTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        count = (int)(duration * 60) ;
        if (count == 0)
            count = 1;
         List<Vector4> speed=new List<Vector4>();
         foreach (SpriteRenderer r in renders)
         {
             speed.Add((destColor - (Vector4)r.color) / count);
         }
        do
        {
            count = (int)(duration * 60) ;
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
                count = (int)(duration * 60) ;
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
        }  while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }


    IEnumerator IEumUITintTo()
    {
        if (isDelay)
            yield return new WaitForSeconds(delayTime);

        count = (int)(duration * 60) ;
        if (count == 0)
            count = 1;
        List<Vector4> speed = new List<Vector4>();
        foreach (SpriteRenderer r in renders)
        {
            speed.Add((destColor - (Vector4)r.color) / count);
        }
        do
        {
            count = (int)(duration * 60) ;
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
                count = (int)(duration * 60) ;
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
        }  while (isLoop && (--loopTimes > 0 || loopForever));
        Destroy(this);
    }


}

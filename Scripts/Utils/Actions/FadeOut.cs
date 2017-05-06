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



    Text[] texts;
    Renderer[] renders;
    Image[] images;

    float[] speeds;


    public override bool GetNormalComponents()
    {
        renders = this.GetComponentsInChildren<SpriteRenderer>();

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
            speeds = new float[images.Length + texts.Length];
            return true;
        }

    }

    public override void ResetValue(Vector4 value)
    {
        if (isOnCanvas)
        {
            //Debug.Log("a:" + value.x);
            foreach (Image r in images)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, value.x);

            }
            foreach (Text r in texts)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, value.x);
            }
        }
        else
        {
            foreach (SpriteRenderer r in renders)
            {
                r.color = new Color(r.color.r, r.color.g, r.color.b, value.x);

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
                r.color = new Color(r.color.r, r.color.g, r.color.b, r.color.a + dir * speeds[i]);
                i++;

            }
        }
    }

    protected override void ReCalSpeed()
    {
        base.ReCalSpeed();
        int i = 0;
        if (isOnCanvas)
        {
            foreach (Image r in images)
            {
                speeds[i] = (destValue.x - r.color.a) / count;
                i++;

            }
            foreach (Text r in texts)
            {
                speeds[i] = (destValue.x - r.color.a) / count;
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

using UnityEngine;
using System.Collections;
/// <summary>
/// ScaleTo
/// 控制物体缩放到多少
/// 运动完毕后自动销毁
/// YYF 17.3.29
/// </summary>
public class ScaleTo : Action
{








    public override bool GetNormalComponents()
    {

        return true;
    }

    public override bool GetUIComponents()
    {
        return true;

    }

    public override void ResetValue(Vector4 value)
    {
        transform.localScale = new Vector3(value.x, value.y, value.z);


    }

    public override void ChangeValue(bool direction)
    {
        int dir = direction ? 1 : -1;

        transform.localScale += new Vector3(dir*speed.x,dir*speed.y,dir*speed.z);
    }

    protected override void ReCalSpeed()
    {
        Vector4 t=(destValue - new Vector4(transform.localScale.x, transform.localScale.y, transform.localScale.z,0));

        speed = t / count;
     
    }



}

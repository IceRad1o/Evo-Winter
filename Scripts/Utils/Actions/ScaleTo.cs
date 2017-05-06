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


    /// <summary>
    /// 缩放目标值
    /// </summary>
   // public Vector3 destScale = new Vector3();




    /// <summary>
    /// 初始化缩放Action的参数
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="destScale">缩放目标值</param>
    /// <param name="isReverse">是否反转,即缩放至目标值后是否缩放回原来值</param>
    /// <param name="isLoop"> 是否循环缩放</param>
    /// <param name="isOnCanvas">缩放对象是否为UI元素</param>
    void Init(float duration,Vector3 destScale,bool isReverse=true,bool isLoop=false,bool isOnCanvas=false)
    {
        this.duration = duration;
        //this.destScale = destScale;
        this.isReverse = isReverse;
        this.isLoop = isLoop;
        this.isOnCanvas = isOnCanvas;
    }
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

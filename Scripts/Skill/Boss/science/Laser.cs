using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    /// <summary>
    /// 每次旋转改变的差值
    /// </summary>
    public float d_Value_Rotate = 10;
    /// <summary>
    /// 时间间隔
    /// </summary>
    public float interval_Rotate = 0.05f;
    /// <summary>
    /// 旋转持续时间
    /// </summary>
    public float duration_Rotate=2.0f;
    /// <summary>
    /// 伸长是每次改变的差值
    /// </summary>
    public float d_Value_Scale = 0.5f;
    /// <summary>
    /// 伸长的时间间隔
    /// </summary>
    public float interval_Scale = 0.05f;
    /// <summary>
    /// 伸长的持续时间
    /// </summary>
    public float duration_Scale = 2.0f;
    /// <summary>
    /// 伸长的方向
    /// </summary>
    int direction_Scale = 0;


    IEnumerator ChangeRotate()
    {
        yield return new WaitForSeconds(interval_Rotate);
        this.transform.rotation = new Quaternion(0, 0, (this.transform.rotation.z + d_Value_Rotate) % 360, 0);
        duration_Rotate -= interval_Rotate;
        if (duration_Rotate > 0.0f)
            StartCoroutine(ChangeRotate());
        else
        {
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            //direction_Scale=
            StartCoroutine(ChangeScale());
        }
           
    }

    IEnumerator ChangeScale()
    {
        yield return new WaitForSeconds(interval_Scale);
        
    
    }
    
    
    // Use this for initialization
	void Start () {
	
	}
	
}

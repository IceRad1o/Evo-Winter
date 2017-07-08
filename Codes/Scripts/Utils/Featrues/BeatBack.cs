using UnityEngine;
using System.Collections;

public class BeatBack : MonoBehaviour
{

    /*基本设置*/
    public int level=1;
    public int direction = 1;

    [Header("Advanced Options")]
    /// <summary>
    /// 是否使用高级设置
    /// </summary>
    public bool advanced = false;
    /*详细设置*/
    /// <summary>
    /// 速度
    /// </summary>
    [ConditionalHide("advanced", true)]
    public float speed = 15f;
   
    /// <summary>
    /// 距离
    /// </summary>
    [ConditionalHide("advanced", true)]
    public float distance=0.1f;

    [ConditionalHide("advanced", true)]
    public iTween.EaseType easeType;

    [ConditionalHide("advanced", true)]
    public Vector3 distanceV3=new Vector3(1,0,0);
    public void Init(int direction,int level)
    {
        this.level = level;
        this.direction = direction;
        advanced = false;
    }

    public void Init(Vector3 distance, float speed=15f, iTween.EaseType easeType=iTween.EaseType.linear)
    {
        this.speed=speed;
        this.distanceV3=distance;
        this.easeType = easeType;
        advanced=true;
    }

    void Start()
    {
        if(!advanced)
        {
            if (level <= 0)
                return;
            distance = (2 * level - 1) * 0.1f;
            speed = 15f;
            if (direction != 1 && direction != -1)
            {
                Debug.LogError("the direction is not correct!");
                return;
            }
            else
                distanceV3 = new Vector3(direction*distance, 0, 0);
        }
        //iTween.MoveBy(gameObject,)

 
        iTween.MoveBy(gameObject, iTween.Hash("x", distanceV3.x, "y",distanceV3.y,"z",distanceV3.z,"speed", speed, "easeType", easeType));
        Destroy(this);
        //StartCoroutine(Fly());
    }

    //直线
    IEnumerator Fly()
    {
        while (true)
        {
            if (distance > 0)
            {
                this.transform.position = new Vector3(this.transform.position.x + direction * speed,
                      this.transform.position.y,
                      this.transform.position.z);
                distance -= speed;
            }
            else
            {
                Destroy(this);
                break;
            }

            yield return null;
        }
    }
}

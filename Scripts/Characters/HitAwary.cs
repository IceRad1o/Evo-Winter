using UnityEngine;
using System.Collections;

public class HitAwary : MonoBehaviour {

    public float flySpeed;
    Vector3 direction;
    float flyDistance;
    int penetrating;
    int damage;
    int flyPath;
    Vector3 startPosition;
    void Start()
    {
        flySpeed = 10;
        Init(2.5f, 0.1f, 0, new Vector3(1,0,0), 0, 0);
        BeHitAwary();
    }

    public void BeHitAwary()
    {
     
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        StartCoroutine(Fly());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fd">飞行距离</param>
    /// <param name="fs"></param>
    /// <param name="pe"></param>
    /// <param name="dr"></param>
    /// <param name="dm"></param>
    /// <param name="fp"></param>
    public void Init(float fd, float fs, int pe, Vector3 dr, int dm, int fp)
    {
        flyDistance = fd;
        flySpeed = fs;
        penetrating = pe;
        direction = dr;
        damage = dm;
        flyPath = fp;
    }

    IEnumerator Fly()
    {
        //X轴速度
        float speed = flySpeed ;
        //重力加速度
        float g = 1f;
        //Y轴速度
        float v = 2f;
        //时间
        float t = 0;

        while (true)
        {
            float rotateTheta = Mathf.Atan((v - g * t) / (speed)) * 10;
            //Debug.Log("旋转角：" + Mathf.Atan((v-g*t)/(speed))*10);
            if (direction.x < 0)
            {
                if (this.transform.position.x > (startPosition.x - flyDistance))
                {

                    this.transform.rotation = Quaternion.Euler(0f, 0f, 180f - rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        startPosition.y + v * t - 0.5f * g * t * t,
                        this.transform.position.z-speed*direction.z);
                    t += 0.1f;
                }
                else
                {
                    break;
                }
            }

            if (direction.x > 0)
            {
                if (this.transform.position.x < (startPosition.x + flyDistance))
                {
                    this.transform.rotation = Quaternion.Euler(0f, 0f, rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        startPosition.y + v * t - 0.5f * t * t,
                        this.transform.position.z + speed * direction.z);
                    t += 0.1f;
                }
                else
                {
                    break;
                }
            }
            yield return null;
        }
    }

}

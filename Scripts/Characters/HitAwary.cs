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
       
        Init(2.5f, 0.1f,  new Vector3(1,0,0));
       // BeHitAwary();
    }
    //路径1为击退,路径0为击飞
    public void BeHitAwary()
    {
     
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        if(flyPath==0)
            StartCoroutine(FlyPath0());
        else
            StartCoroutine(FlyPath1());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="distance">飞行距离</param>
    /// <param name="speed">速度</param>
    /// <param name="pene">穿透性</param>
    /// <param name="direct">方向</param>
    /// <param name="dmg">伤害</param>
    /// <param name="path">路径</param>
    public void Init(float distance, float speed, Vector3 direct, int path=0, int dmg=0, int pene=0)
    {
        flyDistance = distance;
        flySpeed = speed;
        penetrating = pene;
        direction = direct;
        damage = dmg;
        flyPath = path;
    }

    IEnumerator FlyPath0()
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
            int direct = 0;
            if (direction.x < 0)
                direct = -1;
            else if (direction.x > 0)
                direct = 1;
        
                //if ((this.transform.position.x!=startPosition.x )||Mathf.Abs(this.transform.position.z-startPosition.z)>float.Epsilon)
                if (v > 0.5f * g * t||t==0)
                {
                    

                   //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f*(1-direct) + direct*rotateTheta);
                    //Vector3 temp = new Vector3(this.transform.position.x + direct * speed,
                    //    startPosition.y + v * t - 0.5f * g * t * t,
                    //   this.transform.position.z);
                  //  this.GetComponent<Rigidbody>().MovePosition(temp);
                    this.transform.position = new Vector3(this.transform.position.x + direct*speed,
                        startPosition.y + v * t - 0.5f * g * t * t,
                       this.transform.position.z);
                    t += 0.1f;
                }
                else
                {
                    break;
                }
   
            yield return null;
        }
    }


    //发射物飞行路径4，水平抛物线
    IEnumerator FlyPath4()
    {
        //X轴速度
        float speed = flySpeed ;
        //重力加速度
        float g = 1f;
        //Y轴速度
        float v = 0f;
        //时间
        float t = 0;

        flyDistance = flyDistance / 2;
        while (true)
        {
            float rotateTheta = Mathf.Atan((v - g * t) / (speed)) * 10;
            //Debug.Log("旋转角：" + Mathf.Atan((v-g*t)/(speed))*10);
            if (direction.x < 0)
            {
                if (this.transform.position.x > (startPosition.x - flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        this.transform.position.y,
                        this.transform.position.z);
                }
                else if (this.transform.position.y > (startPosition.y - 0.5f))
                {

                    this.transform.rotation = Quaternion.Euler(0f, 0f, 180f - rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        startPosition.y + v * t - 0.5f * g * t * t,
                        this.transform.position.z);
                    t += 0.1f;
                }
                else
                {
                    //this.Destroy();
                    break;
                }
            }

            if (direction.x > 0)
            {
                if (this.transform.position.x < (startPosition.x + flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        this.transform.position.y,
                        this.transform.position.z);
                }
                else if (this.transform.position.y > (startPosition.y - 0.5f))
                {

                    this.transform.rotation = Quaternion.Euler(0f, 0f, rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        startPosition.y + v * t - 0.5f * g * t * t,
                        this.transform.position.z);
                    t += 0.1f;
                }
                else
                {
                    //this.Destroy();
                    break;
                }
            }
            yield return null;
        }
    }



    //发射物飞行路径1, 直线
    IEnumerator FlyPath1()
    {
        float speed = flySpeed ;
        while (true)
        {
            if (direction.x < 0)
            {
                if (this.transform.position.x > (startPosition.x - flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        this.transform.position.y,
                        this.transform.position.z);
                }
                else
                {
                   // this.Destroy();
                    break;
                }
            }

            if (direction.x > 0)
            {
                if (this.transform.position.x < (startPosition.x + flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        this.transform.position.y,
                        this.transform.position.z);
                }
                else
                {
                   // this.Destroy();
                    break;
                }
            }
            yield return null;
        }
    }

}

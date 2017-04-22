using UnityEngine;
using System.Collections;

public class Missiles : MonoBehaviour {
    //是否调用fly
    public bool isFly = true;
    //飞行距离
    public float flyDistance = 1.5f;
    public int distanceLevel = 1;
    public float distanceBuff = 1;
    //飞行速度
    public float flySpeed = 0.02f;
    public int speedLevel = 1;
    public float speedBuff = 1;

    //穿透性，0无，1有
    public int penetrating = 0;
    //方向，-1左，1右
    public int direction;
    //飞行路径,0-N
    public int flyPath = 1;
    //初始位置
    private Vector3 startPosition;


    //public override void Awake()
    //{
    //    Debug.Log("Awake");
    //    base.Awake();
    //    RoomElementID = 0;
    //}

    /// <summary>
    /// 初始化倍数
    /// </summary>
    /// <param name="fd">飞行距离</param>
    /// <param name="fs">发射物飞行速度</param>
    public void InitMissiles(float fd, float fs)
    {
        distanceBuff = fd;
        speedBuff = fs;
    }

    //发射物飞行
    public void Fly()
    {
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        if (flyPath > 0)
        {
            if (direction > 0)
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            switch (flyPath)
            {
                case 1://直线
                    StartCoroutine(FlyPath1());
                    break;
                case 2://斜向上抛物线
                    StartCoroutine(FlyPath2());
                    break;
                case 3://竖直下落
                    StartCoroutine(FlyPath3());
                    break;
                case 4://水平抛物线
                    StartCoroutine(FlyPath4());
                    break;
                case 5://Z轴上斜线
                    StartCoroutine(FlyPath5());
                    break;
                case 6://上下圆环
                    StartCoroutine(FlyPath6());
                    break;
                case 7://Z轴下斜线
                    StartCoroutine(FlyPath7());
                    break;
            }
        }
    }
    //发射物飞行路径1, 直线
    IEnumerator FlyPath1()
    {
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        float distance = flyDistance * distanceBuff + distanceLevel * 0.2f;
        while (true)
        {
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed, 
                        this.transform.position.y, 
                        this.transform.position.z);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed, 
                        this.transform.position.y, 
                        this.transform.position.z);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }

    //发射物飞行路径2，抛物线
    IEnumerator FlyPath2()
    {
        //X轴速度
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        //飞行距离
        float distance = flyDistance * distanceBuff + distanceLevel * 0.2f;
        //Y轴速度
        float v = 0.5f * 0.1f * distance / speed;
        //时间
        float t = 0;

        while (true)
        {
            float rotateTheta = 15 * (distance / 2 - Mathf.Abs(this.transform.position.x - startPosition.x));
            //Debug.Log("旋转角：" + Mathf.Atan(100*(v-t)/(speed))*10);
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - distance))
                {

                    this.transform.rotation = Quaternion.Euler(0f, 0f, 180f-rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x - speed, 
                        startPosition.y + v*t - 0.5f*t*t, 
                        this.transform.position.z);
                    t+=0.1f;
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + distance))
                {
                    this.transform.rotation = Quaternion.Euler(0f, 0f, rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x + speed, 
                        startPosition.y + v*t - 0.5f*t*t, 
                        this.transform.position.z);
                    t += 0.1f;
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }

    //发射物飞行路径3, 竖直下落
    IEnumerator FlyPath3()
    {
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        float ySpeed = 0.2f;
        float high = 4f;
        int arrive = 0;
        float xDistance;
        if (direction < 0) xDistance =  -1 * (flyDistance * distanceBuff + distanceLevel * 0.2f);
        else xDistance = flyDistance * distanceBuff + distanceLevel * 0.2f;

        while (true)
        {
            //向上
            if ((this.transform.position.y - startPosition.y < high) && (arrive == 0))
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                this.transform.position = new Vector3(this.transform.position.x,
                    this.transform.position.y + ySpeed,
                    this.transform.position.z);
            }

            //到达顶部
            else if ((this.transform.position.y - startPosition.y >= high) && (arrive == 0))
            {
                arrive = 1;
            }
            //下落
            else if ((this.transform.position.y - startPosition.y > 0) && (arrive == 1))
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                this.transform.position = new Vector3(startPosition.x + xDistance / 1.5f,
                    this.transform.position.y - ySpeed,
                    this.transform.position.z);
            }
            //结束
            else
            {
                Destroy(this.gameObject);
                break;
            }    

            yield return null;
        }
    }

    //发射物飞行路径4，水平抛物线
    IEnumerator FlyPath4()
    {
        //X轴速度
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        //重力加速度
        float g = 1f;
        //Y轴速度
        float v = 0f;
        //时间
        float t = 0;

        float distance = flyDistance * distanceBuff + distanceLevel * 0.2f;
        while (true)
        {
            float rotateTheta = Mathf.Atan((v - g * t) / (speed)) * 10;
            //Debug.Log("旋转角：" + Mathf.Atan((v-g*t)/(speed))*10);
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - distance))
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
                    Destroy(this.gameObject);
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + distance))
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
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }

    //发射物飞行路径5, Z轴上斜线
    IEnumerator FlyPath5()
    {
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        float zSpeed = speed / 3;
        float distance = flyDistance * distanceBuff + distanceLevel * 0.2f;
        while (true)
        {
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        this.transform.position.y + zSpeed,
                        this.transform.position.z + zSpeed);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        this.transform.position.y + zSpeed,
                        this.transform.position.z + zSpeed);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }
    //发射物飞行路径6, 上下圆环
    IEnumerator FlyPath6()
    {
        int loop = 30;
        float theta = 0;
        float t = flySpeed * speedBuff + speedLevel * 0.01f;
        float r = (flyDistance * distanceBuff + distanceLevel * 0.2f) / 10;
        Vector3 startPosition;
        penetrating = 1;
        while (true)
        {
            if (theta<2*3.14*loop)
            {
                startPosition = Player.Instance.transform.position;
                this.transform.position = new Vector3(startPosition.x + 2*r*Mathf.Sin(theta),
                        startPosition.y + r * Mathf.Cos(theta),
                        startPosition.y + r * Mathf.Cos(theta));
                theta += t;
                //Debug.Log("theta:" + theta + "     sin:" + Mathf.Sin(theta) + "     cos" + Mathf.Cos(theta));
            }
            else
            {
                Destroy(this.gameObject);
                penetrating = 0;
                break;
            }
            yield return null;
        }
    }

    //发射物飞行路径7, Z轴下斜线
    IEnumerator FlyPath7()
    {
        float speed = flySpeed * speedBuff + speedLevel * 0.01f;
        float zSpeed = speed / 3;
        float distance = flyDistance * distanceBuff + distanceLevel * 0.2f;
        while (true)
        {
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed,
                        this.transform.position.y - zSpeed,
                        this.transform.position.z - zSpeed);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + distance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed,
                        this.transform.position.y - zSpeed,
                        this.transform.position.z - zSpeed);
                }
                else
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }

    //碰撞检测
    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("Missile碰撞标签：" + other.tag);
    //    if (other.tag == "Enemy")
    //    {
    //        //other.GetComponent<Enemy>().Health-=damage;
    //        if (penetrating==0)
    //        {
    //            //animator.SetTrigger("MissileBomb");
    //            StartCoroutine(Wait(0.2f));
    //            Destroy(this.gameObject);
    //        }
    //    }
    //    if (other.tag == "Box")
    //    {
    //        //other.GetComponent<Box>().OpenBox();
    //        if (penetrating==0)
    //        {
    //            //animator.SetTrigger("MissileBomb");
    //            StartCoroutine(Wait(0.2f));
    //            Destroy(this.gameObject);
    //        }
    //    }
    //    if (other.tag == "Wall")
    //    {
    //        StartCoroutine(Wait(0.2f));
    //        Destroy(this.gameObject);
    //    }
    //}





	void Start () {
        if (isFly) Fly();
	}
	

	void Update () {
	
	}

    //等待延迟
    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);     
    }
}

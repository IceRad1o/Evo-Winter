using UnityEngine;
using System.Collections;

public class Missiles : RoomElement {

    //飞行距离
    private float flyDistance;
    //飞行速度
    private float flySpeed;
    //穿透性，0无，1有
    private int penetrating;
    //方向，-1左，1右
    private int direction;
    //伤害
    private int damage;
    //飞行路径,0-N
    private int flyPath;
    //初始位置
    private Vector3 startPosition;

    public override void Awake()
    {
        Debug.Log("Awake");
        base.Awake();
        RoomElementID = 0;
    }

    //构造函数,距离，速度，穿透性，方向，伤害，飞行路径
    public void InitMissiles(float fd, float fs, int pe, int dr, int dm, int fp)
    {
        flyDistance = fd;
        flySpeed = fs;
        penetrating = pe;
        direction = dr;
        damage = dm;
        flyPath = fp;
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
                this.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
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
            }
        }
    }
    //发射物飞行路径1, 直线
    IEnumerator FlyPath1()
    {
        float speed = flySpeed /30;
        while (true)
        {
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x - speed, 
                        this.transform.position.y, 
                        this.transform.position.z);
                }
                else
                {
                    this.Destroy();
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + flyDistance))
                {
                    this.transform.position = new Vector3(this.transform.position.x + speed, 
                        this.transform.position.y, 
                        this.transform.position.z);
                }
                else
                {
                    this.Destroy();
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
        float speed = flySpeed / 27;
        //重力加速度
        float g = 1f;
        //Y轴速度
        float v = 2f;
        //时间
        float t = 0;

        while (true)
        {
            float rotateTheta = Mathf.Atan((v-g*t)/(speed))*10;
            //Debug.Log("旋转角：" + Mathf.Atan((v-g*t)/(speed))*10);
            if (direction < 0)
            {
                if (this.transform.position.x > (startPosition.x - flyDistance))
                {

                    this.transform.rotation = Quaternion.Euler(0f, 0f, 180f-rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x - speed, 
                        startPosition.y + v*t - 0.5f*g*t*t, 
                        this.transform.position.z);
                    t+=0.1f;
                }
                else
                {
                    this.Destroy();
                    break;
                }
            }

            if (direction > 0)
            {
                if (this.transform.position.x < (startPosition.x + flyDistance))
                {
                    this.transform.rotation = Quaternion.Euler(0f, 0f, rotateTheta);
                    this.transform.position = new Vector3(this.transform.position.x + speed, 
                        startPosition.y + v*t - 0.5f*t*t, 
                        this.transform.position.z);
                    t += 0.1f;
                }
                else
                {
                    this.Destroy();
                    break;
                }
            }
            yield return null;
        }
    }

    //发射物飞行路径3, 竖直下落
    IEnumerator FlyPath3()
    {
        float speed = flySpeed / 100;
        float ySpeed = 0.1f;
        float high = 4f;
        int arrive = 0;
        float xDistance;
        if (direction < 0) xDistance = flyDistance * -1;
        else xDistance = flyDistance;

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
                this.Destroy();
                break;
            }    

            yield return null;
        }
    }

    //发射物飞行路径4，水平抛物线
    IEnumerator FlyPath4()
    {
        //X轴速度
        float speed = flySpeed / 27;
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
            if (direction < 0)
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
                    this.Destroy();
                    break;
                }
            }

            if (direction > 0)
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
                    this.Destroy();
                    break;
                }
            }
            yield return null;
        }
    }




    //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Missile碰撞标签：" + other.tag);
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Health-=damage;
            if (penetrating==0)
            {
                //animator.SetTrigger("MissileBomb");
                StartCoroutine(Wait(0.2f));
                Destroy();
            }
        }
        if (other.tag == "Box")
        {
            //other.GetComponent<Box>().OpenBox();
            if (penetrating==0)
            {
                //animator.SetTrigger("MissileBomb");
                StartCoroutine(Wait(0.2f));
                Destroy();
            }
        }
    }





	void Start () {

	}
	

	void Update () {
	
	}

    //等待延迟
    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);     
    }
}

using UnityEngine;
using System.Collections;

public class BeatBack : MonoBehaviour
{

    public int level;
    public float flySpeed=0.1f;
    public int direction;
    float flyDistance;
    //int penetrating;
    //int damage;
    //int flyPath;
    Vector3 startPosition;

    void Start()
    {
        flySpeed = 0.1f;
        if (level <= 0)
            return;
        flyDistance = (2*level-1) * 0.1f;
        if (direction != 1 || direction != -1)
        {
            Debug.LogError("the direction is not correct!");
            return; 
        }
        StartCoroutine(Fly());
    }
    IEnumerator FlyPath0()
    {
        //X轴速度
        float speed = flySpeed;
        //重力加速度
        float g = 1f;
        //Y轴速度
        float v = 2f;
        //时间
        float t = 0;

        while (true)
        {
            //float rotateTheta = Mathf.Atan((v - g * t) / (speed)) * 10;
            if (v > 0.5f * g * t || t == 0)
            {
                //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f*(1-direct) + direct*rotateTheta);
                this.transform.position = new Vector3(this.transform.position.x + direction * speed,
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



    //发射物飞行路径1, 直线
    IEnumerator Fly()
    {
        while (true)
        {
            if (flyDistance>0)
            {
                this.transform.position = new Vector3(this.transform.position.x + direction * flySpeed,
                      this.transform.position.y,
                      this.transform.position.z);
                flyDistance -= flySpeed;
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

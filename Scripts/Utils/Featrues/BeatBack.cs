using UnityEngine;
using System.Collections;

public class BeatBack : MonoBehaviour
{


    public int level;
    public float flySpeed = 0.2f;
    public int direction;

    /// <summary>
    /// 初始值根据level发生变化
    /// </summary>
    public float flyDistance;

    void Start()
    {
        if (level <= 0)
            return;
        flyDistance = (2 * level - 1) * 0.1f;
        if (direction != 1 && direction != -1)
        {
            Debug.LogError("the direction is not correct!");
            return;
        }
        StartCoroutine(Fly());
    }

    //发射物飞行路径1, 直线
    IEnumerator Fly()
    {
        Debug.Log("enter bacjk");
        while (true)
        {
            if (flyDistance > 0)
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

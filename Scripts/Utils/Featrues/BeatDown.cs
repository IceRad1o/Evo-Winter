using UnityEngine;
using System.Collections;

public class BeatDown : MonoBehaviour {


    public int levelX;
    public int levelY=4;
    public float flySpeedX = 0.15f;
    public float flySpeedY = 2f;
    public float g = 1.2f;
 
    public int direction;



    void Start()
    {
        //if (levelX <= 0)
          //  return;
        flySpeedX = levelX * 0.1f;
        flySpeedY= levelY * 0.5f;
        if (direction != 1 && direction != -1)
        {
            Debug.LogError("the direction is not correct!"+direction);
            return;
        }
        StartCoroutine(Fly());
    }
    IEnumerator Fly()
    {
   

        //时间
        float t = 0;
        float posY = this.transform.position.y;
        Debug.Log("enter");
        while (true)
        {
            if (flySpeedY > 0.5f * g * t || t == 0)
            {
          
                this.transform.position = new Vector3(this.transform.position.x + direction * flySpeedX,
                  posY + flySpeedY * t - 0.5f * g * t * t,
                   this.transform.position.z);
                t += 0.1f;
          
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

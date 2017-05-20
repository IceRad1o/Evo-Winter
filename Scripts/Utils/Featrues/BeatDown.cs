using UnityEngine;
using System.Collections;

public class BeatDown : MonoBehaviour {


    public int levelX=2;
    public int levelY=4;
    public float flySpeedX = 0.15f;
    public float flySpeedY = 2f;
    public float g = 1.2f;
 
    public int direction=1;

    public void Init(int direction=1,int levelX=2,int levelY=4)
    {
        this.direction = direction;
        this.levelX = levelX;
        this.levelY = levelY;
    }

    void Start()
    {
        if (levelX < 0)
            return;
        if (levelY < 0)
            return;
        if (levelX == 0 && levelY == 0)
            return;
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

        GroundObject go = GetComponent<GroundObject>();
        if (go)
            go.enabled = false;
        //时间
        float t = 0;
        float posY = this.transform.position.y;
        float posZ = this.transform.position.z;
        //Debug.Log("enter");
        while (true)
        {
            if (flySpeedY > 0.5f * g * t || t == 0)
            {

                this.transform.position = new Vector3(this.transform.position.x + direction * flySpeedX,
                  posY + flySpeedY * t - 0.5f * g * t * t,
                   posZ);
                //this.transform.position = new Vector3(this.transform.position.x, posY, transform.position.z) + new Vector3(direction * flySpeedX, flySpeedY * t - 0.5f * g * t * t);
                t += 0.1f;
          
            }
            else
            {
                Destroy(this);
                if (go)
                    go.enabled = true;
                break;
            }
            yield return null;
        }
    }
}

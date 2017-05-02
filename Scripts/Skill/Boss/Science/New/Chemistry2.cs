using UnityEngine;
using System.Collections;

public class Chemistry2 : Chemistry{
    public float speed = 1.0f;
    public override void Start()
    {
        base.Start();
        //设置速度
        float time = (Player.Instance.transform.position -this.transform.position).sqrMagnitude / speed;
        GetComponent<MoveTo>().duration =time ;
        gameObject.AddComponent<AutoDestoryedObject>().destroyTime = time;


    }
}

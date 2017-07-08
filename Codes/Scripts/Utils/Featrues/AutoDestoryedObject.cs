using UnityEngine;
using System.Collections;
/// <summary>
/// 自动延时销毁gameObject,兼容RoomElement的销毁
/// Author:IfYan
/// Latest Update Time: 2017.5.14
/// </summary>
public class AutoDestoryedObject : MonoBehaviour {

    public float destroyTime=1f;
	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDestroy());
	}

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        RoomElement re = GetComponent<RoomElement>();
        if (re)
            re.Destroy();
        else
            Destroy(this.gameObject);
    }
}

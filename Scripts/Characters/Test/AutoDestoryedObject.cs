using UnityEngine;
using System.Collections;
/// <summary>
/// 自动销毁gameObject
/// </summary>
public class AutoDestoryedObject : MonoBehaviour {

    public float destroyTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDestroy());
	}

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}

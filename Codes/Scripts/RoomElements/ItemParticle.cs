using UnityEngine;
using System.Collections;

public class ItemParticle : MonoBehaviour {

    public float rotateTheta;
    public float rotateSpeed = 0.1f;
	void Start () {
        rotateTheta = 0;
        StartCoroutine(Rotate());
	}

    IEnumerator Rotate()
    {
        while (true)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotateTheta);
            rotateTheta = (rotateSpeed+rotateTheta)%360f;
            yield return null;
        }
    }


}

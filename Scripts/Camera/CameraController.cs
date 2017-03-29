using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Vector3 delta;
	// Use this for initialization
	void Start () {
        delta = new Vector3(5, 0, 0);
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {

        transform.position = player.transform.position + offset;
        if (transform.position.x > 6.8f)
            transform.position= new Vector3(6.8f, transform.position.y,transform.position.z);
        if (transform.position.x < -6.8f)
            transform.position = new Vector3(-6.8f, transform.position.y, transform.position.z);
        if(transform.position.y < -1.5f)
            transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
    }
}

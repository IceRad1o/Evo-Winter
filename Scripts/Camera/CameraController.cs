using UnityEngine;
using System.Collections;

public class CameraController : ExUnitySingleton<CameraController>{

    public enum CameraMoveType
    {
        RemainOffset,
        Smooth
    }

    public CameraMoveType type;
    float[] size = { 0f, 2.64f, 6.8f};
    private Vector3 offset;
    private Vector3 delta;
    int sizeNum;
    int smoothMoveFrame=3; 
	// Use this for initialization
	void Start () {
        //player=GameObject.FindGameObjectWithTag("Player");
        delta = new Vector3(5, 0, 0);
        offset = transform.position - Player.Instance.transform.position;
       
	}


  

	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        
        sizeNum = RoomManager.Instance.RoomSize-1;
        if (type == CameraMoveType.RemainOffset)
            MoveWithPlayer();
        else
            SmoothMoveWithPlayer();
      
        CheckBoundary();
        //Debug.Log("Camera:" + transform.position.x);
    }


    void SmoothMoveWithPlayer()
    {
        //计算距离
        Vector3 distance = -transform.position + Player.Instance.transform.position + offset;
        //判断是否已达到要求
        if (distance.x < 0.2f&& distance.x >- 0.2f)
            return;
        transform.position += distance/smoothMoveFrame;

    }

    void MoveWithPlayer()
    {
        transform.position = Player.Instance.transform.position + offset;
    }

    void CheckBoundary()
    {
        if (transform.position.x > size[sizeNum])
            transform.position = new Vector3(size[sizeNum], transform.position.y, transform.position.z);
        if (transform.position.x < -size[sizeNum])
            transform.position = new Vector3(-size[sizeNum], transform.position.y, transform.position.z);
        if (transform.position.y < -1.25f)
            transform.position = new Vector3(transform.position.x, -1.25f, transform.position.z);
    }


}

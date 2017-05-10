using UnityEngine;
using System.Collections;
/// <summary>
/// CameraController
/// Brief:For camera follow player.
/// Author:IfYan
/// LatestUpdateTime:2017.5.9
/// </summary>
public class CameraController : ExUnitySingleton<CameraController>{

    public enum CameraMoveType
    {
        RemainOffset,
        Smooth
    }
    /// <summary>
    /// Camera Move Type
    /// </summary>
    public CameraMoveType type;
    /// <summary>
    /// Room X size
    /// </summary>
    float[] sizeX = { 0f, 2.64f, 6.8f};
    /// <summary>
    /// Room Y boundary
    /// </summary>
    float[] sizeY = { -1.25f, 0.206f };

    private Vector3 offset;
    private Vector3 delta;
    int sizeNum;
    int smoothMoveFrame=3; 

	void Start () {
 
        delta = new Vector3(5, 0, 0);
        offset = transform.position - Player.Instance.transform.position;
       
	}

    void LateUpdate()
    {
        
        sizeNum = RoomManager.Instance.RoomSize-1;
        if (type == CameraMoveType.RemainOffset)
            MoveWithPlayer();
        else
            SmoothMoveWithPlayer();
      
        CheckBoundary();

    }

    /// <summary>
    /// Smooth Move Type
    /// But it may cause some bug.
    /// </summary>
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
        if (transform.position.x > sizeX[sizeNum])
            transform.position = new Vector3(sizeX[sizeNum], transform.position.y, transform.position.z);
        if (transform.position.x < -sizeX[sizeNum])
            transform.position = new Vector3(-sizeX[sizeNum], transform.position.y, transform.position.z);
        if (transform.position.y < sizeY[0])
            transform.position = new Vector3(transform.position.x, sizeY[0], transform.position.z);
        if (transform.position.y > sizeY[1])
            transform.position = new Vector3(transform.position.x, sizeY[1], transform.position.z);
    }


}

using UnityEngine;
using System.Collections;

public class CameraMove : ExUnitySingleton<CameraMove>
{


	void Start () {
        RoomManager.Instance.AddObserver(this);
	}

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "EnterRoom")
        {
            StartCoroutine("MoveRoom");
          
        }


    }

    IEnumerator MoveRoom()
    {
        //MoveBy mb = this.gameObject.AddComponent<MoveBy>();
        //mb.duration = 0.3f;
        //mb.isReverse = true;
        //mb.deltaPosition = new Vector3(0, 5, 0);
        GetComponent<CameraController>().enabled = false;
        int count = 20;
        float speed=5.0f/count;
        while(count--!=0)
        {
            gameObject.transform.position += new Vector3(0, speed, 0);
            yield return null;
        }

        gameObject.transform.position -= new Vector3(0, 5, 0);
        GetComponent<CameraController>().enabled = true;
           

    }

}

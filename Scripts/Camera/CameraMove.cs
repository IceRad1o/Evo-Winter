using UnityEngine;
using System.Collections;

public class CameraMove : ExUnitySingleton<CameraMove>
{
    int dir;//0=上,1=下,2=左，3=右

	void Start () {
        RoomManager.Instance.AddObserver(this);
	}

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "LeaveRoom")
        {
            Debug.Log(123321);
            dir = int.Parse(str[1]);
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


        Hashtable args = new Hashtable();
        args.Add("time", 0.33f);//设置动画实现消耗时间 
        args.Add("easeType", iTween.EaseType.easeInQuad);



        if (dir < 2)
        {
            args.Add("x", 0);
            Debug.Log("Y" + (5 - dir * 10));
            args.Add("y", 5 - dir * 10);
        }
        else
        {
            Debug.Log("x" + (5 - (dir-2) * 10));
            args.Add("x", -5+(dir-2)*10);
            args.Add("y", 0);
        }
        args.Add("z", 0);

        iTween.MoveBy(gameObject, args);
        //float speed=5.0f/count;
        //while(count--!=0)
        //{
        //    gameObject.transform.position += new Vector3(0, speed, 0);
        //    yield return null;
        //}
        yield return new WaitForSeconds(0.33f);
        //gameObject.transform.position -= new Vector3(0, 5, 0);
        GetComponent<CameraController>().enabled = true;
           

    }

}

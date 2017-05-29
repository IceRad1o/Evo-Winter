using UnityEngine;
using System.Collections;
/// <summary>
/// 贿赂 扣血掉金币
/// </summary>
public class Grease : ExSubject
{
    public GameObject trickCoin;

    void Start()
    {
        GetComponent<RoomElement>().AddObserver(this);
    }

    /**/
    public override void OnNotify(string msg)
    {
        //Debug.Log("msg:" + msg);
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "HealthPercent")
        {
            float a = float.Parse(str[1]);
            float b = float.Parse(str[2]);
            if (a >= b)
                return;
            Vector3 bossPos = this.transform.position;
            Vector3 startPoint = bossPos + new Vector3(0, 0.5f, 0);
            int num = Random.Range(0, 6);
            if (num < 3)
                num = 0;
            else if (num < 5)
                num = 1;
            else
                num = 2;
            for (int i = 0; i < num; i++)
            {
                Vector3 deltaPos = new Vector3((Random.value - 0.5f) * 5, (Random.value - 0.5f) * 5);
                GameObject ins = Instantiate(trickCoin, startPoint, Quaternion.identity) as GameObject;
                ins.GetComponent<RoomElement>().Master = this.GetComponent<RoomElement>();
                Vector3[] paths = new Vector3[3];
                paths[0] = startPoint;
                paths[1] = startPoint + deltaPos / 3 + new Vector3(0, 0.75f, 0);
                paths[2] = bossPos + deltaPos;
                iTween.MoveTo(ins, iTween.Hash("path", paths, "speed", 10f, "easeType", iTween.EaseType.linear));
            }

        }
    }





}

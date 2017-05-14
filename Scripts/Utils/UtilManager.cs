using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/*UtilManager
 *@Brief 负责提供一些游戏工具函数
 *@Author YYF
 *@Time 16.12.23
 */
public class UtilManager : UnitySingleton<UtilManager> 
{

    /*GetCurTime
     *@Brief 获取当前时间
     *@Return System.DateTime
     *@Remark 可用System.DateTime.ToString("yyyyMMddHHmmss")进行转换
     */
    System.DateTime GetCurTime()
    {
        return System.DateTime.Now;
    }

    /// <summary>
    /// 解析消息,开头无";"
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public string GetMsgField(string msg,int num)
    {
        string[] str1 = msg.Split(';');//分割
        if (num < str1.Length)
            return str1[num];
        else
            return null;
    }

    public string[] GetMsgFields(string msg)
    {
        return msg.Split(';');
    }

     /// <summary>
    /// 解析消息，开头有";"
    /// </summary>
    /// <param name="_msg">要解析的消息</param>
    /// <param name="number">需要返回的字段</param>
    /// <returns>返回的字段，string形式，找不到对应字段返回“Error”</returns>
    public string GetFieldFormMsg(string msg, int number) {
        string str="";
        int num=-1,i=0;
        for (i = 0; i < msg.Length; i++)
        {
            if (num == number)
            {
                if (msg[i] != ';')
                    str += msg[i];
                else
                    return str;
            }
            else {
                if (msg[i] == ';')
                    num++;
            }
        }
        if (num == number)
            return str;
        else
            return "Error";

    }
    /// <summary>
    /// 判断消息的匹配，并解析
    /// </summary>
    /// <param name="msg">消息匹配段</param>
    /// <param name="_msg">要解析的消息</param>
    /// <param name="number">消息的字段</param>
    /// <returns>获取的字段string，“Fail”表示不匹配，“Error”表示无该字段</returns>
    public string MatchFiledFormMsg(string msg,string srcMsg, int number) {
        if (msg.Length > srcMsg.Length)
            return "Fail";
        for (int i = 0; i < msg.Length; i++)
        {
            if (msg[i] != srcMsg[i])
                return "Fail";
        }
        string str = "";
        int num = -1;
        for (int i = 0; i < srcMsg.Length; i++)
        {
            if (num == number)
            {
                if (srcMsg[i] != ';')
                    str += srcMsg[i];
                else
                    return str;
            }
            else
            {
                if (srcMsg[i] == ';')
                    num++;
            }
        }

        if (num == number)
            return str;
        else
            return "Error";

        
    }



    /// <summary>
    /// 解析id
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="part">每部分ID的长度</param>
    /// <returns></returns>
    public int[] DecomposeID(int id,int[] part) 
    {
        int[] a = { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000};
        List<int> array=new List<int>();
        for (int i = 0; i < part.Length; i++)
        {
            array.Add(id % a[part[i]]);
            id /= a[part[i]];
        }

        return array.ToArray();
    }



    public void CreateEffcet(GameObject pfb, Vector3 pos = new Vector3())
    {
        if (pfb == null)
            return;
        GameObject prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = pos;
    }

    public void CreateEffcet(GameObject pfb, GameObject ob, Vector3 deviation = new Vector3())
    {
        if (pfb == null || ob==null)
            return;
        Vector3 s = new Vector3(ob.gameObject.transform.position.x + deviation.x, ob.gameObject.transform.position.y + deviation.y, ob.gameObject.transform.position.z + deviation.z);
        GameObject prefabInstance = Instantiate(pfb);
        Vector3 Scale = prefabInstance.transform.localScale;
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = ob.gameObject.transform;
        prefabInstance.transform.localScale = Scale;
    
    }

    public GameObject CreateEffcet(string pfbPath, Vector3 pos = default(Vector3))
    {
        if (pfbPath == "" )
            return null;
        GameObject pfb = Resources.Load(pfbPath) as GameObject;
        GameObject prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = pos;




        return prefabInstance;

    }

    public GameObject CreateEffcet(string pfbPath, GameObject ob, Vector3 deviation = default(Vector3))
    {
        if (pfbPath == "" || ob == null)
            return null;
        GameObject pfb = Resources.Load(pfbPath) as GameObject;
        Vector3 s = new Vector3(ob.gameObject.transform.position.x + deviation.x, ob.gameObject.transform.position.y + deviation.y, ob.gameObject.transform.position.z + deviation.z);
        GameObject prefabInstance = Instantiate(pfb);
        Vector3 Scale = prefabInstance.transform.localScale;
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = ob.gameObject.transform;
        prefabInstance.transform.localScale = Scale;

        return prefabInstance;

    }

    /// <summary>
    /// 将游戏中的坐标转换成校正后的坐标,尤其对非地面物体,空中飞行物体有效
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static Vector3 Trans(Vector3 pos)
    {
        return new Vector3(pos.x, 0.707107f * (pos.y - pos.z), 0.707107f * (pos.z + pos.y));
    }
    public static Vector3 Trans(float x,float y,float z=0)
    {
        return Trans(new Vector3(x, y, z));
    }

}

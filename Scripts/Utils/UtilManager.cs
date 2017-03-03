using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
    /// 解析消息
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



}

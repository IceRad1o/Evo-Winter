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





}

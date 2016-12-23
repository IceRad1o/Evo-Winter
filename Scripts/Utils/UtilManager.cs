using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*UtilManager
 *@Brief 负责提供一些游戏工具函数
 *@Author YYF
 *@Time 16.12.23
 */
public class UtilManager : MonoBehaviour {

    /*GetInstance
    *@Brief 获取一个UtilManager实例 
    *@Return UtilManager
    */
    static public UtilManager GetInstance()
    {
        if (instance)
            return instance;
        else
        {
            instance = Instantiate(instance);
            return instance;
        }

    }

    /*GetCurTime
     *@Brief 获取当前时间
     *@Return System.DateTime
     *@Remark 可用System.DateTime.ToString("yyyyMMddHHmmss")进行转换
     */
    System.DateTime GetCurTime()
    {
        return System.DateTime.Now;
    }



    private static UtilManager instance = null;  //单例

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
    }



}

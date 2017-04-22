using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 玩家详细信息模块
/// </summary>
public class PlayerInfo : ExUnitySingleton<PlayerInfo> {

    /// <summary>
    /// 展示玩家详细信息
    /// </summary>
    public void Display()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏玩家详细信息
    /// </summary>
    public void Undisplay()
    {
        gameObject.SetActive(false);
    }





	void Start () {
        gameObject.SetActive(false);
	}


}

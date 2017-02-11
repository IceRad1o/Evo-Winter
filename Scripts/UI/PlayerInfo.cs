using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 玩家详细信息模块
/// </summary>
public class PlayerInfo : UnitySingleton<PlayerInfo> {

    /// <summary>
    /// 展示玩家详细信息
    /// </summary>
    public void Display()
    {
        playerInfoBg.SetActive(true);
    }

    /// <summary>
    /// 隐藏玩家详细信息
    /// </summary>
    public void Undisplay()
    {

    }

     public GameObject playerInfoBg; //玩家信息



	void Start () {
        playerInfoBg.SetActive(false);
	}


	void Update () {
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfo : UnitySingleton<PlayerInfo> {

    public void Display()
    {
        playerInfoBg.SetActive(true);
    }

     public GameObject playerInfoBg; //玩家信息


	void Start () {
        playerInfoBg.SetActive(false);
	}


	void Update () {
	
	}
}

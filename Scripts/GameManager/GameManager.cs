using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //参数的声明
    public static GameManager instance = null;
    public RoomManager roomScript;

    private bool doingSetup;



	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        roomScript = GetComponent<RoomManager>();
        InitGame();
	}

    //游戏初始化
    void InitGame()
    {
        doingSetup = true;

        roomScript.SetupScene();
    }

	

}

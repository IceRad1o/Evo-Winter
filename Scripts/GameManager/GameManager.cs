using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //参数的声明
    public static GameManager instance = null;
    public RoomManager roomScript;
    public CheckpointManager checkpointScrip;

    private bool doingSetup;



	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        roomScript = GetComponent<RoomManager>();
        checkpointScrip = GetComponent<CheckpointManager>();
        InitGame();
	}

    //游戏初始化
    void InitGame()
    {
        doingSetup = true;

        checkpointScrip.SetupCheckpoint();

        roomScript.SetDoorDierction(checkpointScrip.surroundRoom);

        roomScript.SetupScene();
    }

	

}

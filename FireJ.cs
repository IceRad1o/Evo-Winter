﻿using UnityEngine;
using System.Collections;

public class FireJ : MonoBehaviour {

    public GameObject m_Missile;
    public int numberOfMissile;
    public int direction;
    public int pathNumber;


	// Use this for initialization
	void Start () {
        numberOfMissile = 0;
        direction = -1;
        pathNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pathNumber == 1)
                pathNumber = 2;
            else
                pathNumber = 1;
        }
	}

    private void Fire()
    {
        Debug.Log("进入Fire()");
        GameObject missileInstance =
               Instantiate(m_Missile, Player.Instance.Character.transform.position, Quaternion.identity) as GameObject;
        if (numberOfMissile <100)
        {
            missileInstance.GetComponent<Missile>().SetDirection(direction);
            missileInstance.GetComponent<Missile>().SetFlyPath(pathNumber);
            missileInstance.GetComponent<Missile>().StartMove(7.5f, 80f);
        }
        else
        {       
            numberOfMissile = 0;
        }
        
        numberOfMissile++;
        Debug.Log("发射物数量：" + numberOfMissile);
        Debug.Log("退出Fire()");
    }



}

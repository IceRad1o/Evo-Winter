﻿using UnityEngine;
using System.Collections;

public class ItemManagerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(Test());
        ItemManager.Instance.CreateItemType(false,false,true);
        ItemManager.Instance.CreateItemType(true,false,false);
	}

    IEnumerator Test()
    {

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test1：create item");
        ItemManager.Instance.CreateItemType(true);
        Debug.Log("Test1 Over");
    }
}
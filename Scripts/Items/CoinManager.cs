﻿using UnityEngine;
using System.Collections;

public class CoinManager : ExUnitySingleton<CoinManager> {

    public GameObject coinPrefab;

    int wealth;

    public int Wealth
    {
        get { return wealth; }
        set { wealth = value; }
    }




    public bool Buy(int price)
    {
        if (wealth >= price)
        {
            wealth -= price;
            ItemManager.Instance.SendMsg("Coin_Changed;" + wealth);
            return true;
        }

        return false;
    }

    public void GetCoin(int money = 1)
    {
        wealth += money;
    }

    public void CreateCoin(int number, Vector3 pos=default(Vector3))
    {
        Instantiate(coinPrefab, pos,Quaternion.identity);
        
    }


    public void SendMsg(string msg)
    {
        Notify(msg);
    }



}

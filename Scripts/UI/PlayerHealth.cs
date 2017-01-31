using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : UnitySingleton<PlayerHealth>{

    private int health;

    public GameObject[] hearts;
    public int Health
    {
        get { return health; }
        set 
        { 
            if(value<0)
            {
                Debug.Log("Health cannot < 0 !");
                value = 0;
            }
            if(value>10)
            {
                Debug.Log("Health cannot > 10 !");
                value = 10;
            }
            health = value;
            for (int i = 0; i < 10; i++)
            {
                if(i<health)
                    hearts[i].SetActive(true);
                else
                    hearts[i].SetActive(false);
            }
               
        }
    }

	void Start () {
        InitPlayerHealth();
	}
	
	void Update () {
	    
	}

    void InitPlayerHealth()
    {
        for(int i=0;i<3;i++)
        {
            hearts[i].SetActive(true);
        }
        for (int i = 3; i < 10; i++)
        {
            hearts[i].SetActive(false);
        }
    }

}

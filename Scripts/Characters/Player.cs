using UnityEngine;
using System.Collections;
/// <summary>
/// 玩家类,即玩家的操控对象
/// </summary>
public class Player :Character,IFly {

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(Player)) as Player;
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.DontSave;  
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = (Player)obj.AddComponent(typeof(Player));
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this as Player;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    


    void Update()
    {
        base.Update();
       // Debug.Log("这是Player的Update()方法");
    }

    void Start()
    {
        base.Start();
        Health = 3;

        Fly();
    }


    //扩展方法示例
    void Fly()
    {

        this.fly();
    }
}

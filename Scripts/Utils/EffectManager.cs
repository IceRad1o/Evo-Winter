using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {


    private GameObject[] effects;


    /*GetInstance
    *@Brief 获取一个UtilManager实例 
    *@Return UtilManager
    */
    static public EffectManager GetInstance()
    {
        if (instance)
            return instance;
        else
        {
            instance = Instantiate(instance);
            return instance;
        }
    }


    GameObject InstantiateEffect(int effectID)
    {
        GameObject effect = Instantiate(effects[effectID]);
        return effect;
    }


    private static EffectManager instance = null;  //单例

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    
    }

}

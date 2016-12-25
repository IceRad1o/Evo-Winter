using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

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


    void PlayEffect(int effectID)
    {
        //DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

        //itemInstance.Create(1001);

        //StartCoroutine(Test1(itemInstance));
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

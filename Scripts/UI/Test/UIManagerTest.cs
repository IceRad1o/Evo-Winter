using UnityEngine;
using System.Collections;

public class UIManagerTest : MonoBehaviour {


    void Start()
    {
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test1：销毁一次性物品");
        UIManager.GetInstance().DestroyDisposableItem();
        Debug.Log("Test1 Over");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test2：销毁主动物品");
        UIManager.GetInstance().DestroyInitiativeItem();
        Debug.Log("Test2 Over");
    }
}

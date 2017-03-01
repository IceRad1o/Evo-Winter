using UnityEngine;
using System.Collections;

public class UIManagerTest : MonoBehaviour {

    public Sprite testSprite;
    void Start()
    {
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test1：销毁一次性物品");
        UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        Debug.Log("Test1 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test2：销毁主动物品");
        UIManager.Instance.ItemButtonManager.DestroyInitiativeItem();
        Debug.Log("Test2 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test3：改变精华数量");
        UIManager.Instance.EsscencesDisplayer.SetEsscences(1, 4);
        Debug.Log("Test3 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test4：增加血量");
        UIManager.Instance.PlayerHealth.Health = 15;
        Debug.Log("Test4 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test4：减少血量");
        UIManager.Instance.PlayerHealth.Health = 1;
        Debug.Log("Test4 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test5：增加主动道具");
        UIManager.Instance.ItemButtonManager.AddInitiativeItem(testSprite);
        Debug.Log("Test4 Over");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test6：增加一次性道具");
        UIManager.Instance.ItemButtonManager.AddDisposableItem(testSprite);
        Debug.Log("Test6 Over");
    }
}

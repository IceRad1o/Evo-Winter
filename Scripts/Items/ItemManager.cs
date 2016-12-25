using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class ItemManager : MonoBehaviour {
    //一次性道具
    private DisposableItem disposableItem;


    //用来确定道具生成时的道具位置
    public Transform itemsTransform;
    public DisposableItem itemsDisposable;

    /*
     *CreateItem
     *创建一个道具
     */
    public void CreateItem(){
        int itemID=RandomItemID();

        if (itemID == 1001)
        {
            DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(1001);

            StartCoroutine(Test1(itemInstance));
        }
    
    }
    /*AddDisposableItems
     *设置当前拥有的一次性道具，如果已经有道具了，则创建已有道具的实例  
     *item 获得的一次性道具
     */
    public void AddDisposableItems( DisposableItem item) {
        if (disposableItem != null)
        {
            DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(disposableItem.GetID());
        }

        disposableItem = item;
    
    }

    /*GetDisposableItems
     *获得当前拥有的一次性道具      
     */
    public DisposableItem GetDisposableItems() {

        return disposableItem;
    }

    public void DestoryDisposableItems() {
        if (disposableItem != null)
            disposableItem.Destroy();
    }

    //随机产生道具的ID
    private int RandomItemID() {

        return 1001;
    }




    //初始化参数
    void Awake() {

        disposableItem = new DisposableItem();
    
    
    }





	// Use this for initialization
	void Start () {
        StartCoroutine(Test());


	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);

        CreateItem();

    }

    IEnumerator Test1(DisposableItem test)
    {
        yield return new WaitForSeconds(2.0f);
        test.Use();
    }


	// Update is called once per frame
	void Update () {
	    
	}
}

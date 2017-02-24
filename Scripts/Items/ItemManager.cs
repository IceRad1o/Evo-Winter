using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour {
    //一次性道具
    private DisposableItem disposableItem;


    //用来确定道具生成时的道具位置
    public Transform itemsTransform;
    public DisposableItem itemsDisposable;

    //创建ItemsTable的实例
    protected ItemsTable itemsTable = new ItemsTable();

    /*CreateItem
     *@Brief 创建一个道具
     *Param  includeingDis 随机生成的道具中是否含一次性道具
     *Param  includeingImm 随机生成的道具中是否含立即使用道具
     *Param  includeingIni 随机生成的道具中是否含主动道具
     */
    public void CreateItemType(bool includeingDis = false, bool includeingImm = false, bool includeingIni = false)
    {
        int itemID = RandomItemID(itemsTable.GetItemsByType(includeingDis, includeingImm, includeingIni));

        if (itemID == 1001)
        {
            DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(1001);

            StartCoroutine(Test1(itemInstance));
        }
    
    }
    /*CreateItem
    *@Brief 创建一个道具
    *Param  roomDroping 随机生成的道具中是否含房间掉落
    *Param  bossDroping 随机生成的道具中是否含boss掉落
    *Param  boxDroping 随机生成的道具中是否含宝箱掉落
    */
    public void CreateItemDrop(bool roomDroping = false, bool boosDroping = false, bool boxDroping = false)
    {
        //int itemID = RandomItemID();

        if (itemID == 1001)
        {
            DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(1001);

            StartCoroutine(Test1(itemInstance));
        }

    }
    /*AddDisposableItems
     *@Brief 设置当前拥有的一次性道具，如果已经有道具了，则创建已有道具的实例  
     *@Param item 获得的一次性道具
     */
    public void AddDisposableItems( DisposableItem item) {
        if (disposableItem != null)
        {
            DisposableItem itemInstance = Instantiate(itemsDisposable, itemsTransform.position, itemsTransform.rotation) as DisposableItem;

            itemInstance.Create(disposableItem.GetID());
        }

        disposableItem = item;
        //need UIManager.GetInstance().AddDisposableItem(item.itemSprite[itemsTable.GetSpriteID(item.GetID())]);

    
    }

    /*GetDisposableItems
     *@Brief 获得当前拥有的一次性道具      
     */
    public DisposableItem GetDisposableItems() {

        return disposableItem;
    }
    /*DestoryDisposableItems
    *@Brief 销毁当前拥有的一次性道具      
    */
    public void DestoryDisposableItems() {
        if (disposableItem != null)
            disposableItem.Destroy();
    }

   
    
    //随机产生道具的ID
    private int RandomItemID(int[] itemsID) {
        //创建random的实例
        System.Random random = new System.Random();
        return itemsID[random.Next(itemsID.Length)];
    }




    //初始化参数
    void Awake() {

        disposableItem = new DisposableItem();
    
    
    }





	
	void Start () {
        StartCoroutine(Test());


	}
    //TEST
    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);

        CreateItemType(true, false, false);

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

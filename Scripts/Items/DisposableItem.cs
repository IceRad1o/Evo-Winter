using UnityEngine;
using System.Collections;
/// <summary>
/// 一次性道具
/// 一次性道具销毁             DisposableItem_Destroy
/// 道具的使用，Buff、Skill    "UseItem_Buff_ID="+itemBuffID   或   "UseItem_Skill_ID="+itemSkillID
/// </summary>
public class DisposableItem : Item{

    public ItemSprite itemSp;
    private Sprite[] itemSprite;
    public  bool playerIn;
    //public UIElement[] uiList;


    int usingNumber = 1;
    

    /*@SetUsingNumber
     *@Brief 设置一次性道具的使用次数
     *@Param number  将次数设置为number
     */
    void SetUsingNumber(int number)
    {
        usingNumber = number;
    }
    /*@GetUsingNumber
     *@Brief 获得一次性道具的使用次数
     */
    int GetUsingNumber()
    {
        return usingNumber;
    }



    /*@Use
     *@Brief 一次性道具的使用
     *@发送消息，使用道具，并将Skill或Buff的ID发出
     */
    public void Use()
    {
        usingNumber--;


        //发送消息，使用道具，并产生Buff
        if (itemBuffID!=0)
            Notify("UseItem_Buff_ID;"+itemBuffID);
        if (itemSkillID != 0)
            Notify("UseItem_Skill_ID;"+itemSkillID);


        if (usingNumber == 0)
            Destroy();


    }

    /*@Create
     *@设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {

        itemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        spriteRenderer.sprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        itemID = ID;

        ItemManager.Instance.listDisposableItem.Add(this);
    }

    /*@Destroy
     *@Brief 销毁该实例
     */
    public void Destroy()
    {
        ItemManager.Instance.listDisposableItem.Remove(this);
        //发送消息，一次性道具销毁
        Notify("DisposableItem_Destroy");

        Destroy(gameObject);    
    }



    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            Notify("Player_Get_DisposableItem;" + itemID);
          
            playerIn = true;
        }
       
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Notify("Player_Leave_DisposableItem");
            playerIn = false;
        }
    }
    /// <summary>
    /// 发送消息，道具已被拾取
    /// </summary>
    public void PlayerGet()
    {
        Notify("Get_DisposableItem;" + itemID);

    }
    // Use this for initialization
    void Awake()
    {
        playerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //获取图片数组
        //itemSprite = itemSp.SpriteArray;
        itemSprite = ItemManager.Instance.itemSprite.SpriteArray;
    }


    
}

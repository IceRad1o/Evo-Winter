﻿using UnityEngine;
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

    public int UsingNumber
    {
        get { return usingNumber; }
        set { usingNumber = value; }
    }
    

   



    /*@Use
     *@Brief 一次性道具的使用
     *@发送消息，使用道具，并将Skill或Buff的ID发出
     */
    public string Use()
    {
        usingNumber--;

        Debug.Log("UseItem_Buff_ID" + ItemBuffID);

        if (usingNumber <= 0)
            DestroyScript();

        if (ItemBuffID != 0)
            return "UseItem_Buff_ID;" + ItemBuffID;
        if (itemSkillID != 0)
            return "UseItem_Skill_ID;" + itemSkillID;

        

        return "Error";
    }

    /*@Create
     *@设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {

        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        iSprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        spriteRenderer.sprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemID = ID;

        ItemManager.Instance.listDisposableItem.Add(this);
        this.AddObserver(ItemManager.Instance.ItemObs);
        this.AddObserver(UIManager.Instance.ItemObserver);
    }

    public void CreateScript(int ID)
    {
        iSprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        ItemID = ID;
    }
    /*@Destroy
     *@Brief 销毁该实例
     */
    public void DestroyDisposableItem()
    {

        ItemManager.Instance.listDisposableItem.Remove(this);
        //发送消息，一次性道具销毁
       
        if (this.gameObject)
            Destroy(gameObject); 
        else
            Destroy(this);
    }

    public override void DestroyScript()
    {
        Notify("DisposableItem_Destroy");
        UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        Debug.Log("Des");
        base.DestroyScript();
        
    }


    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {
            Notify("Player_Get_DisposableItem;" + ItemID);
          
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
        Notify("Get_DisposableItem;" + ItemID);

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

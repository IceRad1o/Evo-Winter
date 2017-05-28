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

    public override void Create(int ID)
    {
 	    base.Create(ID);
        CreateScript(ID);
        spriteRenderer.sprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];

        ItemManager.Instance.listDisposableItem.Add(this);
    }
 
    public void CreateScript(int ID)
    {
        //ItemName=
        iSprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        ItemBuffID_Advance = ItemManager.Instance.itemsTable.GetItemBuffID_Advance(ID);
        ItemSkillID_Advance = ItemManager.Instance.itemsTable.GetItemSkillID_Advanced(ID);
        ItemID = ID;
    }
    /// <summary>
    /// 销毁实例
    /// </summary>
    public override void Destroy()
    {
        ItemManager.Instance.listDisposableItem.Remove(this);

        this.RemoveObserver(ItemManager.Instance);
        this.RemoveObserver(UIManager.Instance.ItemObserver);

        base.Destroy();
    }

    public override void DestroyScript()
    {
        ItemManager.Instance.SendMsg("DisposableItem_Destroy");
        UIManager.Instance.ItemButtonManager.DestroyDisposableItem();
        base.DestroyScript();
        
    }


    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            Notify("Player_Get_DisposableItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Get_DisposableItem;" + ItemID);
            PlayerIn = true;
        }
       
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Notify("Player_Leave_DisposableItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Leave_DisposableItem;" + ItemID);
            PlayerIn = false;
        }
    }
    // Use this for initialization
    public override void Awake()
    {
        base.Awake();
        PlayerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //获取图片数组
        //itemSprite = itemSp.SpriteArray;
        itemSprite = ItemManager.Instance.itemSprite.SpriteArray;
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
    }
    
}

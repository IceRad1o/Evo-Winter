using UnityEngine;
using System.Collections;

public class ImmediatelyItem : Item{


    public ItemSprite itemSp;
    private Sprite[] itemSprite;
    public  bool playerIn;
    //public AudioClip[] itemSounds;



    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {


            Notify("Player_Get_ImmediatelyItem;" + ItemID);
            playerIn = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player"){

            Notify("Player_Leave_ImmediatelyItem");
            playerIn = false;
        }
    }
    
    /*@Use
     *@Brief 一次性道具的使用
     *@Return ：Buff 道具增加的buff，如果道具是使用skill，则返回null
     */
    public void Use()
    {
        //发送消息，使用道具，并产生Buff
        if (ItemBuffID != 0)
            ItemManager.Instance.SendMsg("UseItem_Buff_ID;" + ItemBuffID);
        if (itemSkillID != 0)
            ItemManager.Instance.SendMsg("UseItem_Skill_ID;" + itemSkillID);

        Destroy(gameObject);
    }


    //need Buff,Skill
    /*@Create
     *@Brief 设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);

        spriteRenderer.sprite = itemSprite[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemID = ID;

        ItemManager.Instance.listImmediatelyItem.Add(this);
        this.AddObserver(ItemManager.Instance);
        this.AddObserver(UIManager.Instance.ItemObserver);

    }


    void Awake()
    {
        playerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemSprite = ItemManager.Instance.itemSprite.SpriteArray;
    }

    
}

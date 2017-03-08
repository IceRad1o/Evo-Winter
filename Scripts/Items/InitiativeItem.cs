using UnityEngine;
using System.Collections;

public class InitiativeItem : Item{


    private int energyMax;
    private bool playerIn;
    public bool PlayerIn
    {
        get { return playerIn; }
        set { playerIn = value; }
    }
    private int energyNow;
    public int EnergyNow
    {
        get { return energyNow; }
        set { energyNow = value; if (energyNow > energyMax) energyNow = energyMax; Notify("InitiativeItem_Energy_Number;"+energyNow); }
    }

    public ItemSprite itemSp;
    private Sprite[] itemSprite;

    /*@Create
     *@设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {
         
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        energyMax = ItemManager.Instance.itemsTable.GetItemEnergy(ID);
        energyNow = energyMax;
        spriteRenderer.sprite = itemSprite[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemID = ID;

    }

    /*@Destroy
     *@Brief 销毁该实例
     */
    public void Destroy()
    {
        //发送消息，一次性道具销毁
        Notify("InitiativeItem_Destroy");
        
        Destroy(gameObject);
    }

    public void Use() {
        if (energyNow < energyMax)
        {
            Notify("InitiativeItem_Energy_NotFull");
            return;
        }
        //发送消息，使用道具，并产生Buff
        if (ItemBuffID != 0)
            Notify("UseItem_Buff_ID;" + ItemBuffID);
        if (itemSkillID != 0)
            Notify("UseItem_Skill_ID;" + itemSkillID);

        energyNow = 0;
        Notify("InitiativeItem_Energy_Number;" + energyNow);
    }


    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Notify("Player_Get_InitiativeItem;" + ItemID);
            playerIn = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
        }
    }
    /// <summary>
    /// 发送消息，道具已被拾取
    /// </summary>
    public void PlayerGet()
    {
        Notify("Get_InitiativeItem;" + ItemID);
    
    }



    void Awake()
    {
        playerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemSprite = itemSp.SpriteArray;
    }
}

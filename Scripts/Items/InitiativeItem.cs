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
        set { energyNow = value; if (energyNow > energyMax) energyNow = energyMax; ItemManager.Instance.SendMsg("InitiativeItem_Energy_Number;"+(energyMax==0?100:energyNow*100/energyMax)); }
    }

    public ItemSprite itemSp;
    private Sprite[] itemSprite;

    /*@Create
     *@设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {
        RoomElementID = ID;
        CreateScript(ID);
        spriteRenderer.sprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];

        ItemManager.Instance.listInitiativeItem.Add(this);
        this.AddObserver(ItemManager.Instance);
        this.AddObserver(UIManager.Instance.ItemObserver);

    }

    public void CreateScript(int ID)
    {
        iSprite = ItemManager.Instance.itemSprite.SpriteArray[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        energyMax = ItemManager.Instance.itemsTable.GetItemEnergy(ID);
        energyNow = energyMax;
        ItemID = ID;
    }

    /*@Destroy
     *@Brief 销毁该实例
     */
    public void Destroy()
    {
        ItemManager.Instance.listInitiativeItem.Remove(this);
        
        Destroy(gameObject);
    }

    public override void DestroyScript()
    {
        //发送消息，一次性道具销毁
        ItemManager.Instance.SendMsg("InitiativeItem_Destroy");

        base.DestroyScript();
    }

    public void Use() {
        if (energyNow < energyMax)
        {
            ItemManager.Instance.SendMsg("InitiativeItem_Energy_NotFull");
            return;
        }
        //发送消息，使用道具，并产生Buff
        if (ItemBuffID != 0)
            ItemManager.Instance.SendMsg("UseItem_Buff_ID;" + ItemBuffID);
        if (itemSkillID != 0)
            ItemManager.Instance.SendMsg("UseItem_Skill_ID;" + itemSkillID);

        EnergyNow = 0;
        //ItemManager.Instance.SendMsg("InitiativeItem_Energy_Number;" + energyNow);
    }



    /*************************************************************/
    /// <summary>
    /// 2D碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Notify("Player_Get_InitiativeItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Get_InitiativeItem;" + ItemID);

            playerIn = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Notify("Player_Leave_InitiativeItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Leave_InitiativeItem;" + ItemID);

            playerIn = false;
        }
    }



    void Awake()
    {
        playerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemSprite = ItemManager.Instance.itemSprite.SpriteArray;
    }
}

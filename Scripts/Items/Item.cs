using UnityEngine;
using System.Collections;

public class Item : RoomElement {

    protected Sprite iSprite;
    private bool playerIn;
    public bool PlayerIn
    {
        get { return playerIn; }
        set { playerIn = value; }
    }
    private int itemID;
    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    private int itemBuffID;
    public int ItemBuffID
    {
        get { return itemBuffID; }
        set { itemBuffID = value; }
    }
    protected int itemSkillID;
    protected SpriteRenderer spriteRenderer;
    public AudioClip usingSounds;

    private string itemName;
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    private string itemIntro;
    public string ItemIntro
    {
        get { return itemIntro; }
        set { itemIntro = value; }
    }

    private int value = 0;
    public int Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    private int itemBuffID_Advance = 0;
    public int ItemBuffID_Advance
    {
        get { return itemBuffID_Advance; }
        set { itemBuffID_Advance = value; }
    }


    private int itemSkillID_Advance = 0;
    public int ItemSkillID_Advance
    {
        get { return itemSkillID_Advance; }
        set { itemSkillID_Advance = value; }
    }


    /*@GetID
     *@Brief 获得道具的ID
     *@Return  道具的ID
     */
    public int GetID()
    {
        return itemID;
    }
    /*@GetID
     *@Brief 设置道具的ID
     */
    public void SetID(int ID)
    {
        itemID = ID;
    }

    virtual public void Create(int ID)
    {
        ItemID = ID;
        RoomElementID = ID;
        ItemBuffID = ItemManager.Instance.itemsTable.GetItemBuffID(ID);
        itemSkillID = ItemManager.Instance.itemsTable.GetItemSkillID(ID);
        ItemBuffID_Advance = ItemManager.Instance.itemsTable.GetItemBuffID_Advance(ID);
        itemSkillID_Advance = ItemManager.Instance.itemsTable.GetItemSkillID_Advanced(ID);
        this.AddObserver(ItemManager.Instance);
        this.AddObserver(UIManager.Instance.ItemObserver);
    }

    virtual public void DestroyScript() {

        this.itemID=0;
    }

    public Sprite GetSprite() {
        if (iSprite == null)
            Debug.Log("No Sprite");
        return iSprite;
    }
    public override void Destroy()
    {
        PlayerIn = false;
        base.Destroy();
    }

    public override void Awake()
    {
        base.Awake();
        roomElementID = 1000;
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "Price")
        {
            this.Value = int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0));
        }
    }
}

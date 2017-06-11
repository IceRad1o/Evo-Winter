using UnityEngine;
using System.Collections;




public class Item : RoomElement {

    private ItemsTable.ItemData data;
    public ItemsTable.ItemData Data
    {
        get { return data; }
        set { data = value; }
    }

    private bool playerIn=false;
    protected bool canGet = false;
    bool needBuy = false;
    public bool PlayerIn
    {
        get { return playerIn; }
        set { playerIn = value; }
    }

    protected Sprite iSprite;
  
  
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

    private int price=0;
    public int Price
    {
        get { return price; }
        set { price = value; }
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

    public bool NeedBuy
    {
        get
        {
            return needBuy;
        }

        set
        {
            needBuy = value;
        }
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
        CreateScript(ID); ;
        this.AddObserver(ItemManager.Instance);
        this.AddObserver(UIManager.Instance.ItemObserver);
    }
    public virtual void CreateScript(int ID)
    {
        ItemID = ID;
        RoomElementID = ID;
        Data = ItemsTable.Instance.FindItemsByID(ID);
        ItemBuffID = Data.buffID;
        itemSkillID = Data.skillID;
        ItemBuffID_Advance = Data.buffID_advanced;
        itemSkillID_Advance = Data.skillID_advanced;
        Price = Data.price;
        if(spriteRenderer)
             spriteRenderer.sprite = Data.sprite;
    }
    virtual public void DestroyScript() {

        this.itemID=0;
    }

    public Sprite GetSprite() {
        return Data.sprite;
        //if (iSprite == null)
        //    Debug.Log("No Sprite");
        //return iSprite;
    }
    public override void Destroy()
    {
        PlayerIn = false;
        base.Destroy();
    }

    public override void Awake()
    {
        base.Awake();
        PlayerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        roomElementID = 1000;

    }

    void Start()
    {
        StartCoroutine(CanBeGot());
    }

    IEnumerator CanBeGot()
    {
        yield return new WaitForSeconds(0.5f);
        canGet = true;
    }
    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);

        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "Price")
        {
            this.Price = int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0));
        }
    }

    public virtual void Use()
    {
        for (int i = 0; i < data.trims.Length; i++)
        {
            Player.Instance.GetComponent<CharacterSkin>().AddDecoration(data.trims[i].decoration, data.trims[i].parentNode);
        }

    }

    public virtual void PickUp()
    {
        if(!NeedBuy)
            SoundManager.Instance.PlaySoundEffect(ItemsTable.Instance.pickUpSounds[(int)Data.pickUpSound]);
        else
            SoundManager.Instance.PlaySoundEffect(ItemsTable.Instance.pickUpSounds[(int)ItemPickUpSound.Trade]);
        Destroy();
    }

}

using UnityEngine;
using System.Collections;

public class ImmediatelyItem : Item{


    public ItemSprite itemSp;
    private Sprite[] itemSprite;
    
    //public AudioClip[] itemSounds;



    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {


            Notify("Player_Get_ImmediatelyItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Get_ImmediatelyItem;" + ItemID);

            PlayerIn = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){

            Notify("Player_Leave_ImmediatelyItem;" + ItemID);
            ItemManager.Instance.SendMsg("Player_Leave_ImmediatelyItem;" + ItemID);

            PlayerIn = false;
        }
    }
    
    /*@Use
     *@Brief 一次性道具的使用
     *@Return ：Buff 道具增加的buff，如果道具是使用skill，则返回null
     */
    public void Use()
    {

        if (ItemID >= 1500)
        {
            ItemManager.Instance.SendMsg("Item_Advance;" + (ItemID - 1500));
            ItemManager.Instance.advancedItem[(ItemID - 1500)] = 1;
        }
        else
        {
            //发送消息，使用道具，并产生Buff
            if (ItemBuffID != 0)
                ItemManager.Instance.SendMsg("UseItem_Buff_ID;" + ItemBuffID);
            if (itemSkillID != 0)
                ItemManager.Instance.SendMsg("UseItem_Skill_ID;" + itemSkillID);

            //判断是否已经进阶
            if (ItemManager.Instance.advancedItem[(ItemID - 1000)] == 1)
            {
                //发送消息，使用道具，并产生Buff
                if (ItemBuffID_Advance != 0)
                    ItemManager.Instance.SendMsg("UseItem_Buff_ID;" + ItemBuffID_Advance);
                if (ItemSkillID_Advance != 0)
                    ItemManager.Instance.SendMsg("UseItem_Skill_ID;" + ItemSkillID_Advance);
            }

        }
        ItemManager.Instance.listImmediatelyItem.Remove(this);
        this.Destroy();
    }


    public override void Create(int ID)
    {
 	    base.Create(ID);
        spriteRenderer.sprite = itemSprite[ItemManager.Instance.itemsTable.GetSpriteID(ID)];
        
        ItemManager.Instance.listImmediatelyItem.Add(this);
        
    } 

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Awake()
    {
        base.Awake();
        PlayerIn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemSprite = ItemManager.Instance.itemSprite.SpriteArray;
    }

    
}

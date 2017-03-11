using UnityEngine;
using System.Collections;

public class Item : ExSubject {

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
    public AudioClip usingSounds;

  


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

    virtual public void DestroyScript() {

        this.itemID=0;
    }

    public Sprite GetSprite() {
        if (iSprite == null)
            Debug.Log("No Sprite");
        return iSprite;
    }

    virtual public void DestoryItem() {
        Destroy(gameObject);    
    }
}

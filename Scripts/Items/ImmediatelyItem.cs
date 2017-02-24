using UnityEngine;
using System.Collections;

public class ImmediatelyItem : Item{

    class Buff { }

    public Sprite[] itemSprite;
    //public AudioClip[] itemSounds;

    //need Buff,Skill
    Buff buff;
    
    
    
    
    //need Buff,Skill
    /*@Use
     *@Brief 一次性道具的使用
     *@Return ：Buff 道具增加的buff，如果道具是使用skill，则返回null
     */
    public void Use()
    {
        Destroy();
        //return buff;
    }


    //need Buff,Skill
    /*@Create
     *@Brief 设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {

        //buff = new Buff();
        buff = null;
        spriteRenderer.sprite = itemSprite[itemsTable.GetSpriteID(ID)];
        itemID = ID;

    }


    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}

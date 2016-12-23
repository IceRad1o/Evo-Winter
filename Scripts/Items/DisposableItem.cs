using UnityEngine;
using System.Collections;

public class DisposableItem : Item{

    class Buff { }

    public Sprite[] itemSprite;
    //public UIElement[] uiList;


    Buff buff;
    int usingNumber = 1;

    /*@SetUsingNumber
     *@设置一次性道具的使用次数
     *@number  将次数设置为number
     */
    void SetUsingNumber(int number)
    {
        usingNumber = number;
    }
    /*@GetUsingNumber
     *@获得一次性道具的使用次数
     */
    int GetUsingNumber()
    {

        return usingNumber;
    }


    //need Buff,Skill
    /*@Use
     *@一次性道具的使用
     *@返回：Buff 道具增加的buff，如果道具是使用skill，则返回null
     */
    public void Use()
    {
        usingNumber--;

        if (usingNumber == 0)
            Destroy();

        //return buff;
    }

    //need Buff,Skill
    /*@Create
     *@设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public void Create(int ID)
    {

        //buff = new Buff();
        buff = null;
        spriteRenderer.sprite = itemSprite[0];
        itemID = ID;

    }

    /*@Destroy
     *@销毁该实例
     */
    public void Destroy()
    {
        Destroy(gameObject);    
    }


    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
}

using UnityEngine;
using System.Collections;

public class Item : Subject {

    protected int itemID;
    protected int itemBuffID;
    protected int itemSkillID;
    protected SpriteRenderer spriteRenderer;
    public AudioClip usingSounds;

   


    /*@Destroy
     *@Brief 虚函数，用来销毁道具
     */
    public virtual void Destroy()
    {

    }
    /*@Create
     *@Brief 虚函数，设置该道具的一些相关属性
     *@ID 该道具的ID
     */
    public virtual void Create(int ID)
    {
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

}

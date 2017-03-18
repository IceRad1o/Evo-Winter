using UnityEngine;
using System.Collections;

public class BuffCreateItem : Buff {


    public void Trigger()
    {
        ItemManager.Instance.CreateItemType(true, true, true);       

        this.DestroyBuff();
    }



    public void Create(int ID)
    {
 
        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        Trigger();
    }


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   


}

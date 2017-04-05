using UnityEngine;
using System.Collections;

public class BuffCreateItem : Buff {

    

    public void Trigger(int ID)
    {
        if (ID==102)
            ItemManager.Instance.CreateItemType(true, true, true);
        if (ID == 202)
        {
            EsscenceManager.Instance.CreateEsscence();

            GameObject pfb = Resources.Load("Buffs/devil") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            GameObject prefabInstance = Instantiate(pfb);
            prefabInstance.transform.position = s;
            prefabInstance.transform.parent = this.gameObject.transform;
        }
        if (ID == 302)
        {
            EsscenceManager.Instance.ChangeTwoEsscence();
            

            GameObject pfb = Resources.Load("Buffs/devil") as GameObject;
            Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
            GameObject prefabInstance = Instantiate(pfb);
            prefabInstance.transform.position = s;
            prefabInstance.transform.parent = this.gameObject.transform;
        }



        this.DestroyBuff();
    }



    public void Create(int ID)
    {
 
        this.gameObject.GetComponent<BuffManager>().BuffList.Add(this);
        Trigger(ID);
    }


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   


}

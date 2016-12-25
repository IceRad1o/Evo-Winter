using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    protected int itemID;
    public AudioClip usingSounds;

    protected SpriteRenderer spriteRenderer;

    public virtual void Destroy()
    {

    }

    public virtual void Create(int ID)
    {
    }

    public int GetID()
    {

        return itemID;
    }

    public void SetID(int ID)
    {
        itemID = ID;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

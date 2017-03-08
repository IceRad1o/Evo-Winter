using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{

    private Animator animator;
    private bool isOpen;
    //NEED public AudioClip getBox;
    //NEED public AudioClip openBox;
    void Awake()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
        //NEED SoundManager.instance.PlaySingle(getBox);
    }

    void Update()
    {
       
    }

    public void OpenBox()
    {
        //打开宝箱的动画和声音
        animator.SetTrigger("OpenBox");
        isOpen = true;
        //NEED SoundManager.instance.PlaySingle(openBox);   
        //NEED Item item=ItemManager.getInstance().GenerateItem();
        //item.transfrom.setParent(this.transform);
        
        ItemManager.Instance.ItemsTransform = this.transform;
        
        ItemManager.Instance.CreateItemDrop(false, false, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("箱子碰撞物标签：" + other.tag);
        if (other.tag == "Weapon")
            if (other.GetComponentInParent<Character>().IsWeaponDmg>0&&isOpen==false&& other.GetComponentInParent<Character>().Camp==0)
            {
                OpenBox();
            }
    }
}

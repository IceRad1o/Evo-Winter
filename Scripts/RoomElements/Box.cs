using UnityEngine;
using System.Collections;

public class Box : RoomElement
{
    private Animator animator;
    //NEED public AudioClip getBox;
    public AudioClip openBox;
    void Start()
    {
        animator = GetComponent<Animator>();
        //NEED SoundManager.instance.PlaySingle(getBox);
    }

    public override void Awake()
    {
        base.Awake();
        RoomElementID = 1;
        this.tag = "DynamicGroundElement";
    }
    void Update()
    {
       
    }
	//打开宝箱
    public void OpenBox()
    {
        //打开宝箱的动画和声音
        animator.SetTrigger("OpenBox");
		RoomElementState = 1;
        SoundManager.Instance.PlaySoundEffect(openBox);
        //NEED Item item=ItemManager.getInstance().GenerateItem();
        //item.transfrom.setParent(this.transform);

        if (Random.value * 100 < 20)
            EsscenceManager.Instance.CreateEsscence((int)(Random.value * 4), this.transform.position);
        else
        {
           // ItemManager.Instance.ItemsTransform = new Transform();
            ItemManager.Instance.CreateItemDrop(false, false, true, this.transform.position + new Vector3(0, 1, 0));

        }
    }

	//宝箱碰撞检测
	private void OnCollisionEnter(Collision collision)
    {
		//Debug.Log("箱子碰撞物标签：" + collision.gameObject.tag);
		//Debug.Log ("BottleTagState:"+this.RoomElementState);
		if (RoomElementState == 1)
			return;
		if (collision.gameObject.CompareTag("Player"))
		{
			Player.Instance.Character.AddObserver(this);
			RoomManager.Instance.Notify("EnterBox");
		}
    }
	void OnCollisionExit(Collision collision)
	{
		//Debug.Log("箱子看离开标签：" + collision.gameObject.tag);
		if (collision.gameObject.CompareTag("Player"))
		{
			RoomManager.Instance.Notify("LeaveBox");
			Player.Instance.Character.RemoveObserver(this);
		}
	}
	//函数重载
	public override void Trriger()
	{
		if (RoomElementState == 1)
			return;
			
		base.Trriger();
		OpenBox ();
		RoomElementState = 1;
		Notify("OpenBox");
	}
}

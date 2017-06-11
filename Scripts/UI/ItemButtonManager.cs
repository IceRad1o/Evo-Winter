using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Author YYF
/// 管理2个使用道具按钮
/// </summary>
public class ItemButtonManager : UnitySingleton<ItemButtonManager>{

    float curEnergy;

 

    /*DestroyDisposableItem
     *@Brief 销毁UI上的一次性道具
     */
    public void DestroyDisposableItem()
    {
        disposableItemImg.GetComponent<Image>().sprite = defaultItem;
    }

    /*DestroyInitiativeItem
     *@Brief 销毁UI上的主动道具
     */
    public void DestroyInitiativeItem()
    {
        initiativeItemImg.GetComponent<Image>().sprite = defaultItem;
    }

    /*AddInitiativeItem
     *@Brief 增加主动道具到UI
     *@Param Sprite item 道具图片
     */

    public void AddInitiativeItem(Sprite item, Vector3 position, bool isDelay = true)
    {
       
              initiativeItemImg.GetComponent<Image>().sprite = item;
        if (isDelay)
        {
            Vector3 pos = CameraController.Instance.GetComponent<Camera>().WorldToScreenPoint(position);
            var dest = initiativeItemImg.transform.position;
            initiativeItemImg.transform.position = pos;
            iTween.MoveTo(initiativeItemImg, iTween.Hash("x", dest.x, "y", dest.y, "z", dest.z, "time", 0.5f, "easeType", iTween.EaseType.easeInQuad));

        }
    }

    /*AddDisposableItem
     *@Brief 增加一次性道具到UI
     *@Param Sprite item 道具图片
     */
    public void AddDisposableItem(Sprite item,Vector3 position,bool isDelay=true )
    {
        
             disposableItemImg.GetComponent<Image>().sprite = item;
         if (isDelay)
        {
            Vector3 pos = CameraController.Instance.GetComponent<Camera>().WorldToScreenPoint(position);
            var dest=disposableItemImg.transform.position;
            disposableItemImg.transform.position = pos;
            iTween.MoveTo(disposableItemImg, iTween.Hash("x", dest.x, "y", dest.y, "z", dest.z, "time", 0.5f, "easeType", iTween.EaseType.easeInQuad));

        }
    }

    /*OnInitiativeItem
     *@Brief 触发使用主动道具
     */
    public void OnInitiativeItem()
    {
        Debug.Log("s使用主动道具");
        ItemManager.Instance.UseInitiativeItem();
  
        //NEED ItemManager.GetInstance().UseInitiativeItems();

    }

    /*OnDisposableItem
     *@Brief 触发使用一次性道具
     */
    public void OnDisposableItem()
    {
        Debug.Log("s使用一次性道具");
        ItemManager.Instance.UseDisposableItems();

    }

    public void SetEnergy(float value)
    {
        float temp = value ;
        int delta = 100 * (int)(temp - curEnergy);
        curEnergy = temp;
        fillImg.GetComponent<Image>().fillAmount = value;
        if (value == 1)
        {
            if(initiativeItemButton.gameObject.GetComponent<ScaleBy>()==null)
            {
                ScaleBy s = initiativeItemButton.gameObject.AddComponent<ScaleBy>();
                s.Init(1f, new Vector3(0.2f, 0.2f, 0.2f), true, true, true);
            }

        }
        else if (initiativeItemButton.GetComponent<ScaleBy>() != null)
            initiativeItemButton.GetComponent<ScaleBy>().isLoop = false;

    }


    public Button initiativeItemButton; //主动道具按钮
    public Button disposableItemButton; //一次性道具按钮
    private GameObject initiativeItemImg;   //主动道具图片
    private GameObject disposableItemImg;   //一次性道具图片
    public GameObject fillImg;
    public Sprite defaultItem;  //缺省道具图片

	void Start () {
        curEnergy = 0;
        initControlButton();
	}
	

	void Update () {
	
	}

    //初始化控制按钮
    void initControlButton()
    {
        //TODO 根据首选项初始化位置大小等
        Button initiativeItemBtn = initiativeItemButton.GetComponent<Button>();
        initiativeItemBtn.onClick.AddListener(OnInitiativeItem);

        Button disposableItemBtn = disposableItemButton.GetComponent<Button>();
        disposableItemBtn.onClick.AddListener(OnDisposableItem);

        initiativeItemImg = initiativeItemButton.transform.FindChild("Image").gameObject;
        disposableItemImg = disposableItemButton.transform.FindChild("Image").gameObject;

    }



}

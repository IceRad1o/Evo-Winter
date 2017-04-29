using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 负责UI弹幕的显示
/// </summary>
public class Popup : UnitySingleton<Popup> {


    public GameObject itemDetailPopup;
    GameObject itemDetailPopupTitle;
    GameObject itemDetailPopupText;
    GameObject itemDetailPopupType;
    GameObject itemDetailPopupQuality;


    public GameObject esscencePopup;
    GameObject esscencePopupSprite;
    GameObject esscencePopupName;
    GameObject esscencePopupDescribe;


	// Use this for initialization
	void Start () {
        itemDetailPopupTitle = itemDetailPopup.GetComponent<RectTransform>().Find("Title").gameObject;
        itemDetailPopupText= itemDetailPopup.GetComponent<RectTransform>().Find("Text").gameObject;
        itemDetailPopupType= itemDetailPopup.GetComponent<RectTransform>().Find("Type").gameObject;
        itemDetailPopupQuality = itemDetailPopup.GetComponent<RectTransform>().Find("Quality").gameObject;


        esscencePopupSprite = esscencePopup.GetComponent<RectTransform>().Find("Image").gameObject;
        esscencePopupName= esscencePopup.GetComponent<RectTransform>().Find("Title").gameObject;
        esscencePopupDescribe = esscencePopup.GetComponent<RectTransform>().Find("Text").gameObject;
	}



    public void SetItemDetailPopup(string itemName,string itemIntro,int itemType,string itemQuality)
    {
       
        //D级 灰色 C级绿色 B级蓝色 A级紫色 S级 橙色 S+级 红色 6级
        string[] colorStr = new string[6] { "color=grey", "color=lime", "color=cyan", "color=#FF00FFFF", "color=orange", "color=red" };
        string []typeStr=new string[4]{"被动道具","消耗品","主动道具","欲望精华"};
        int quality=0;
        if (itemQuality == "D")
            quality = 0;
        else if (itemQuality == "C")
            quality = 1;
        else if (itemQuality == "B")
            quality = 2;
        else if (itemQuality == "A")
            quality = 3;
        else if (itemQuality == "S")
            quality = 4;
        else if (itemQuality == "S+")
            quality = 5;
        itemDetailPopupTitle.GetComponent<Text>().text ="<"+colorStr[quality]+">"+ itemName+"</color>";

        itemDetailPopupText.GetComponent<Text>().text = itemIntro;
        itemDetailPopupType.GetComponent<Text>().text = ""+typeStr[itemType];
        itemDetailPopupQuality.GetComponent<Text>().text = "" + itemQuality;
    }

    public void ShowEsscencePopup(Sprite sp,string name,string desc)
    {
        esscencePopup.SetActive(true);
        esscencePopupSprite.GetComponent<Image>().sprite = sp;
        esscencePopupName.GetComponent<Text>().text = name;
        esscencePopupDescribe.GetComponent<Text>().text = desc;

        FadeIn a=esscencePopup.AddComponent<FadeIn>();
        a.isReverse = true;
        a.isReset = true;
        a.isOnCanvas = true;
        a.resetToZero = true;
        a.isReverseDelay = true;
        a.reverseDelayTime = 2f;
        a.destValue.x = 1;
    }


}

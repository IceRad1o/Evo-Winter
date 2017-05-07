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

    /*恶魔祭坛：
"CloseAltar;1;"+attribute1+";"+change1+";"+attribute2+";"+change2
1：祭坛种类
attribute1：增益属性（int 1~7）
change1：增益数值（int 1~3）
attribute1：减益属性（int 1~7）
change1：减益数值（int -1~ -3）

天使祭坛：
"CloseAltar;1;"+attribute+";"+increase
2：祭坛种类
attribute：增益属性（int 1~7）
increace：增益数值（int 1~3）*/
    public void SetAltarPopup(int type, int attri1, int value1, int attri2,int value2)
    {
        string[] attris = new string[7] { "HP", "ATK", "SPD", "RNG", "MOV", "FHR","LUK" }; 
        if (type == 1)
        {
            itemDetailPopupTitle.GetComponent<Text>().text = "恶魔祭坛";
            itemDetailPopupText.GetComponent<Text>().text = "这是一座恶魔祭坛.献祭将在短时间内会获得" + attris[attri1 - 1] + "+ " + value1 + "的强力加成,但随后" + attris[attri2 - 1] + value2;
        }
        else
        {
            itemDetailPopupTitle.GetComponent<Text>().text = "普通祭坛";
            itemDetailPopupText.GetComponent<Text>().text = "这是一座普通的祭坛.献祭将在短时间内会获得" + attris[attri1 - 1] + "+ " + value1 + "的加成.";
        } 

      

        itemDetailPopupType.GetComponent<Text>().text = "" ;
      //  itemDetailPopupQuality.GetComponent<Text>().text = "" + itemQuality;
    }

}

using UnityEngine;
using System.Collections;
/// <summary>
/// 负责UI弹幕的显示
/// </summary>
public class Popup : UnitySingleton<Popup> {


    public GameObject itemDetailPopup;
    GameObject itemDetailPopupTitle;
    GameObject itemDetailPopupText;

	// Use this for initialization
	void Start () {
        itemDetailPopupTitle = itemDetailPopup.GetComponent<RectTransform>().Find("Title").gameObject;
        itemDetailPopupText= itemDetailPopup.GetComponent<RectTransform>().Find("Text").gameObject;
	}



    void SetItemDetailPopup(string itemName,string itemIntro)
    {
        itemDetailPopupTitle
    }
}

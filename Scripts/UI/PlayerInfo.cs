using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 玩家详细信息模块
/// </summary>
public class PlayerInfo : ExUnitySingleton<PlayerInfo> {

    public GameObject backBtn;
    public AudioClip sound;
    /// <summary>
    /// 展示玩家详细信息
    /// </summary>
    public void Display()
    {
        gameObject.SetActive(true);
        AttriInfo.Instance.GetComponent<RectTransform>().localPosition = new Vector3(193.5f, 121, 0);
        EsscenceInfoManager.Instance.GetComponent<RectTransform>().localPosition = new Vector3(193.5f, -192, 0);
        DialogInfo.Instance.GetComponent<RectTransform>().localPosition = new Vector3(-412, -192, 0);
        CreerInfo.Instance.GetComponent<RectTransform>().localPosition = new Vector3(-481.5f, 115, 0);
        backBtn.GetComponent<RectTransform>().localPosition = new Vector3(-546, 314, 0);
        Hashtable args = new Hashtable();
        args.Add("time", 0.25f);//设置动画实现消耗时间   time 一定不要写错
        args.Add("easeType", iTween.EaseType.easeInQuad);
        args.Add("x", 1450);
        args.Add("y", 0);
        args.Add("z", 0);
   
        //args.Add("delay", 0.5f);
        iTween.MoveBy(AttriInfo.Instance.gameObject , args);

        args.Remove("delay");
        args.Add("delay", 0.18f);
        iTween.MoveBy(EsscenceInfoManager.Instance.gameObject, args);
        args.Remove("delay");
        args.Add("delay", 0.35f);
        iTween.MoveBy(CreerInfo.Instance.gameObject, args);
        args.Remove("delay");
        args.Add("delay", 0.45f);
        iTween.MoveBy(DialogInfo.Instance.gameObject, args);

        args.Remove("delay");
        args.Add("delay", 0.52f);
        iTween.MoveBy(backBtn, args);


        SoundManager.Instance.PlaySoundEffect(sound);
    }

    /// <summary>
    /// 隐藏玩家详细信息
    /// </summary>
    public void Undisplay()
    {
       

        Hashtable args = new Hashtable();
        args.Add("time", 0.1f);//设置动画实现消耗时间   time 一定不要写错
        args.Add("easeType", iTween.EaseType.easeInQuad);
        args.Add("x", 1450);
        args.Add("y", 0);
        args.Add("z", 0);
        //args.Add("delay", 0.5f);
        iTween.MoveBy(AttriInfo.Instance.gameObject, args);

        args.Remove("delay");
        args.Add("delay", 0.1f);
        iTween.MoveBy(EsscenceInfoManager.Instance.gameObject, args);


        iTween.MoveBy(DialogInfo.Instance.gameObject, args);

        args.Remove("x");
        args.Add("x", -1450);
        args.Remove("delay");
        args.Add("delay", 0.18f);
        iTween.MoveBy(CreerInfo.Instance.gameObject, args);


        args.Remove("delay");
        args.Add("delay", 0.25f);
        iTween.MoveBy(backBtn, args);

        StartCoroutine(DelayUnActive());
        //gameObject.SetActive(false);
        SoundManager.Instance.PlaySoundEffect(sound);
    }


    IEnumerator DelayUnActive()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }


	void Start () {
        gameObject.SetActive(false);
	}


}

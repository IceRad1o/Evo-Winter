using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*MoveBall
 *@Brief 移动球,负责将玩家的触摸转换成角色的移动
 *@Author YYF
 *@Time 17.1.26
 */

/// <summary>
/// <para>Author YYF</para>
/// <para>Time 17.2.5</para>
/// Brief 移动球,负责将玩家的触摸转换成角色的移动
/// </summary>
public class MoveBall :UnitySingleton<MoveBall> {

    public GameObject moveBallBg; //移动球
    public GameObject area;
    private GameObject idleImg;     //移动球静止图片
    private GameObject moveImg;     //移动球移动图片
    private Vector3 centerPosition; //移动球正中心坐标
    private Vector3 touchPoint; //触摸坐标
    private bool isPressed; //是否触摸

    public bool IsPressed
    {
        get { return isPressed; }
    }

	void Start () {
        initMoveBall();
        isPressed = false;
        ActionManager.UndisplayUIObject(gameObject);
    }
	

	void Update () {
        if (isPressed)
        {
            OnMoveMoved(moveBallBg);
        }
	}

    void initMoveBall()
    {

        //TODO 根据首选项初始化位置大小等

        idleImg = moveBallBg.transform.FindChild("Idle").gameObject;
        moveImg = moveBallBg.transform.FindChild("Move").gameObject;

        EventTriggerListener.Get(moveBallBg).onEnter = OnMoveEnter;
        EventTriggerListener.Get(area).onClick = OnMoveClick;
        EventTriggerListener.Get(moveBallBg).onExit = OnMoveExit;

        centerPosition = new Vector3(110, 115, 0);
        idleImg.SetActive(true);
        moveImg.SetActive(false);
    }


    //当触摸进入
    private void OnMoveEnter(GameObject obj)
    {

        touchPoint = Input.mousePosition;
        //Debug.Log("OnMoveEnter" + touchPoint);
        isPressed = true;
       
    }




    //当鼠标点击
    private void OnMoveClick(GameObject obj)
    {
        //Debug.Log("OnMoveClick" + Input.mousePosition);
        gameObject.transform.position = Input.mousePosition;
        ActionManager.DisplayUIObject(gameObject);
        centerPosition = Input.mousePosition;
        idleImg.SetActive(true);
        moveImg.SetActive(false);
    }


    //当触摸移出
    private void OnMoveExit(GameObject obj)
    {
        touchPoint = Input.mousePosition;
        //Debug.Log("OnMoveExit" + touchPoint);
        isPressed = false;

        idleImg.SetActive(true);
        moveImg.SetActive(false);

        ActionManager.UndisplayUIObject(gameObject);

        if (Player.Instance.Character)
            Player.Instance.Character.IsMove = 0;
    }


    //当触摸移动时
    private void OnMoveMoved(GameObject obj)
    {
        idleImg.SetActive(false);
        moveImg.SetActive(true);
        touchPoint = Input.mousePosition;

        //判断触摸是否在球上
        RectTransform rtf = moveBallBg.GetComponent<RectTransform>();

        RectTransform rtfInternal = idleImg.GetComponent<RectTransform>();
  
        if (touchPoint.x > rtfInternal.position.x + rtfInternal.sizeDelta.x*0.5f || touchPoint.y > rtfInternal.position.y + rtfInternal.sizeDelta.y*0.5f || touchPoint.x < rtfInternal.position.x - rtfInternal.sizeDelta.x*0.5f || touchPoint.y < rtfInternal.position.y - rtfInternal.sizeDelta.y*0.5f)
        {
            idleImg.SetActive(false);
            moveImg.SetActive(true);
        }
        else
        {
            idleImg.SetActive(true);
            moveImg.SetActive(false);
            return;
        }
        //Debug.Log("rtfps:"+rtf.position);
        //Debug.Log(rtf.sizeDelta);
        if (touchPoint.x > rtf.position.x + rtf.sizeDelta.x || touchPoint.y > rtf.position.y + rtf.sizeDelta.y || touchPoint.x < rtf.position.x - rtf.sizeDelta.x || touchPoint.y < rtf.position.y - rtf.sizeDelta.y)
            return;

        // Debug.Log("移动:" + touchPoint);
        Vector3 offset = touchPoint - centerPosition;
        offset.Normalize();
        float angle;
        Vector3 oVector = new Vector3(0, -1, 0);
        Vector3 v3 = Vector3.Cross(offset, oVector);
        if (v3.z > 0)
            angle = -Vector3.Angle(offset, oVector);
        else
            angle = -360 + Vector3.Angle(offset, oVector);
        moveImg.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle);

        if (Player.Instance.Character)
        {
            Player.Instance.Character.Direction = offset;
            Player.Instance.Character.IsMove = 1;
        }
   
    }
}

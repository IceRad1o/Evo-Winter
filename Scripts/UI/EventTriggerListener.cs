using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// Author: wbq
/// 事件触发封装 - 需要什么事件可扩展
/// Event trigger listener.
/// 这是一个静态类，用委托来传递你想要的事件。比如你再某个类中要监听你的 YourButton。
///EventTriggerListener.Get(YourButton).onClick = onClickButtonHandler;
///private void onClickButtonHandler( GameObject obj ){
///    Debug.log("点击到了你的按钮");
///｝
/// 
///.onClick 可以换成其他的事件，如按下、抬起、划过等。
/// </summary>

public class EventTriggerListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onClick;//点击
    public VoidDelegate onDown;//按下
    public VoidDelegate onEnter;//进入
    public VoidDelegate onExit;//退出
    public VoidDelegate onUp;//抬起
    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(gameObject);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown(gameObject);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) onEnter(gameObject);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) onExit(gameObject);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp(gameObject);
    }

   
}
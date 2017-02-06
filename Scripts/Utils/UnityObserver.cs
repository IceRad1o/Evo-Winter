using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>  
/// 抽象观察者，定义接收通知的接口  
/// </summary>  
public abstract class Observer
{
    public abstract void OnNotify(string msg);
}  


/// <summary>  
/// 抽象主题（抽象被观察者）类,内含观察者列表和实现接收各种通知  
/// </summary>  
public class Subject:MonoBehaviour
{
    private List<Observer> observerList = new List<Observer>(); 
    /// <summary>  
    /// 添加观察者  
    /// </summary>  
    /// <param name="observer"></param>  
    public void AddObserver(Observer observer)
    { 
       observerList.Add(observer);
    }
    /// <summary>  
    /// 移除观察者  
    /// </summary>  
    /// <param name="observer"></param>  
    public void RemoveObserver(Observer observer)
    {
       observerList.Remove(observer);
    }
    /// <summary>  
    /// 推送通知  
    /// </summary>  
    public void Notify(string msg)
    {
        foreach (Observer o in observerList)
        {
            o.OnNotify(msg);
        }
    }
}  


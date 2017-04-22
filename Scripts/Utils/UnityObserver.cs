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
    public virtual void Notify(string msg)
    {
        foreach (Observer o in observerList)
        {
            o.OnNotify(msg);
        }
    }
} 

public class ExSubject:Subject
{
    private List<ExSubject> exObserverList = new List<ExSubject>();

    /// <summary>  
    /// 添加观察者  
    /// </summary>  
    /// <param name="observer"></param>  
    public void AddObserver(ExSubject observer)
    {
        exObserverList.Add(observer);
    }
    /// <summary>  
    /// 移除观察者  
    /// </summary>  
    /// <param name="observer"></param>  
    public void RemoveObserver(ExSubject observer)
    {
        exObserverList.Remove(observer);
    }
    /// <summary>
    /// 获得所有的观察者
    /// </summary>
    /// <returns></returns>
    public ExSubject[] GetAllObserver() 
    {
        return exObserverList.ToArray();
    }

    public void RemoveAllObserver()
    {
        exObserverList.Clear();
    }
    /// <summary>  
    /// 推送通知  
    /// </summary>  
    public override  void  Notify(string msg)
    {
        base.Notify(msg);
        var s = exObserverList.ToArray();
        foreach (ExSubject o in s)
        {
            o.OnNotify(msg);
        }
    }

    public virtual void OnNotify(string msg)
    { 
    }
 
}


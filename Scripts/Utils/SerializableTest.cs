using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 测试Serializable
/// </summary>
[System.Serializable]   //如果其内部全为数据,则可序列化
public class SerializableTest : MonoBehaviour
{

    [Header("Test Type")]   //建立一个Header以更好的分类
    public bool type = false;

    [ConditionalHide("type", false)]    //当type为true时禁止输入
    public bool forbid = false;


    [ConditionalHide("type", true)]     //当type为true时不可见
    public bool unSeen = false;

    [ConditionalHide("type", true)]   
    public List<int> values;//当type为true时不可见,条件：在序列化类中


} 

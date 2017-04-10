﻿using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

    /// <summary>
    /// 是否为UI元素,默认false
    /// </summary>
    public bool isOnCanvas = false;

    /// <summary>
    /// 持续时间,运动开始后不可变更,默认1
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// 是否重置初始值,默认false
    /// </summary>
    public bool isReset = false;

    /// <summary>
    /// 是否将初始值设为0,默认false
    /// </summary>
    public bool resetToZero = false;

    /// <summary>
    /// 重置值
    /// </summary>
    public Vector4 resetValue;

    /// <summary>
    /// 是否反转,默认false
    /// </summary>
    public bool isReverse = false;
    /// <summary>
    /// 是否延迟反转,默认false
    /// </summary>
    public bool isReverseDelay = false;

    public float reverseDelayTime ;
    /// <summary>
    /// 是否循环,默认false
    /// </summary>
    public bool isLoop = false;
    
    /// <summary>
    /// 是否永久循环,默认false
    /// </summary>
    public bool loopForever = false;

    /// <summary>
    /// 循环次数
    /// </summary>
    public int loopTimes;


    /// <summary>
    /// 是否延迟
    /// </summary>
    public bool isDelay = false;

    /// <summary>
    /// 延迟时间
    /// </summary>
    public float delayTime=0f;


    /// <summary>
    /// 持续帧数
    /// </summary>
    protected int count;



    public void Init1(float duration)
    {

    }


}

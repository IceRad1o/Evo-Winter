using UnityEngine;
using System.Collections;
using UnityEditor.Animations; 


public class AnimationController : MonoBehaviour {
    public AnimatorController ac;
    public string[] attackAnimationNames;
    /// <summary>
    /// 改变单个动画的速度
    /// </summary>
    /// <param name="animationName">动画的名称</param>
    /// <param name="speed">播放速度</param>
    public void ChangeAnimationSpeed(string animationName,float speed)
    {
        if(ac==null)
        {
            Debug.Log("AnimatorController NULL!");
            return;
        }
       
        for (int i = 0; i < ac.layers[0].stateMachine.states.Length; i++)
        {
           // Debug.Log(AC.layers[0].stateMachine.states[i].state.name);
            if (ac.layers[0].stateMachine.states[i].state.name == animationName)
            {
                ac.layers[0].stateMachine.states[i].state.speed = speed;
            }
        }
    }

    /// <summary>
    /// 改变所有攻击动画的速度
    /// </summary>
    /// <param name="speed"></param>
    public void ChangeAttackAnimationsSpeed(float speed)
    {
      for(int i=0;i<attackAnimationNames.Length;i++)
      {
          ChangeAnimationSpeed(attackAnimationNames[i], speed);
      }
    }
}

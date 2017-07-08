using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

#region 检测选中的游戏对象是否在视野内

/// <summary>  
///CanSeeObject是在Conditional下的节点，因此自己手动写的一个类似于CanSeeObject的节点继承自Conditional，在这里命名为MyCanSeeObject  
///寻找队列中第一个在视野中的目标对象
/// </summary>  
public class MyCanSeeObject : Conditional
{
    public string targetTag;

    /// <summary>  
    /// 视野距离（共享变量）  
    /// </summary>  
    public SharedFloat sharedSight;
    /// <summary>  
    /// 在视野内检测到的游戏对象位置（共享变量，在这里将检测到的游戏对象位置数据附给它）  
    /// </summary>  
    public SharedGameObject storeTarget;
    public SharedFloat storeDistance;
    public SharedVector3 storeDistanceV3;


    public override TaskStatus OnUpdate()
    {
        
        if (targetTag == null) return TaskStatus.Failure;
        
       // for(int i=0;i<)
        var list= CharacterManager.Instance.CharacterList;

        for (int i = 0; i < list.Count;i++ )
        {
            if(list[i].CompareTag(targetTag))
            {
                Vector3 distanceV3 = (list[i].transform.position - gameObject.transform.position);
                float distance = distanceV3.magnitude;
                if(distance<=sharedSight.Value)
                {
                    storeTarget.Value = list[i].gameObject;
                    storeDistance.Value = distance;
                    storeDistanceV3.Value = distanceV3;
                    GetComponent<RoomElement>().EnableBloodBar(true);
                    return TaskStatus.Success;
                }
            }


        }

        return TaskStatus.Failure;
    }
}

#endregion
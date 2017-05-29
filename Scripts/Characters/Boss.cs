using UnityEngine;
using System.Collections;
/// <summary>
/// Boss
/// Brief:标识游戏Boss实体
/// Author:IfYan
/// LatestUpdateTime:2017.5.9
/// </summary>
//public class Boss :Enemy{

//    public override void Awake()
//    {
//        base.Awake();
//        this.tag = "Boss";
//        this.IsSuperArmor = 1;
//        this.Sight = 5;
//        this.AddObserver(BossHealthBar.Instance);
//        Notify("BossAppear;"+(RoomElementID-2050));
//        //EnemyManager.Instance.EnemyList.Add(this);
//    }

//    public override void Die()
//    {
//        RoomManager.Instance.DropBox( this.transform.position,2,4);
//        if(RoomElementID==2057)
//        {
//            Destroy(GreedBar.Instance.gameObject);
//            foreach(Enemy enemy in EnemyManager.Instance.EnemyList)
//            {

//                if (enemy.RoomElementID == 2157)
//                    enemy.Die();
//            }
//        }


//        base.Die();
//    }
//}

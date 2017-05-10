using UnityEngine;
using System.Collections;
/// <summary>
/// Boss
/// Brief:标识游戏Boss实体
/// Author:IfYan
/// LatestUpdateTime:2017.5.9
/// </summary>
public class Boss :Enemy{


  
    public override void Awake()
    {
        base.Awake();
        this.tag = "Boss";
        this.IsSuperArmor = 1;
        this.AddObserver(BossHealthBar.Instance);
        Notify("BossAppear;"+(RoomElementID-2050));
        //EnemyManager.Instance.EnemyList.Add(this);
    }


   

    public override void Die()
    {
        DropBox( this.transform.position,2,4);
        if(RoomElementID==2057)
        {
            foreach(Enemy enemy in EnemyManager.Instance.EnemyList)
            {

                if (enemy.RoomElementID == 2157)
                    enemy.Die();
            }
        }


        base.Die();
    }


    public void DropBox(Vector3 position,int minNum=1,int maxNum=2)
    {
        
        Vector3 startPoint = position + new Vector3(0, 1, 0);
        int num = Random.Range(minNum,maxNum);
        for (int i = 0; i < num; i++)
        {
            Vector3 deltaPos = new Vector3((Random.value - 0.5f) * 5, (Random.value - 0.5f) * 5);
            GameObject ins = Instantiate(box, startPoint, Quaternion.identity) as GameObject;
            Vector3[] paths = new Vector3[3];
            paths[0] = startPoint;
            paths[1] = startPoint + deltaPos / 3 + new Vector3(0, 1.5f, 0);
            paths[2] = startPoint + deltaPos;
            iTween.MoveTo(ins, iTween.Hash("path", paths, "speed", 30f, "easeType", iTween.EaseType.easeInQuad));
        }
    }


}

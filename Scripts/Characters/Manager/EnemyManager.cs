using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : ExUnitySingleton<EnemyManager>{

    List<Character> enemyList = new List<Character>();

    public List<Character> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }


   public void ClearAll()
    {
        foreach (var enemy in enemyList)
        {
            if (enemy!=null)
                 Destroy(enemy.gameObject);
        }
        EnemyList.Clear();
    }
}

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

}

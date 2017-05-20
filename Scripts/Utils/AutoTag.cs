using UnityEngine;
using System.Collections;
/// <summary>
/// 获取一个有Tag的GameObject的目标Tags
/// </summary>
public class AutoTag : ExUnitySingleton<AutoTag>{


    static string [] playerTags=new string[] { "Enemy", "Monster", "Boss", "DynamicGroundElement", "FakeBoss" };
    static string[] friendTags = new string[] { "Enemy", "Monster", "Boss", "FakeBoss" };
    static string[] enemyTags = new string[] { "Player", "Friend" };
    static string[] bossTags = new string[] { "Player", "Friend", "Monster" };
    static public string [] GetTargetTags(string tag)
    {
        string[] destTags = null ;
        if (tag == "Player")
        {
            destTags = playerTags;
        }
        else if (tag == "Friend")
        {
            destTags = friendTags;
        }
        else if (tag == "Enemy")
        {
            destTags = enemyTags;
        }
        else if (tag == "Monster")
        {
            destTags = enemyTags;
        }
        else if (tag == "Boss")
        {
            destTags = bossTags;
        }
        else if (tag == "FakeBoss")
        {
            destTags = bossTags;
        }
        return destTags;
    }


    static public bool IsEnemyTag(string tag1,string tag2)
    {
        if (tag1 == "Player")
        {
            for (int i = 0; i < playerTags.Length; i++)
                if (playerTags[i].Equals(tag2))
                    return true;
            return false;
        }
        else if (tag1 == "Friend")
        {
            for (int i = 0; i < friendTags.Length; i++)
                if (friendTags[i].Equals(tag2))
                    return true;
            return false;
        }
        else if (tag1 == "Enemy" || tag1 == "Monster")
        {
            for (int i = 0; i < enemyTags.Length; i++)
                if (enemyTags[i].Equals(tag2))
                    return true;
            return false;
        }
    
        else if (tag1 == "Boss"||tag1=="FakeBoss")
        {
            for (int i = 0; i < bossTags.Length; i++)
                if (bossTags[i].Equals(tag2))
                    return true;
            return false;
        }
 
        return false;
    }

}

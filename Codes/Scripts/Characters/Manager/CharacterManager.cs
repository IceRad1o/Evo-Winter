using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// CharacterManager
/// Brief: For Management of all characters
/// Author: IfYan
/// Latest Update Time: 2017.5.11
/// </summary>
public class CharacterManager :ExUnitySingleton<CharacterManager>
{
   
    List<Character> characterList = new List<Character>();

    List<Character> enemyList = new List<Character>();

    List<Character> friendList = new List<Character>();


    public List<Character> CharacterList
    {
        get { return characterList; }
        set { characterList = value; }
    }
    public List<Character> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }
    public List<Character> FriendList
    {
        get { return friendList; }
        set { friendList = value; }
    }

    public void Add(Character ch)
    {
        CharacterList.Add(ch);
        if(ch.CompareTag("Monster"))
        {
            //EnemyList.Add(ch);
            EnemyManager.Instance.EnemyList.Add(ch);
        }
        else if(ch.CompareTag("Boss"))
        {
            EnemyManager.Instance.EnemyList.Add(ch);
        }
        else if(ch.CompareTag("FakeBoss"))
        {
            ch.IsSuperArmor = 1;
        }
        else if(ch.CompareTag("Friend"))
        {
            FriendList.Add(ch);
        }

    }

    public void Remove(Character ch)
    {
        CharacterList.Remove(ch);
        if (ch.CompareTag("Monster") || ch.CompareTag("Boss") || ch.CompareTag("FakeBoss"))
        {
            //EnemyList.Remove(ch);
            EnemyManager.Instance.EnemyList.Remove(ch);
            if (EnemyManager.Instance.EnemyList.Count == 0)
                EnemyManager.Instance.Notify("ClearRoom");
        }
        else if (ch.CompareTag("Friend"))
        {
            FriendList.Remove(ch);
        }
    }

    

}

using UnityEngine;
using System.Collections;
/// <summary>
/// 获取一个有Tag的GameObject的目标Tags
/// </summary>
public class AutoTag : ExUnitySingleton<AutoTag>{

    string [] GetTargetTags(string tag)
    {
        string[] destTags = null ;
        if (tag == "Player")
        {
            destTags = new string[] { "Enemy", "Monster", "Boss", "RoomElement", "FakeBoss" };
        }
        else if (tag == "Friend")
        {
            destTags = new string[] { "Enemy", "Monster", "Boss",  "FakeBoss" };
        }
        else if (tag == "Enemy")
        {
            destTags = new string[] { "Player", "Friend" };
        }
        else if (tag == "Monster")
        {
            destTags = new string[] { "Player", "Friend" };
        }
        else if (tag == "Boss")
        {
            destTags = new string[] { "Player", "Friend","Monster" };
        }
        else if (tag == "FakeBoss")
        {
            destTags = new string[] { "Player", "Friend" };
        }
        return destTags;
    }
}

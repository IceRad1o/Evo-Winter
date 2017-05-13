using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// FriendManager
/// Brief: For Management of all friends
/// Author: IfYan
/// Latest Update Time: 2017.5.11
/// </summary>
public class FriendManager : ExUnitySingleton<FriendManager> {

    List<Friend> friendList = new List<Friend>();

    public List<Friend> FriendList
    {
        get { return friendList; }
        set { friendList = value; }
    }

}

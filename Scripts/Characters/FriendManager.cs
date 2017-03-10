using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FriendManager : ExUnitySingleton<FriendManager> {

    List<Friend> friendList = new List<Friend>();

    public List<Friend> FriendList
    {
        get { return friendList; }
        set { friendList = value; }
    }

}

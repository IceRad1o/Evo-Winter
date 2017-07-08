using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RoomElementManager : ExUnitySingleton<RoomElementManager>
{
    List<RoomElement> roomElementList = new List<RoomElement>();
    public List<RoomElement> RoomElementList
    {
        get { return roomElementList; }
        set { roomElementList = value; }
    }

    /// <summary>
    /// 删除除了Player以外的所有RoomElement
    /// </summary>
    public void ClearAll()
    {
        for (int i = roomElementList.Count-1; i >= 0; i--)
        {
            if (!roomElementList[i].CompareTag("Player"))
            {
                if (roomElementList[i].IsDestoryOnEnterRoom)
                    roomElementList[i].Destroy();
            }
        }
     
    }
}

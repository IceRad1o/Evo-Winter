using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RETable : ExUnitySingleton<RETable> {

    public GameObject bloodBarPrefab;
    public static bool isInit=false;
    public RoomElement[] roomElements;
    //REID->RoomElement的字典,快速查找ID为X的RoomElement
    public static Dictionary<REID, RoomElement> REDict = new  Dictionary<REID, RoomElement>(100);
    public static Dictionary<RoomDomain, RoomElement[]> DomainDict = new Dictionary<RoomDomain, RoomElement[]>();
    //public override void Awake()
    //{
    //    base.Awake();
    //    Debug.Log("ret1:" + RETable.DomainDict);
    //    InitREDict();
    //    Debug.Log("ret2:" + RETable.DomainDict);
    //}
    private void Start()
    {
        if (!isInit)
        {
            InitREDict();
            isInit = true;
        }
    }

    public void InitREDict()
    {
        
        for (int i = 0; i < roomElements.Length; i++)
        {
            //Debug.Log("<color=blue>Fatal error:</color>" + i, gameObject) ;
            REDict.Add(roomElements[i].RoomElementID, roomElements[i]);
        }
        //TODO O(n),可优化
        foreach (RoomDomain item in System.Enum.GetValues(typeof(RoomDomain)))
        {
            DomainDict.Add(item,FindRoomElementsByDomain(item));
        }

    }

    RoomElement[] FindRoomElementsByDomain(RoomDomain domain)
    {
        List<RoomElement> list = new List<RoomElement>();
        for(int i=0;i<roomElements.Length;i++)
        {
            if (roomElements[i].belongDomain == domain)
                list.Add(roomElements[i]);
        }
        return list.ToArray();
    }


}

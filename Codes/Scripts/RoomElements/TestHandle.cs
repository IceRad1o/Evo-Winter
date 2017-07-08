using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestHandle : RoomElement
{   
    public enum TestType
    {
        Items,
        RoomElements,
        Monster,
        Boss
    }
    bool isOn = false;
    int times=0;
    List<RoomElement> list = new List<RoomElement>();

    private void Start()
    {
        if (RoomElementState >= 10)
            isOn = true;
        if(!isOn)
           HandleOn();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            if(isOn)
            {
                HandleOff();
               
            }
            else
            {
                HandleOn();
            }
        }
    }

    void HandleOn()
    {

        switch ((TestType)RoomElementState)
        {
            case TestType.Items:
                GenerateItems();
                break;
            case TestType.RoomElements:
                GenerateRoomElements();
                break;
            case TestType.Monster:
                GenerateMonster();
                break;
            case TestType.Boss:
                GenerateBoss();
                break;
            default:
                break;
        }
        isOn = true;

        GetComponent<Animator>().SetTrigger("switchOn");
        RoomElementState += 10;
        times++;
    }

    void HandleOff()
    {
        isOn = false;
        RoomElementState -= 10;
        GetComponent<Animator>().SetTrigger("switchOn");
        Clear();

    }
    void Clear()
    {
        for(int i=0;i<list.Count;i++)
        {
            if(list[i]!=null)
                list[i].Die();
        }
        list.Clear();
    }
    //道具房:左：按间隔生成所有道具 右:清空
    void GenerateItems()
    {
        var items = ItemsTable.Instance.itemDataArray;
        int columns = 10;
        for (int i=0;i<items.Length;i++)
        {
           list.Add( ItemManager.Instance.CreateItemID(items[i].ID,new Vector3(-6.4f+i%columns*1.2f,0-i/columns*2)));
        }  
    }
    //房间元素房 
    void GenerateRoomElements()
    {
        var items = RETable.Instance.roomElements;
        int columns = 7;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].roomElementID == REID.TestHandle ||
                items[i].roomElementID == REID.DoorFront ||
                items[i].roomElementID == REID.DoorLeft ||
                items[i].roomElementID == REID.DoorRight ||
                items[i].roomElementID == REID.DoorBack||
                 items[i].roomElementID == REID.Shop
                )
                continue;
            list.Add(Instantiate(items[i], new Vector3(-6.4f + i % columns * 2f,  - i / columns * 3),Quaternion.identity) as RoomElement);
        }
    }
    //怪物房 放置稻草人 左：按次序生成一个怪物  右：杀死怪物
    void GenerateMonster()
    {
        var items = CharacterTable.CampDict[Character.CampType.Monster];
        int index = times % items.Length;
        int num = Random.Range(1, 6);
        for(int i=0;i<num;i++)
        {
            list.Add(Instantiate(items[index], new Vector3(-5+num%3*5, -2-num/3*2, -2 - num / 3 * 2), Quaternion.identity) as RoomElement);
        }

    }
    //Boss房 类似
    void GenerateBoss()
    {
        var items = CharacterTable.CampDict[Character.CampType.Boss];
        int index = times % items.Length;
        list.Add(Instantiate(items[index], new Vector3(-1, -1), Quaternion.identity) as RoomElement);    
    }


    public override void Destroy()
    {
        Clear();
        base.Destroy();

    }


}

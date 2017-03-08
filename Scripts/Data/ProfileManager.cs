using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 存档管理
/// 存档数据在每一次进入房间和清空房间的时候更新
/// </summary>
public class ProfileManager : ExUnitySingleton<ProfileManager>{


    ProfileData data;


    public ProfileData Data
    {
        get { return data; }
        set { data = value; }
    }

    void InitData()
    {
        data = new ProfileData();
        data.Init();
    }


    void Start()
    {
        InitData();

    }

    public override void OnNotify(string msg)
    {

        if (msg == null)
        {
            Debug.LogError("the msg is null!");
        }
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "ClearRoom")
        {
            data.Health = Player.Instance.Character.Health;
            data.MoveSpeed = Player.Instance.Character.MoveSpeed;
            data.AttackRange = Player.Instance.Character.AttackRange;
            data.AttackDamage = Player.Instance.Character.AttackDamage;
            data.HitRecover = Player.Instance.Character.HitRecover;
            data.Spasticity = Player.Instance.Character.Spasticity;
            data.Race = Player.Instance.Character.Weapon;
            data.Sight = Player.Instance.Character.Sight;
            data.Camp = Player.Instance.Character.Camp;
            data.Luck = Player.Instance.Character.Luck;
            data.ActionStateMachineID = Player.Instance.Character.ActionStateMachine.MachineID;
            data.CurPosition = Player.Instance.Character.transform.position;
            //data.Map=
            if (ItemManager.Instance.itemInitiative!=null)
                data.ItemEnergy = ItemManager.Instance.itemInitiative.EnergyNow;
            List<int> templist = new List<int>();
            if (ItemManager.Instance.itemInitiative != null)
                templist.Add(ItemManager.Instance.GetInitiativeItem().ItemID);
            else
                templist.Add(-1);
            if (ItemManager.Instance.GetDisposableItems() != null)
                templist.Add(ItemManager.Instance.GetDisposableItems().ItemID);

            for (int i = 0; i < ItemManager.Instance.listDisposableItem.Count; i++)
                templist.Add(ItemManager.Instance.listDisposableItem[i].ItemID);
            for (int i = 0; i < ItemManager.Instance.listImmediatelyItem.Count; i++)
                templist.Add(ItemManager.Instance.listImmediatelyItem[i].ItemID);
            for (int i = 0; i < ItemManager.Instance.listInitiativeItem.Count; i++)
                templist.Add(ItemManager.Instance.listInitiativeItem[i].ItemID);
            data.ItemsID = templist.ToArray();




           

        }
        if(str[0]=="EnterRoom")
        {

        }
        //if (str[0] == "BgmVolumeChanged")
            // data.BackGroundMusicVolume = float.Parse(str[1]);
    }
}

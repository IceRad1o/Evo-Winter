using UnityEngine;
using System.Collections;
/// <summary>
/// 玩家类,即玩家的操控对象
/// </summary>
public class Player :ExUnitySingleton<Player>,IFly {

    Character character;

    public Character Character
    {
        get { return character; }
        set { character = value; }
    }

    void Start()
    {
        this.tag = "Player";
        character = GetComponent<Character>();
        character.Camp = 0;
        //加载存档
        if (PlayerPrefs.GetInt("isNew", 1) == 0)
            LoadPlayerMsg();

    }

    //扩展方法示例
    void Fly()
    {
        Debug.Log("此处为 C# 扩展方法示例");
        this.fly();
    }


    void LoadPlayerMsg()
    {
        //Debug.Log("load");
        ProfileData data = ProfileManager.Instance.Data;
        character.Health = (int)data.Health;
        character.MoveSpeed = (int)data.MoveSpeed;
        character.AttackDamage = (int)data.AttackDamage;
        character.AttackRange = (int)data.AttackRange;
        character.Luck = (int)data.Luck;
        character.HitRecover = (int)data.HitRecover;
        character.Spasticity = data.Spasticity;
        character.Weapon = data.Weapon;
        character.Race = data.Race;
        character.ActionStateMachine.MachineID=data.ActionStateMachineID;
        character.transform.position=data.CurPosition;
        character.Sight=data.Sight;
        character.Camp=data.Camp;

    }
}

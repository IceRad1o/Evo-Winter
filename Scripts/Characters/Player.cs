using UnityEngine;
using System.Collections;
/// <summary>
/// 玩家类,即玩家的操控对象
/// </summary>
public class Player :UnitySingleton<Player>,IFly {

    Character character;

    public Character Character
    {
        get { return character; }
        set { character = value; }
    }

    void Start()
    {
        character = GetComponent<Character>();
        character.MoveSpeed = 0.1f;
    }

    //扩展方法示例
    void Fly()
    {

        this.fly();
    }
}

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
        this.tag = "Player";
        character = GetComponent<Character>();
        character.MoveSpeed = 5;
  
    }

    //扩展方法示例
    void Fly()
    {
        Debug.Log("此处为 C# 扩展方法示例");
        this.fly();
    }
}

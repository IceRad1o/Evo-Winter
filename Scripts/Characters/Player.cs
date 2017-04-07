using UnityEngine;
using System.Collections;
/// <summary>
/// 玩家类,即玩家的操控对象
/// </summary>
public class Player :ExSubject,IFly {

    Character character;

    public Character Character
    {
        get { 
            if(character==null)
                character = GetComponent<Character>();
            return character;
        }
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

    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(Player)) as Player;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.DontSave;  
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = (Player)obj.AddComponent(typeof(Player));
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {

        //DontDestroyOnLoad(this.gameObject);

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {

            Destroy(_instance);
            _instance = this ;
        }
    }


}

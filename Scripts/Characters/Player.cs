using UnityEngine;
using System.Collections;
/// <summary>
/// 玩家类,即玩家的操控对象
/// </summary>
public class Player :ExSubject {

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
       // character.Camp = 0;
        //加载存档
        if (PlayerPrefs.GetInt("isNew", 1) == 0)
            LoadPlayerMsg();

    }




    void LoadPlayerMsg()
    {
        //Debug.Log("load");
        ProfileData data = ProfileManager.Instance.Data;
        character.Hp = (int)data.Hp;
        character.Atk = (int)data.Atk;
        //TODO character.Spd=(int)data.Att
        character.Rng = (int)data.Rng;
        character.Mov = (int)data.Mov;
        character.Fhr = (int)data.Fhr;
        character.Luk = (int)data.Luk;
  
        //character.RoomElementID= data.Spasticity;
        //character.Career = data.Weapon;
        //character.Race = data.Race;
       // character.ActionStateMachine.MachineID=data.ActionStateMachineID;
        character.transform.position=data.CurPosition;
        character.Sight=data.Sight;
        //character.Camp=data.Camp;

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
        this.tag = "Player";
    }


}

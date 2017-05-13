using UnityEngine;
using System.Collections;
/// <summary>
/// PlayerManager 
/// Brief:The manager that responses for the switch of character.
/// Author:IfYan
/// Latest Update Time:2017.5.11
/// </summary>
public class PlayerManager : ExUnitySingleton<PlayerManager>{
    /// <summary>
    /// Player的Prefabs集合
    /// </summary>
    public GameObject[] players;
    /// <summary>
    /// 是否一开始就初始化Player
    /// </summary>
    public bool isRandomInit=false;
    public bool isChangePlayer = true;
    public bool initOnStart = true;
    public int initCharacterID = 0;
    /// <summary>
    /// 判断是否是第一次初始化Player
    /// </summary>
    bool isInit = false;
    /// <summary>
    /// 玩家默认出生点
    /// </summary>
    static Vector3 rebornPlace = new Vector3(-2, -2, 0);
	void Start () {
        if (initOnStart)
        {
            if(isRandomInit)
                SwitchPlayer(Random.Range(0, 16));
            else
                SwitchPlayer(initCharacterID);
        }
              
	}

    /// <summary>
    /// 切换人物
    /// </summary>
    /// <param name="ID">人物ID</param>
    public void SwitchPlayer(int ID)
    {
        if (!isInit)
        {
            Instantiate(players[ID], rebornPlace, Quaternion.identity);
            isInit = true;
        }
        else
        {
            //销毁BuffManager和SkillManager
            Player.Instance.gameObject.GetComponent<BuffManager>().DestoryManager();
            Player.Instance.gameObject.GetComponent<SkillManager>().DestoryManager();
            //保存原有Buff
            var strBuff = Player.Instance.GetComponent<BuffManager>().SavingBuff();
            //保存原有Observer
            var observers = Player.Instance.GetComponent<Character>().GetAllObserver();
            //保存原有属性
            var attris = Player.Instance.Character.GetAttris();     
            //删除Player
            Player.Instance.Character.Destroy();
            //生成新Player
            Instantiate(players[ID], Player.Instance.transform.position, Quaternion.identity);
            //加载原有属性
            Player.Instance.Character.LoadAttris(attris);
            //加载原有buff
            Player.Instance.GetComponent<BuffManager>().LoadBuff(strBuff);
            //加载原有Observer
            foreach (var item in observers)
            {
                Player.Instance.GetComponent<Character>().AddObserver(item);
            } 
            //将是否切换角色的变量赋值为true
            isChangePlayer = true;
            //切换精华，延迟0.1f
            StartCoroutine(SwitchEsscence(Player.Instance.GetComponent<Character>().Race));
            Player.Instance.Character.Notify("RaceChanged;0;" + Player.Instance.Character.Race);
        }

    }

    IEnumerator SwitchEsscence(Character.RaceType race)
    {
        yield return new WaitForSeconds(0.1f);
        EsscenceManager.Instance.SwitchEsscence((int)Player.Instance.GetComponent<Character>().Race);
    }

    /// <summary>
    /// 切换人物的方法2
    /// 未完善
    /// </summary>
    [System.Obsolete]
    public void SwitchPlayerMethod2(int ID)
    {
        //保留原有人物
        Animator anim = Player.Instance.GetComponent<Animator>();
        anim.enabled = false;
        Destroy(Player.Instance.transform.Find("BodyNode").Find("Body").gameObject);

        GameObject a = Instantiate(players[ID].transform.Find("Body").gameObject, Player.Instance.transform, false) as GameObject;
        a.name = "Body";
        anim.runtimeAnimatorController = players[ID].GetComponent<Animator>().runtimeAnimatorController;
        anim.enabled = true;
        //Player.Instance.transform.Find("Body").transform.SetParent(Player.Instance.transform.Find("BodyNode"));
        Player.Instance.Character.CharacterSkin.weapons = players[ID].GetComponent<Character>().CharacterSkin.weapons;
        Player.Instance.Character.CharacterSkin.missiles = players[ID].GetComponent<Character>().CharacterSkin.missiles;

        //TODO Sound


        Player.Instance.Character.Direction = new Vector3(-1, 0, 0);
        Player.Instance.Character.RoomElementID = players[ID].GetComponent<Character>().RoomElementID;
        //Player.Instance.GetComponent<CharacterSkin>().SetSkin();
    }
}

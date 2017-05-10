using UnityEngine;
using System.Collections;
/// <summary>
/// The manager that responses for the switch of character.
/// </summary>
public class PlayerManager : ExUnitySingleton<PlayerManager>{
    /// <summary>
    /// 
    /// </summary>
    public GameObject[] players;
    public bool isRandomInit=false;
    bool isInit = false;
	// Use this for initialization
	void Start () {
        int a = Random.Range(0, 16);
     
        if(isRandomInit)
         InitPlayer(a );
	}

    public void InitPlayer(int ID)
    {

        if (!isInit)
        {
            Instantiate(players[ID], new Vector3(-2,-2,0), Quaternion.identity);
            isInit = true;
        }
        else
        {


            //Player.Instance.gameObject.SetActive(false);
            Player.Instance.gameObject.GetComponent<BuffManager>().DestoryManager();
            Player.Instance.gameObject.GetComponent<SkillManager>().DestoryManager();
            //保存原有buff
            var strBuff = Player.Instance.GetComponent<BuffManager>().SavingBuff();
            var observer = Player.Instance.GetComponent<Character>().GetAllObserver();

            var attris = Player.Instance.Character.GetAttris();
            //CharacterManager.Instance.CharacterList.Remove(Player.Instance.Character);
            //Destroy(Player.Instance.gameObject);
            Player.Instance.Character.Destroy();
            //删除原来人物,生成新人物
            Instantiate(players[ID], Player.Instance.transform.position, Quaternion.identity);
            //Player.Instance.AddObserver(CameraShake.Instance);
            //Player.Instance.AddObserver(UIManager.Instance);//
            //加载原有buff

            Player.Instance.GetComponent<BuffManager>().LoadBuff(strBuff);
            foreach (var item in observer)
            {
                Player.Instance.GetComponent<Character>().AddObserver(item);
            }
            Debug.Log("1:" + Player.Instance.Character.Hp);
            Debug.Log("2:" + attris[0]);
            Player.Instance.Character.LoadAttris(attris);
            Debug.Log("3:" + Player.Instance.Character.Hp);
            //切换精华，延迟0.1
            StartCoroutine(SwitchEsscence(Player.Instance.GetComponent<Character>().Race));








            Player.Instance.Character.Notify("RaceChanged;0;" + Player.Instance.Character.Race);

            return;











            //保留原有人物
            Animator anim = Player.Instance.GetComponent<Animator>();
            anim.enabled = false;
            Destroy(Player.Instance.transform.Find("BodyNode").Find("Body").gameObject);

            GameObject a = Instantiate(players[ID].transform.Find("Body").gameObject, Player.Instance.transform, false) as GameObject;
            a.name = "Body";
            anim.runtimeAnimatorController = players[ID].GetComponent<Animator>().runtimeAnimatorController;
            anim.enabled = true;
            //Player.Instance.transform.Find("Body").transform.SetParent(Player.Instance.transform.Find("BodyNode"));
            Player.Instance.Character.weapons = players[ID].GetComponent<Character>().weapons;
            Player.Instance.Character.missiles = players[ID].GetComponent<Character>().missiles;

            //TODO Sound


            Player.Instance.Character.Direction = new Vector3(-1, 0, 0);
            Player.Instance.Character.RoomElementID = players[ID].GetComponent<Character>().RoomElementID;
            Player.Instance.GetComponent<CharacterSkin>().SetSkin();
        }

    }

    IEnumerator SwitchEsscence(Character.RaceType race)
    {
        yield return new WaitForSeconds(0.1f);
        EsscenceManager.Instance.SwitchEsscence((int)Player.Instance.GetComponent<Character>().Race);
    }

}

using UnityEngine;
using System.Collections;

public class PlayerManager : ExUnitySingleton<PlayerManager>{

    public GameObject[] players;
    public bool isRandomInit=false;
    int a1= 0;
	// Use this for initialization
	void Start () {
        int a = Random.Range(0, 16);
     
        if(isRandomInit)
         InitPlayer(a );
	}

    public void InitPlayer(int ID)
    {
        a1++;
        if (Player.Instance == null)
            Instantiate(players[ID], Vector3.zero, Quaternion.identity);
        else
        {
            

            //Player.Instance.gameObject.SetActive(false);
            Player.Instance.gameObject.GetComponent<BuffManager>().DestoryManager();
            Player.Instance.gameObject.GetComponent<SkillManager>().DestoryManager();
            //保存原有buff
            var strBuff = Player.Instance.GetComponent<BuffManager>().SavingBuff();
            var observer = Player.Instance.GetComponent<Character>().GetAllObserver();
            Destroy(Player.Instance.gameObject);

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
            EsscenceManager.Instance.SwitchEsscence(Player.Instance.GetComponent<Character>().Race);







             Player.Instance.Character.Notify("RaceChanged;0;"+Player.Instance.Character.Race);

            return;
           
            
            
            
            
            
            
            
            
            
            
            //保留原有人物
           Animator anim= Player.Instance.GetComponent<Animator>();
           anim.enabled= false;
           Destroy(Player.Instance.transform.Find("BodyNode").Find("Body").gameObject);
           
           GameObject a=Instantiate(players[ID].transform.Find("Body").gameObject, Player.Instance.transform,false) as GameObject;
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


}

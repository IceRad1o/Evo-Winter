using UnityEngine;
using System.Collections;

public class PlayerManager : ExUnitySingleton<PlayerManager>{

    public GameObject[] players;
    public bool isRandomInit=false;
	// Use this for initialization
	void Start () {
        int a = Random.Range(0, 5);
        int b = Random.Range(0, 2);
        if(isRandomInit)
         InitPlayer(a + b * 8);
	}

    public void InitPlayer(int ID)
    {
        if (Player.Instance == null)
            Instantiate(players[ID], Vector3.zero, Quaternion.identity);
        else
        {
            //删除原来人物,生成新人物
            Instantiate(players[ID], Player.Instance.transform.position, Quaternion.identity);
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

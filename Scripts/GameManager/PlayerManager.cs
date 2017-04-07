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
       if(Player.Instance==null)
            Instantiate(players[ID],Vector3.zero,Quaternion.identity);
       else
           Instantiate(players[ID], Player.Instance.transform.position, Quaternion.identity);

    }


}

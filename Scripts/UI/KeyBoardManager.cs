using UnityEngine;
using System.Collections;

public class KeyBoardManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Player.Instance.Direction =new Vector3(0,1,0);
            Player.Instance.State = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.Instance.Direction = new Vector3(0, -1, 0);
            Player.Instance.State = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.Instance.Direction = new Vector3(-1, 0, 0);
            Player.Instance.State = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Player.Instance.Direction = new Vector3(1, 0, 0);
            Player.Instance.State = 1;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            AttackButtonManager.Instance.OnNormalAttack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AttackButtonManager.Instance.OnSpecialAttack();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            AttackButtonManager.Instance.OnRaceSkill();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ItemButtonManager.Instance.OnDisposableItem();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ItemButtonManager.Instance.OnInitiativeItem();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Player.Instance.State = 0;
        }
	}
}

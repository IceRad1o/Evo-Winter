using UnityEngine;
using System.Collections;

/// <summary>
/// 可通过键盘进行移动等操作
/// 仅限PC端测试使用
/// </summary>
public class KeyBoardManager : MonoBehaviour {

    int keyDownNum;
    Vector3 direction;

    void Start()
    {
        keyDownNum = 0;
        direction = new Vector3(0, 0, 0);
     
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction=new Vector3(0,1,0);
        
            keyDownNum++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction= new Vector3(0, -1, 0);
           
            keyDownNum++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction= new Vector3(-1, 0, 0);
           
            keyDownNum++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction= new Vector3(1, 0, 0);
           
             keyDownNum++;
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

        if (Input.GetKeyUp(KeyCode.W) )
        {
            keyDownNum--;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            keyDownNum--;
        }
        if (Input.GetKeyUp(KeyCode.A) )
        {
            keyDownNum--;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyDownNum--;
        }



        if (keyDownNum == 0)
            Player.Instance.Character.State = 0;
        else
        {
            Player.Instance.Character.State = 1;
            Player.Instance.Character.Direction = direction;
        }
	}
}

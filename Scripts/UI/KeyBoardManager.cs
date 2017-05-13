using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class KeyBoardManager : MonoBehaviour {

    int keyDownNum;



    Vector3 direction;
    public GameObject DamageSrc;
    public GameObject box;
    public GameObject monster;
	public GameObject handle;
    int cheatPunish;
    void Start()
    {
        cheatPunish = 0;
        keyDownNum = 0;
        direction = new Vector3(0, 0, 0);
     
    }
    ///
    bool isChanged = false;
	void Update () {
      
        //如果有触摸事件,则屏蔽键盘事件,否则键盘事件会干扰触摸事件
        if (MoveBall.Instance.IsPressed)
            return;

       
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction=new Vector3(0,1,0);
            
            keyDownNum++;isChanged=true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction= new Vector3(0, -1, 0);
           
            keyDownNum++;isChanged=true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction= new Vector3(-1, 0, 0);
            keyDownNum++;isChanged=true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction= new Vector3(1, 0, 0);
           
             keyDownNum++;isChanged=true;
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
            keyDownNum--;isChanged=true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            keyDownNum--;isChanged=true;
        }
        if (Input.GetKeyUp(KeyCode.A) )
        {
            keyDownNum--;isChanged=true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyDownNum--;isChanged=true;
        }


        if(isChanged)
        {
            if (keyDownNum == 0)
            { 
                Player.Instance.Character.IsMove = 0; 
                // Debug.Log("keyboard:"); 
            }
            else
            {
               
                Player.Instance.Character.IsMove = 1;
                Player.Instance.Character.Direction = direction;
            }
            isChanged = false;
        }
        //秒杀
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
            {
                Instantiate(DamageSrc, EnemyManager.Instance.EnemyList[i].transform.position, Quaternion.identity);
                //EnemyManager.Instance.EnemyList[i].Health = 0;
            }
            cheatPunish++;
            if(cheatPunish==10)
            {
                string []a={"Player"};
                GameObject ds=Instantiate(DamageSrc, Player.Instance.transform.position, Quaternion.identity) as GameObject;
                ds.GetComponent<HurtByContract>().destTags = a;
                ds.GetComponent<HurtByContract>().damage = 1;
                ds.GetComponent<HurtByContract>().beatDownLevelX=1;
                ds.GetComponent<HurtByContract>().beatDownLevelY=4; 
                cheatPunish=0;
            }
        }
        //静止
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
            {
               // Destroy(EnemyManager.Instance.EnemyList[i].gameObject.GetComponent<CharacterAi>());
                //EnemyManager.Instance.EnemyList[i].Health = 0;
                EnemyManager.Instance.EnemyList[i].IsControllable = 0;
            }
    
        }
        //回血
        if (Input.GetKeyDown(KeyCode.O))
        {
            
            Player.Instance.Character.Hp = 10;
        }
        //
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RandomCharacter();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GetBox();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddAttackSpeed();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GodBar.Instance.OnGate();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(monster);
        }
		if (Input.GetKeyDown(KeyCode.H))
		{
			GetHandle();
		}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PlayerInfo.Instance.gameObject.activeInHierarchy)
                PlayerInfo.Instance.Display();
            else
                PlayerInfo.Instance.Undisplay();
        }

	}

    public void RemoveAi()
    {
        for (int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
        {
            // Destroy(EnemyManager.Instance.EnemyList[i].gameObject.GetComponent<CharacterAi>());
            //EnemyManager.Instance.EnemyList[i].Health = 0;
            EnemyManager.Instance.EnemyList[i].IsControllable = 0;
        }
    }

    public void KillAll()
    {
         for (int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
            {
                Instantiate(DamageSrc, EnemyManager.Instance.EnemyList[i].transform.position, Quaternion.identity);
                //EnemyManager.Instance.EnemyList[i].Health = 0;
            }
            cheatPunish++;
            if (cheatPunish == 10)
            {
                string[] a = { "Player" };
                GameObject ds = Instantiate(DamageSrc, Player.Instance.transform.position, Quaternion.identity) as GameObject;
                ds.GetComponent<HurtByContract>().destTags = a;
                ds.GetComponent<HurtByContract>().damage = 1;
                ds.GetComponent<HurtByContract>().beatDownLevelX = 1;
                ds.GetComponent<HurtByContract>().beatDownLevelY = 4;
                cheatPunish = 0;
            }
    }
    public void FullHealth() {
        Player.Instance.Character.Hp = 10;
    }

    public void RandomCharacter()
    {
        int a = Random.Range(0, 16);
        int b = Random.Range(0, 2);
        PlayerManager.Instance.SwitchPlayer(a );
    }


    public void GetBox()
    {
        Instantiate(box, Player.Instance.transform.position, Quaternion.identity);
    }

	public void GetHandle()
	{
		Instantiate(handle, Player.Instance.transform.position, Quaternion.identity);
	}

    public void AddAttackSpeed()
    {
        Player.Instance.Character.Spd += 1;
        Player.Instance.Character.Mov += 1;
    }


}

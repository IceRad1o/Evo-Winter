using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttriInfo : ExUnitySingleton<AttriInfo> {


    int atk;

    public int Atk
    {
        get { return atk; }
        set { atk = value;
        for (int i = 0; i < 5; i++)
        {
            if (i < atk)
                atkStars[i].SetActive(true);
            else
                atkStars[i].SetActive(false);
        }
        }
    }
    int spd;

    public int Spd
    {
        get { return spd; }
        set { spd = value;
        for (int i = 0; i < 5; i++)
        {
            if (i < spd)
                spdStars[i].SetActive(true);
            else
                spdStars[i].SetActive(false);
        }
        
        }
    }
    int rng;

    public int Rng
    {
        get { return rng; }
        set { rng = value;
        for (int i = 0; i < 5; i++)
        {
            if (i < rng)
                rngStars[i].SetActive(true);
            else
                rngStars[i].SetActive(false);
        }
        }
    }
    int mov;

    public int Mov
    {
        get { return mov; }
        set { mov = value;
        for (int i = 0; i < 5; i++)
        {
            if (i < mov)
                movStars[i].SetActive(true);
            else
                movStars[i].SetActive(false);
        }
        }
    }
    int fhr;

    public int Fhr
    {
        get { return fhr; }
        set { fhr = value;
        for (int i = 0; i < 5; i++)
        {
            if (i < fhr)
                fhrStars[i].SetActive(true);
            else
                fhrStars[i].SetActive(false);
        }
        }
    }
    int luk;

    public int Luk
    {
        get { return luk; }
        set 
        { 
            
           luk = value;
           for(int i=0;i<5;i++)
           {
               if(i<luk)
                    lukStars[i].SetActive(true);
               else
                   lukStars[i].SetActive(false);
           }
        }
    }

    public GameObject[] atkStars;
    public GameObject[] spdStars;
    public GameObject[] rngStars;
    public GameObject[] movStars;
    public GameObject[] fhrStars;
    public GameObject[] lukStars;

	// Use this for initialization
	void Start () {
        Init();
	}

     void Init()
    {
        Atk = Player.Instance.Character.AttackDamage;
        Spd = Player.Instance.Character.AttackSpeed;
        Rng = Player.Instance.Character.AttackRange;
        Mov = Player.Instance.Character.MoveSpeed;
        Fhr = Player.Instance.Character.HitRecover;
        Luk = Player.Instance.Character.Luck;
    }
	

}

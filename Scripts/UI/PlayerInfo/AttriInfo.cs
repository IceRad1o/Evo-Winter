using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttriInfo : ExUnitySingleton<AttriInfo> {


    int atk;

    public int Atk
    {
        get { return atk; }
        set { atk = value;
        values[0].GetComponent<Text>().text = "" + value;
        }
    }
    int spd;

    public int Spd
    {
        get { return spd; }
        set { spd = value;
        values[1].GetComponent<Text>().text = "" + value;
        
        }
    }
    int rng;

    public int Rng
    {
        get { return rng; }
        set { rng = value;
        values[2].GetComponent<Text>().text = "" + value;
        }
    }
    int mov;

    public int Mov
    {
        get { return mov; }
        set { mov = value;
        values[3].GetComponent<Text>().text = "" + value;
        }
    }
    int fhr;

    public int Fhr
    {
        get { return fhr; }
        set { fhr = value;
        values[4].GetComponent<Text>().text = "" + value;
        }
    }
    int luk;

    public int Luk
    {
        get { return luk; }
        set 
        { 
            
            luk = value;
            values[5].GetComponent<Text>().text = ""+value;
        }
    }

    public GameObject[] values;
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

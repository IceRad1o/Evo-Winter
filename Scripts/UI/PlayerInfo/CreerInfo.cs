using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreerInfo : ExUnitySingleton<CreerInfo> {

    public GameObject phote;
    public GameObject creer;
    public  GameObject name;
    public GameObject photeText;
	// Use this for initialization
	void Start () {
        phote = gameObject.transform.Find("Phote").gameObject;
        creer = gameObject.transform.Find("Creer").gameObject;
        name = gameObject.transform.Find("Name").gameObject;
        SetRace(Player.Instance.Character.Race);

        SetCreer(Player.Instance.Character.Weapon);

	}

    public void SetRace(int id)
    {
        switch (id)
        {
            case 0:
                photeText.GetComponent<Text>().text = "Gnome";
                break;
            case 1:
                photeText.GetComponent<Text>().text = "Pygmy";
                break;
            case 2:
                photeText.GetComponent<Text>().text = "Vampire";
                break;
            case 3:
                photeText.GetComponent<Text>().text = "lycan";
                break;
            default:
                break;
        }
    }

    public void SetCreer(int id)
    {
        switch (id)
        {
            case 0:
                creer.GetComponent<Text>().text = "Warrior";
                break;
            case 1:
                creer.GetComponent<Text>().text = "Rouge";
                break;
            case 2:
                creer.GetComponent<Text>().text = "Mage";
                break;
            case 3:
                creer.GetComponent<Text>().text = "Archer";
                break;
            default:
                break;
        }
    }

    public void SetName(string str)
    {
        name.GetComponent<Text>().text = str;
    }



	

}

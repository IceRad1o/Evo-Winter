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

        SetCareer(Player.Instance.Character.Career);

	}

    public void SetRace(Character.RaceType race)
    {
        switch (race)
        {
            case Character.RaceType.Gnome:
                photeText.GetComponent<Text>().text = "Gnome";
                break;
            case Character.RaceType.Pygmy:
                photeText.GetComponent<Text>().text = "Pygmy";
                break;
            case Character.RaceType.Vampire:
                photeText.GetComponent<Text>().text = "Vampire";
                break;
            case Character.RaceType.Lycan:
                photeText.GetComponent<Text>().text = "lycan";
                break;
            default:
                break;
        }
    }

    public void SetCareer(Character.CareerType career)
    {
        /*缺少美术资源*/
        return;
        switch (career)
        {
            case Character.CareerType.Warrior:
                creer.GetComponent<Text>().text = "Warrior";
                break;
            case Character.CareerType.Rogue:
                creer.GetComponent<Text>().text = "Rogue";
                break;
            case Character.CareerType.Mage:
                creer.GetComponent<Text>().text = "Mage";
                break;
            case Character.CareerType.Archer:
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

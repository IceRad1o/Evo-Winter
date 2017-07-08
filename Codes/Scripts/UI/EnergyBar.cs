using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyBar : ExUnitySingleton<EnergyBar> {


    void Start()
    {
        Display();
    }
    public GameObject energyBar;

    public void SetEnergy(float percent)
    {
        //Debug.Log("per:" + percent);
        if (percent > 0)
        {
            energyBar.GetComponent<Image>().fillAmount = percent;
        }
        else
        {
            energyBar.GetComponent<Image>().fillAmount = 0;
        }

    }


    void UnDisplay()
    {
        gameObject.SetActive(false);
    }

    void Display()
    {
        gameObject.SetActive(true);
        energyBar.GetComponent<Image>().fillAmount = 1f;
    }

}

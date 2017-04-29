using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GodBar : ExUnitySingleton<GodBar>
{

    public GameObject gateBtn;

    public GameObject[] btns;
	// Use this for initialization
	void Start () {
        Button btn = gateBtn.GetComponent<Button>();

        btn.onClick.AddListener(OnGate);
        
	}

    void OnGate()
    {
        for(int i=0;i<btns.Length;i++)
        {
            btns[i].SetActive(!btns[i].activeInHierarchy);
        }
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
    }
}

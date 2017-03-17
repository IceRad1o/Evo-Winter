using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartAdventrue : MonoBehaviour {


    public int isNew;
    public int mode;


	// Use this for initialization
	void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnStartAdventrue);


	}
	
    
    void OnStartAdventrue()
    {
        PlayerPrefs.SetInt("isNew", isNew);
        PlayerPrefs.SetInt("mode", mode);

        SceneManager.LoadScene("Scenes/CharacterYYF");

    }



}

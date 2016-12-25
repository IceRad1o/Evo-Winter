using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Button JButton;
    public Button KButton;
    public Button LButton;

    public Button PhoteButton;

    public Button MapButton;

    public GameObject PlayerInfo;

	// Use this for initialization
	void Start () {
        Button jBtn = JButton.GetComponent<Button>();
        jBtn.onClick.AddListener(OnNormalAttack);

        Button kBtn = KButton.GetComponent<Button>();
        jBtn.onClick.AddListener(OnNormalAttack);

        Button lBtn = LButton.GetComponent<Button>();
        jBtn.onClick.AddListener(OnNormalAttack);

        Button photeBtn = PhoteButton.GetComponent<Button>();
        //photeBtn.onClick.AddListener(OnPhote)
	}
	


    void OnNormalAttack()
    {
        Debug.Log("You have clicked the  JButton!");
        //NEED Player.GetInstance().NormalAttack();
    }

    void OnSpecialAttack()
    {
        Debug.Log("You have clicked the  KButton!");
        //NEED Player.GetInstance().SpecialAttack();
    }

    void OnRaceSkill()
    {
        Debug.Log("You have clicked the  LButton!");
        //NEED Player.GetInstance().UseRaceSkill();
    }
}

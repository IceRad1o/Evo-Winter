using UnityEngine;
using System.Collections;

public class FenShenAi : MonoBehaviour {

    private Character character;
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
        StartCoroutine(Test());
	}
	
    IEnumerator Test()
    {
        yield return new WaitForSeconds(3.0f);
        character.UseRaceSkill();


    }
}

using UnityEngine;
using System.Collections;

public class CharacterTest : MonoBehaviour {

    Character character;
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
        StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Start Test1：改变攻速");
        character.AttackSpeed =1;
        Debug.Log("Test1 Over");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Start Test1：改变攻速");
        character.AttackSpeed = 2;
        Debug.Log("Test1 Over");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Start Test1：改变攻速");
        character.AttackSpeed = 3;
        Debug.Log("Test1 Over");

        //yield return new WaitForSeconds(3.0f);
        //Debug.Log("Start Test2：改变移速");
        //character.MoveSpeed = 0.07f;
        //Debug.Log("Test2 Over");
    }
}

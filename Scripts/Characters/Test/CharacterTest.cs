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
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Start Test1：改变攻速");
        AnimatorStateInfo a = character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Idle"))//注意这里指的不是动画的名字而是动画状态的名字
        {
          
        }
        Debug.Log("Test1 Over");

        //yield return new WaitForSeconds(3.0f);
        //Debug.Log("Start Test2：改变移速");
        //character.MoveSpeed = 0.07f;
        //Debug.Log("Test2 Over");
    }
}

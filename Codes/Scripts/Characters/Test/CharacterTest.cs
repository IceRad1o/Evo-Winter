using UnityEngine;
using System.Collections;
using System.Diagnostics;
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
        //UnityEngine.Debug.Log("Start Test1：改变攻速");
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        //character.Direction2 = -character.Direction2;
        //sw.Stop();
        //UnityEngine.Debug.Log(string.Format("total: {0} ms", sw.ElapsedMilliseconds));

        ////Debug.Log("Test1 Over");

        //yield return new WaitForSeconds(5.0f);
        ////Debug.Log("Start Test1：改变攻速");
        //sw = new Stopwatch();
        //sw.Start();
        //character.Direction = -character.Direction;
        //sw.Stop();
        //UnityEngine.Debug.Log(string.Format("total: {0} ms", sw.ElapsedMilliseconds));
        //Debug.Log("Test1 Over");
        //yield return new WaitForSeconds(5.0f);
        //Debug.Log("Start Test1：改变攻速");
        //character.Spd = 3;
        //Debug.Log("Test1 Over");

        //yield return new WaitForSeconds(3.0f);
        //Debug.Log("Start Test2：改变移速");
        //character.MoveSpeed = 0.07f;
        //Debug.Log("Test2 Over");
    }
}

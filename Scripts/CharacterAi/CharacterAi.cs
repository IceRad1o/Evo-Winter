using UnityEngine;
using System.Collections;

public class CharacterAi : MonoBehaviour {

    private Character character;
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
       // StartCoroutine(Test());
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        character.ActionStateMachine.J();
        yield return new WaitForSeconds(1.0f);
        character.ActionStateMachine.JJ();
        //Debug.Log("Test1 Over");
        yield return new WaitForSeconds(1.0f);
        character.ActionStateMachine.JJJ();

    }
	void Update () {

        //TODO 增加一个随机因子,以免ai动作完全相同
        if(Player.Instance.Character.IsAlive>0&&character.IsAlive>0)
        {
            Vector3 destPos = Player.Instance.transform.position;
            Vector3 srcPos = transform.position;
            Vector3 offset = destPos - srcPos;
            //Debug.Log("offset" + offset);
            if (offset.x < 2 && offset.x > -2 && offset.y < 0.5 && offset.y > -0.5)
            {
                character.State = 0;
                character.NormalAttack();
            }
            else
            {

                offset.Normalize();
                character.Direction = offset;
                character.State = 1;
            }

        }
        else
        {
            character.State = 0;
        }

   
	}
}

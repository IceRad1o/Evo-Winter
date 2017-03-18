using UnityEngine;
using System.Collections;

public class CharacterAi : MonoBehaviour {

    private Character character;
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}


	void Update () {

        //TODO 增加一个随机因子,以免ai动作完全相同
        if(Player.Instance.Character.IsAlive>0&&character.IsAlive>0)
        {
            Vector3 destPos = Player.Instance.transform.position;
            Vector3 srcPos = transform.position;
            Vector3 offset = destPos - srcPos;
            //Debug.Log("offset" + offset);
            if (offset.x < 0.8 && offset.x > -0.8 && offset.y < 0.5 && offset.y > -0.5)
            {
                if (Random.value > 0.95)
                {
                    if (Random.value > 0.3)
                        character.NormalAttack();
                    else
                        character.UseRaceSkill();
                }
                else
                {
                    character.State = 0;
                }
               
             
            }
            else
            {

                offset.Normalize();
                Vector3 rand = new Vector3(Random.value, Random.value, Random.value);
                rand.Normalize();
                offset =offset+offset+rand;//3：1
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

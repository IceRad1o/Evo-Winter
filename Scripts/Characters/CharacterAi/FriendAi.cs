using UnityEngine;
using System.Collections;

public class FriendAi : CharacterAi
{

    // Use this for initialization
    void Start()
    {
        attackAbility = 0.5f;
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    public override void Update()
    {

        if (character.Controllable != 0)
        {
            //随机选择目标
            Character tar=null;

            //TODO 根据sight决定视野范围
            float leastDistance=500;
            /*根据*/
            foreach (Enemy en in EnemyManager.Instance.EnemyList)
            {
                Vector3 destPos = en.transform.position;
                Vector3 srcPos = transform.position;
                Vector3 offset = destPos - srcPos;
                if(offset.sqrMagnitude<leastDistance)
                {
                    leastDistance = offset.sqrMagnitude;
                    tar = en;
                }
                
            }
            if (tar == null)
                return;
            //TODO 增加一个随机因子,以免ai动作完全相同
            if (tar.IsAlive > 0 && character.IsAlive > 0)
            {
                Vector3 destPos = tar.transform.position;
                Vector3 srcPos = transform.position;
                Vector3 offset = destPos - srcPos;
                //Debug.Log("offset" + offset);
                if (offset.x < 10 && offset.x > -10 && offset.y < 0.5 && offset.y > -0.5)
                {
                    if (Random.value > attackAbility)
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
                    offset = offset + offset + rand;//3：1
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

}

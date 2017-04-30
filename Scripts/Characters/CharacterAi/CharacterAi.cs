using UnityEngine;
using System.Collections;

public class CharacterAi : MonoBehaviour
{

    protected Character character;
    public float moveAbility=0.2f;//好动性
    public float attackAbility=0.1f;//攻击性
    public float attackRange=1f;//攻击范围
    //  public float 
    protected Character tar;//目标
    bool getTarget=false;
    void Start()
    {
        character = GetComponent<Character>();

        
    }


    public virtual void Update()
    {


        /*ai行动的前提条件*/
        if (Player.Instance.Character.IsAlive > 0 && character.IsAlive > 0 && character.Controllable != 0)
        {
  

            //TODO 根据sight决定视野范围
            float leastDistance = 25;
            if (tag == "Friend"||tag=="Player")
            {
                foreach (Enemy en in EnemyManager.Instance.EnemyList)
                {
                    Vector3 destPos0 = en.transform.position;
                    Vector3 srcPos0 = transform.position;
                    Vector3 offset0 = destPos0 - srcPos0;
                    if (offset0.sqrMagnitude < leastDistance)
                    {
                        leastDistance = offset0.sqrMagnitude;
                        tar = en;
                    }

                }
            }
            else if(tag=="Monster"||tag=="Boss")
            {
                tar = Player.Instance.Character;
            }
            if (tar == null)
                return;



            Vector3 destPos =tar.transform.position;
            Vector3 srcPos = transform.position;
            Vector3 offset = destPos - srcPos;

            if (offset.sqrMagnitude > leastDistance&&getTarget==false)
            {
                character.State = 0;
                return;

            }

            getTarget = true;
            if (Random.value < attackAbility)
            {
                if (offset.x < attackRange && offset.x > -attackRange && offset.y < 0.3 && offset.y > -0.3)
                {
                    if(offset.x>0)
                         character.Direction = new Vector3(1,0,0);
                    else
                        character.Direction = new Vector3(-1, 0, 0);
                    character.NormalAttack();

                }
            }
            else if (Random.value < moveAbility)
            {

                offset.Normalize();
                Vector3 rand = new Vector3(Random.value, Random.value, Random.value);
                rand.Normalize();
                offset = offset + offset + rand;//3：1的随机因子,避免运动一致
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


    public void SetIdle()
    {
        character.State = 0;
    }

    public void SetMove()
    {
        character.State = 1;
    }


    public void SetDirection()
    {
        tar = Player.Instance.Character;
        Vector3 destPos = tar.transform.position;
        Vector3 srcPos = transform.position;
        Vector3 offset = destPos - srcPos;
        offset.Normalize();
        if(!character)
            character = GetComponent<Character>();
        character.Direction = offset;
      //Vector3 a=GetComponent<BehaviorDesigner.Runtime.BehaviorTree>().GetVariable("Distance");
       
    }

}

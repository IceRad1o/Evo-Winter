using UnityEngine;
using System.Collections;

public class ActionStateMachine {

    int machineID;
    int race;
    int weapon;
    bool isFull;

    public bool IsFull
    {
        get { return isFull; }
        set { isFull = value; }
    }
    public int MachineID
    {
        get { return machineID; }
        set { machineID = value; }
    }

    private int state;  //节点链,个位表示链的第一个元素,十位表示第二个,类推
    private string curState;//当前状态

    public string CurState
    {
        get { return curState; }
        set { curState = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }
    private float nextTime;
    private float intervalTime; //最长反应时间

    public float IntervalTime
    {
        get { return intervalTime; }
        set { intervalTime = value; }
    }
    private Character character;
    //2 ->21 0
    public Character Character
    {
        get { return character; }
        set { character = value; }
    }

    public ActionStateMachine(int race=0,int weapon=0)
    {
       
        state = 0;
        nextTime = 0;
        intervalTime = 0.5f;
        isFull = false;

    }
    public void ChangeActionState(int race,int weapon){
        this.race = race;
        this.weapon = weapon;
    }
    public void CallActionState(){
        //Debug.Log("state:"+state);
        if (state < 0)
            return;
        if (curState == "Idle" && state == 0)
            return;

        switch(state)
        {
            case 0:
                Idle();
                break;
            case 1:
                J();
                break;
            case 2:
                K();
                break;
            case 3:
                L();
                break;
            case 4:
                Move();
                break;
            case 5:
                Die();
                break;
            case 6:
                Hurt();
                break;
            case 7:
                Fall();
                break;
            case 11:
                JJ();
                break;
            case 12:
                JK();
                break;
            case 21:
                KJ();
                break;
            case 22:
                KK();
                break;
            case 111:
                JJJ();
                break;
            case 112:
                JJK();
                break;
            case 221:
                KKJ();
                break;
            case 222:
                KKK();
                break;
            case 1111:
                JJJJ();
                break;
            default:
                state = state % 10; //如果没有相应的状态与节点链对应,则表示进入的节点为新的节点链的首节点
                //Debug.Log("1new:"+state);
                CallActionState();
                break;
        }
        
    }


    /*
     *@brief 将节点压入状态机 
     *1=j,2=k,3=l,0=静止,4=移动,5=死亡
     */
    public void Push(int node)
    {
       // Debug.Log("push" + node);
        //TODO 如果链已接受到下一个状态节点,且还未进入下一个状态节点,则不再接受新的节点
        //由于unity自带的动作有缓存,貌似还不要紧
        if (isFull&&(node!=7))
            return;

        isFull = true;
  
        //如果时间大于状态机的响应时间,则新起一条链
        if (Time.time > nextTime)
            state = node;
        


        //如果链长度太大,则去掉前面无用节点 <异常处理>
        else if (state > 100000)
        {
            Debug.Log("State:" + state + " is too big!");
            state = state / 100;
        }
        else 
            state = state * 10 + node;

        nextTime = Time.time + intervalTime;

        CallActionState();
    }

    public virtual void J()
    {
        if(race==0&&weapon==0)
            character.GetComponent<Animator>().SetTrigger("AttackJ");
        else
            character.GetComponent<Animator>().SetTrigger("AttackJ"+race+weapon);
       


    }

    public virtual void K()
    {
        character.GetComponent<Animator>().SetTrigger("AttackK");
    }

    public virtual void L()
    {
        character.GetComponent<Animator>().SetTrigger("AttackL");
        
    }
    public virtual void JJ()
    {
        if (race == 0 && weapon == 0)
            character.GetComponent<Animator>().SetTrigger("AttackJJ");
        else
            character.GetComponent<Animator>().SetTrigger("AttackJJ" + race + weapon);
  
    }

    public virtual void JK()
    {
       // character.GetComponent<Animator>().SetTrigger("AttackJK");
    }

    public virtual void KJ()
    {
      //  character.GetComponent<Animator>().SetTrigger("AttackKJ");
    }

    public virtual void KK()
    {

       // character.GetComponent<Animator>().SetTrigger("AttackKK");
    }

    public virtual void JJJ()
    {
        if (race == 0 && weapon == 0)
            character.GetComponent<Animator>().SetTrigger("AttackJJJ");
        else
            character.GetComponent<Animator>().SetTrigger("AttackJJJ" + race + weapon);
        //state = 0;
    }
    public virtual void JJJJ()
    {

            character.GetComponent<Animator>().SetTrigger("AttackJJJJ");
  
    }
    public virtual void JJK()
    {
       // character.GetComponent<Animator>().SetTrigger("AttackJJK");
    }

    public virtual void KKJ()
    {
       // character.GetComponent<Animator>().SetTrigger("AttackKKJ");
    }
    public virtual void KKK()
    {
       // character.GetComponent<Animator>().SetTrigger("AttackKKK");
    }

    public virtual void Idle()
    {
        if(CurState!="Idle")
          character.GetComponent<Animator>().SetTrigger("Idle");

    }

    public virtual void Move()
    {
        if (CurState != "Move")
         character.GetComponent<Animator>().SetTrigger("Move");
        //character.UpdateAnimSpeed("Move");
    }

    public virtual void Die()
    {
        character.GetComponent<Animator>().SetTrigger("Die");
        SoundManager.Instance.PlaySoundEffect(character.dyingSound);
    }

    public virtual void Hurt()
    {
        if(character.IsAlive>=0)
            character.GetComponent<Animator>().SetTrigger("Hurt");
        SoundManager.Instance.PlaySoundEffect(character.damagingSound);
    }

    public virtual void Fall()
    {
        character.GetComponent<Animator>().SetTrigger("Fall");
    }



    public void UpdateAnimSpeed(Animator anim)
    {
        IsFull = false;

        AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);
        if (asi.IsName("AttackJ") )
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackJ";
        }
        else if (asi.IsName("AttackJJ"))
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackJJ";
        }
        else if (asi.IsName("AttackJJJ"))
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackJJJ";
        }
        else if (asi.IsName("AttackJJJJ"))
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackJJJJ";
        }
        else if (asi.IsName("AttackK"))
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackK";
        }
        else if (asi.IsName("AttackL"))
        {
            anim.speed = character.AttackSpeedIn;
            CurState = "AttackL";
        }
        else if (asi.IsName("Move"))
        {
            anim.speed = character.MoveSpeedIn * 10;
            CurState = "Move";
        }
        else if (asi.IsName("Idle") )
        {
            anim.speed = 1;
            CurState = "Idle";
        }
        else if (asi.IsName("Fall"))
        {
            anim.speed = 1;
            CurState = "Fall";
        }
        else if (asi.IsName("Hurt"))
        {
            anim.speed = character.HitRecover;
            CurState = "Hurt";
        }
    }
}

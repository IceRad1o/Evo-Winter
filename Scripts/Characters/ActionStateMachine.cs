using UnityEngine;
using System.Collections;

public class ActionStateMachine {

    private int state;  //节点链,个位表示链的第一个元素,十位表示第二个,类推
    private float nextTime;
    private float intervalTime;
    private Character character;
    //2 ->21 0
    public Character Character
    {
        get { return character; }
        set { character = value; }
    }

    public ActionStateMachine()
    {
        state = 0;
        nextTime = 0;
        intervalTime = 0.5f;
    }
    public void CheckActionState(){

    }
    public void CallActionState(){
        //Debug.Log("state:"+state);
        if (state < 0)
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
            default:
                state = state % 10; //如果没有相应的状态与节点链对应,则表示进入的节点为新的节点链的首节点
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

        //如果时间大于状态机的响应时间,则新起一条链
        if (Time.time > nextTime)
            state = node;
        //TODO 如果链已接受到下一个状态节点,且还未进入下一个状态节点,则不再接受新的节点
        //由于unity自带的动作有缓存,貌似还不要紧

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
        character.GetComponent<Animator>().SetTrigger("AttackJ");
   
    }

    public virtual void K()
    {

    }

    public virtual void L()
    {
         
    }
    public virtual void JJ()
    {
        character.GetComponent<Animator>().SetTrigger("AttackJJ");
  
    }

    public virtual void JK()
    {

    }

    public virtual void KJ()
    {

    }

    public virtual void KK()
    {


    }

    public virtual void JJJ()
    {
        character.GetComponent<Animator>().SetTrigger("AttackJJJ");
        //state = 0;
    }

    public virtual void JJK()
    {

    }

    public virtual void KKJ()
    {

    }
    public virtual void KKK()
    {

    }

    public virtual void Idle()
    {
        character.GetComponent<Animator>().SetTrigger("Idle");

    }

    public virtual void Move()
    {
        character.GetComponent<Animator>().SetTrigger("Move");
    }

    public virtual void Die()
    {
        character.GetComponent<Animator>().SetTrigger("Die");
        SoundManager.Instance.PlaySoundEffect(character.dyingSound);
    }
}

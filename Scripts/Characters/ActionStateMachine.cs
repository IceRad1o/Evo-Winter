using UnityEngine;
using System.Collections;

public class ActionStateMachine {

    private int state;  //状态栈,个位表示栈的第一个元素,十位表示第二个,类推
    private float nextTime;
    private float intervalTime;
    private Character character;

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
    public void CallActionState(int state){
        Debug.Log("state:"+state);
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
                state = state % 10;
                CallActionState(state);
                break;
        }
    }


    /*
     *@brief 将节点压入状态机 
     *1=j,2=k,3=l,0=静止,4=移动
     */
    public void Push(int node)
    {

 
        if (Time.time > nextTime)
            state = node;
        else if (state > 100000)
        {
            Debug.Log("State:" + state + " is too big!");
            return;
        }
        else 
            state = state * 10 + node;

        nextTime = Time.time + intervalTime;

        CallActionState(state);
    }

    protected virtual void J()
    {
        character.GetComponent<Animator>().SetTrigger("AttackJ");
    }

     protected virtual void K()
    {

    }

     protected  virtual void L()
    {

    }
    protected virtual void JJ()
    {
        character.GetComponent<Animator>().SetTrigger("AttackJJ");
    }

    protected virtual void JK()
    {

    }

    protected virtual void KJ()
    {

    }

    protected virtual void KK()
    {


    }

    protected virtual void JJJ()
    {

    }

    protected virtual void JJK()
    {

    }

    protected virtual void KKJ()
    {

    }
    protected virtual void KKK()
    {

    }

    protected virtual void Idle()
    {
        character.GetComponent<Animator>().SetTrigger("Idle");
    }

    protected virtual void Move()
    {
        character.GetComponent<Animator>().SetTrigger("Move");
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 发射物类，包括法球和弓箭
/// </summary>
public class Missile : MonoBehaviour {

    //NEED public AudioClip fly;
    //NEED public AudioClip bomb;

    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private Animator animator;
    //飞行时间，速度，伤害
    private float moveTime;
    private float flySpeed;
    private int damage;
    //穿透性，距离，爆炸范围（目前没用上）
    private bool penetrating;
    private float flyDistance;
    private float bombRange;
    //方向（-1为左，1为右），飞行时间倒数，飞行路径，初始位置
    private int direction;
    private float inverseMoveTime;
    private int flyPath;
    private float startPosition;

	void Awake () {
        
        //NEED SoundManager.instance.PlaySingle(fly);
	}
    void Start()
    {
        Debug.Log("进入Start()");
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        //初始化默认值
        //flySpeed = 20;
        //flyDistance = 5;
        //moveTime = flyDistance / flySpeed;    
        //inverseMoveTime = 1f / moveTime;
        //direction = -1;
        damage = 1;
        penetrating = false;
        bombRange = 2;
        flyPath = 1;
        Debug.Log("退出Start()");
        //StartMove();      
    }
    /// <summary>
    /// 发射物开始移动
    /// </summary>
    /// <param name="dis">移动距离</param>
    /// <param name="spd">移动速度</param>
    public void StartMove(float dis,float spd)
    {
        Debug.Log("进入StartMove()");
        flyDistance = dis;
        flySpeed = spd;
        moveTime = flyDistance / flySpeed;
        inverseMoveTime = 1f / moveTime;
        Debug.Log("speed:" + flySpeed + "  distance:" + flyDistance + "  direction:" + direction);

        //飞行路径1
        if (flyPath == 1)
        {
            Debug.Log("flyPath:"+flyPath);

            if (direction == 1)
                AttemptMove<Missile>(flyDistance, 0f);
            else
                AttemptMove<Missile>(flyDistance * -1, 0f);
            startPosition = this.transform.position.x;
            //检测结束条件
            StartCoroutine(FlyEndCheck());
        }
        //飞行路径2
        if (flyPath == 2)
        {
            Debug.Log("flyPath:" + flyPath);

            if (direction == 1)
                AttemptMove<Missile>(flyDistance, 3.0f);
            else
                AttemptMove<Missile>(flyDistance * -1, 3.0f);
            startPosition = this.transform.position.x;
            //检测结束条件
            StartCoroutine(FlyEndCheck());
        }
        Debug.Log("退出StartMove()");
       
    }
	
	void Update () {
        
	}
    
    /// <summary>
    /// 运动路径1，法球类运动轨迹，直线
    /// </summary>
    /// <returns></returns>
    IEnumerator FlyEndCheck()
    {
        Debug.Log("进入FlyPath1()");
        while (true)
        {
            //Debug.Log("方向:" + direction + "正距离:" + startPosition +"+"+ flyDistance + "负距离:" + startPosition + flyDistance * -1 + "当前位置：" + this.transform.position.x);
            if ((startPosition + flyDistance) - this.transform.position.x < float.Epsilon + 0.001 && (direction == 1))
             {
                 Debug.Log("1success");
                 animator.SetTrigger("MissileBomb");
                 Debug.Log("1+MissileBomb");
                 yield return new WaitForSeconds(0.2f);
                 //this.gameObject.SetActive(false);
                 Destroy(gameObject);
                 break;
             }
            if (this.transform.position.x - (startPosition - flyDistance) < float.Epsilon + 0.001 && (direction == -1))
             {
                 Debug.Log("-1success");
                 animator.SetTrigger("MissileBomb");
                 Debug.Log("-1+MissileBomb");
                 yield return new WaitForSeconds(0.2f);
                 //this.gameObject.SetActive(false);
                 Destroy(gameObject);
                 break;
             }
             else
                 yield return null;
        }
        Debug.Log("退出FlyPath1()");
    }
    





    //飞行时间
    public void SetMoveTime(float mTime)
    {
        moveTime = mTime;
    }
    //飞行速度
    public void SetFlySpeed(float speed)
    {
        flySpeed = speed;
    }
    public float GetFlySpeed()
    {
        return flySpeed;
    }
    public void ChangeFlySpeed(float speed)
    {
        flySpeed += speed;
    }
    //伤害值
    public void SetDamage(int dam)
    {
        damage = dam;
    }
    public float GetDamage()
    {
        return damage;
    }
    public void ChangeDamage(int dam)
    {
        damage+=dam;
    }
    //穿透性
    public void SetPenetrating(bool pen)
    {
        penetrating = pen;
    }
    public bool GetPenetrating()
    {
        return penetrating;
    }
    //飞行距离
    public void SetFlyDistance(float flydis)
    {
        flyDistance = flydis;
    }
    public float GetFlyDistance()
    {
        return flyDistance;
    }
    //伤害范围
    public void SetBombRange(float bom)
    {
        bombRange = bom;
    }
    public float GetBombRange()
    {
        return bombRange;
    }
    //发射方向
    public void SetDirection(int direct)
    {
        direction = direct;
    }
    public int GetDirection()
    {
        return direction;
    }

    //飞行路径
    public void SetFlyPath(int fp)
    {
        flyPath = fp;
    }





    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTrrigerEnter");
        if (other.tag == "Enemy")
        {
            other.GetComponent<Character>().Health-=damage;
            if (!penetrating)
            {
                Debug.Log("Tirr+MissileBomb");
                animator.SetTrigger("MissileBomb");
                StartCoroutine(Wait(0.3f));
                Destroy(gameObject);
            }
        }
        //if(other.tag==...)
    }







    /// <summary>
    /// 试图移动
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="xDir">x方向距离</param>
    /// <param name="yDir">y方向距离</param>
    protected void AttemptMove<T>(float xDir, float yDir)
    where T : Component
    {
        Debug.Log("AttemptMove");
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
            return;
        T hitComponent = hit.transform.GetComponent<T>();
        if (!canMove && hitComponent != null)
        {
            OnCantMove(hitComponent);
        }
    }
    //移动
    protected bool Move(float xDir, float yDir, out RaycastHit2D hit)
    {
        Debug.Log("Move");
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        GetComponent<BoxCollider2D>().enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        GetComponent<BoxCollider2D>().enabled = true;

        if (hit.transform == null)
        {
            if (flyPath == 1)
            {
                StartCoroutine(SmoothMovement(end));
            }
            if (flyPath == 2)
            {
                StartCoroutine(GravityMovement(end));
            }
            return true;
        }
        return false;
    }
    //平滑移动
    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            rb2D = GetComponent<Rigidbody2D>();
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    //无法移动
    protected void OnCantMove<T>(T component)
    {
        /*NEED
        Character hitCharacter = component as Character;
        hitCharacter.ChangeHealth(damage);
        SoundManager.instance.PlaySingle(bomb);
        */
        Debug.Log("cantMove");
        animator.SetTrigger("CantMove+MissileBomb");
        StartCoroutine(Wait(0.1f));
        
    }

    //重力下的运动
    protected IEnumerator GravityMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        float y=-0.05f;
        Vector3 gravity=new Vector3(0f,y,0f);
        while (sqrRemainingDistance > float.Epsilon)
        {
            rb2D = GetComponent<Rigidbody2D>();
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            end = end + gravity;
            yield return null;
        }
    }



    //等待延迟
    IEnumerator Wait(float sec)
    {
        Debug.Log("cantMoveSuccess");
        yield return new WaitForSeconds(sec);
        //this.gameObject.SetActive(false);
        
    }


}

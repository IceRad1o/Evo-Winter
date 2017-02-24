using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    //NEED public AudioClip fly;
    //NEED public AudioClip bomb;


    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    private Rigidbody2D rb2D;
    private Animator animator;
    private float flySpeed=1.0f;
    private int number;
    private int damage;
    private bool penetrating;
    private float flyDistance=5.0f;
    private float bombRange;

    private int direction;
    private BoxCollider2D boxCollider;
    private float inverseMoveTime;

    private float startPosition;

	void Awake () {

        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
        
        //NEED SoundManager.instance.PlaySingle(fly);
	}
    void Start()
    {
        AttemptMove<Missile>(flyDistance, 0f);
        startPosition = this.transform.position.x;
        
    }
	
	void Update () {
        if (this.transform.position.x == startPosition + flyDistance)
        {
            animator.SetTrigger("MissileBomb");
            StartCoroutine(Test());        
        }
	}
    IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
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
    //发射物数量
    public void SetNumber(int num)
    {
        number = num;
    }
    public float GetNumber()
    {
        return number;
    }
    public void ChangeNumber(int num)
    {
        number+=num;
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

    //碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {

    }




    //试图移动
    protected void AttemptMove<T>(float xDir, float yDir)
    where T : Component
    {
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
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {

            StartCoroutine(SmoothMovement(end));
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
        animator.SetTrigger("MissileBomb");
        this.gameObject.SetActive(false);
    }
}

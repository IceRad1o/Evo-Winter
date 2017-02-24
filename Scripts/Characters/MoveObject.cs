using UnityEngine;
using System.Collections;

public abstract class MoveObject : Subject
{

    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;

    private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    private int state;

    public virtual int State
    {
        get { return state; }
        set { state = value; }
    }

    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    // Use this for initialization
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    protected IEnumerator SmoothMovement()
    {
        while (State==1)
        {
            Vector3 newPosition= gameObject.GetComponent<Transform>().position + direction * moveSpeed;
            rb2D.MovePosition(newPosition);
            yield return null;//暂停协同程序,下一帧再继续往下执行
        }
    }

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
       

        Vector2 start = rb2D.position;
        Vector2 endX = start + new Vector2(xDir, 0);
        Vector2 endY = start + new Vector2(0, yDir);
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;

        RaycastHit2D hitX = Physics2D.Linecast(start, endX, blockingLayer);
        RaycastHit2D hitY = Physics2D.Linecast(start, endX, blockingLayer);
        boxCollider.enabled = true;
        if (hitX.transform != null)
        {
            end.x = start.x;
            hit = hitX;
        }
        if (hitY.transform != null)
        {
            end.y = start.y;
            hit = hitY;
        }
        hit = hitY;
        rb2D.MovePosition(end);
        return false;
    }

    protected virtual void AttemptMove<T>(int xDir, int yDir)
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

    protected abstract void OnCantMove<T>(T component)
        where T : Component;
}

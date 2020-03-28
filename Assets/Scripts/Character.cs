using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject GO;

    protected float speed;

    protected Animator animator;

    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    protected bool isAttacking = false;

    protected bool isDie = false;

    protected Coroutine attackRoutine;

    public bool isMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	protected virtual void Update ()
    {
        HandleLayers();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (myRigidbody == null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        myRigidbody.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        if (isDie)
        {
            ActivateLayer("DiePlayer");
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            return;
        }
        if (isMoving)
        {
            StopAttack();
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
            ActivateLayer("WalkLayer");
        }
        else if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            ActivateLayer("IdleLayer");
        }
        //transform.Translate(direction * speed * Time.deltaTime);
    }
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }
    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
        }
        isAttacking = false;
        animator.SetBool("attack", isAttacking);
    }
}

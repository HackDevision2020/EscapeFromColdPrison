using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakedFat : Enemy
{
    private Rigidbody2D myRidgidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRidgidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {

            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                changeAnim(target.transform.position - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
            else
            {
                //changeAnim(Vector2.zero);
                //ChangeState(EnemyState.idle);
                anim.SetBool("wakeUp", false);

                //ChangeState(EnemyState.walk);

            }
        }
    }
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Debug.Log("X is greater");
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            Debug.Log("Y is greater");
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}

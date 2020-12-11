using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float runForce;
    public int health;
    public Transform lookAheadPoint;
    public LayerMask collisionLayer;
    public bool isGroundAhead;
    private Rigidbody2D rigidbody2D;
    private Animator e_animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        e_animator = GetComponent<Animator>();

        health = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
        _lookAhead();
    }

    private void _Move()
    {
        if(isGroundAhead)
        {
            rigidbody2D.AddForce(Vector2.left * runForce * Time.deltaTime * transform.localScale.x);
            rigidbody2D.velocity *= 0.9f;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void _lookAhead()
    {
        isGroundAhead = Physics2D.Linecast(transform.position, lookAheadPoint.position, collisionLayer);
        Debug.DrawLine(transform.position, lookAheadPoint.position, Color.red);
    }

    public void _Death()
    {
        e_animator.SetInteger("EnemyState", 1);
        runForce = 1;
        Debug.Log("hit");
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        e_animator.SetInteger("EnemyState", 1);
    //        runForce = 1;
    //        Debug.Log("hit");
    //    }
    //}

}

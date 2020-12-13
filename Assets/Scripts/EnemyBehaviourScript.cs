/*
    File Name: EnemyBehaviourScript.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Set enemy behaviour.
    Revision History:
    2020/12/11 Add enemy rigidboday and collision.
    2020/12/11 Add enemy move and death animator.
    2020/12/11 Add enemy movement and check groud
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float runForce;
    public Transform lookAheadPoint;
    public Transform checkAttackRange;
    public LayerMask collisionLayer;
    public LayerMask playerLayer;
    public bool isGroundAhead;
    public bool isLookPlayer;
    public AudioSource hitSound;
    private Rigidbody2D rigidbody2D;
    private Animator e_animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        e_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
        _lookAhead();
        _lookPlayer();
    }

    private void _Move()
    {
        if (isGroundAhead)
        {
            rigidbody2D.AddForce(Vector2.left * runForce * transform.localScale.x);
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

    private void _lookPlayer()
    {
        isLookPlayer = Physics2D.Linecast(transform.position, checkAttackRange.position, playerLayer);
        Debug.DrawLine(transform.position, checkAttackRange.position, Color.green);
    }



    public void _Death()
    {
        e_animator.SetInteger("EnemyState", 1);
        hitSound.Play();
        Score.gameScore += 20;
        runForce = 0;
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

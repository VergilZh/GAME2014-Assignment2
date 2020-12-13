/*
    File Name: PlayerBehaviour.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Player action save at here.
    Revision History:
    2020/12/11 Add joystick and player movement.
    2020/12/11 Set player health.
    2020/12/11 Add player stand ground check.
    2020/12/11 Add player lose sound.
 */

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float horizontalForce;
    public float verticalForce;
    public bool isJumping;
    public bool isGround;
    public int playerHealth;
    public Transform spawnPoint;
    public Transform lookAheadPoint;
    public LayerMask collisionGroundLayer;
    public Animator HealthHUB;
    public AudioSource loseSound;
    

    private Rigidbody2D m_rigidBody2D;
    private Animator m_animator;
    private RaycastHit2D groundHit;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        isJumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
        _LookAhead();

        HealthHUB.SetInteger("HealthNum", playerHealth);


        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void _Move()
    {

        if (joystick.Horizontal > joystickHorizontalSensitivity || Input.GetKey("d"))
        {
            // move right
            m_rigidBody2D.AddForce(Vector2.right * horizontalForce);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            m_animator.SetInteger("AnimState", 1);
        }
        else if (joystick.Horizontal < -joystickHorizontalSensitivity || Input.GetKey("a"))
        {
            // move left
            m_rigidBody2D.AddForce(Vector2.left * horizontalForce);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            m_animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetKey("w") && !isJumping)
        {
            _Jump();
        }
        //else if (Input.GetButton("Fire1") && !isJumping)
        //{
        //    m_animator.SetInteger("AnimState", 3);
            
        //}
        else
        {
            m_animator.SetInteger("AnimState", 0);
            isJumping = false;
        }
    }

    private void _LookAhead()
    {
        groundHit = Physics2D.Linecast(transform.position, lookAheadPoint.position, collisionGroundLayer);
        isGround = (groundHit) ? true : false;
        Debug.DrawLine(transform.position, lookAheadPoint.position, Color.green);
        
    }

    public void _Jump()
    {
        if (isGround)
        {
            m_rigidBody2D.AddForce(Vector2.up * verticalForce);
            //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            m_animator.SetInteger("AnimState", 2);
            //isJumping = true;
        }
        else
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            transform.position = spawnPoint.position;
            playerHealth -= 1;
            loseSound.Play();
            HealthHUB.SetInteger("HealthNum", playerHealth);
        }

        //else if (other.gameObject.CompareTag("Souls"))
        //{
        //    if(playerHealth < 3)
        //    {
        //        playerHealth += 1;
        //    }
        //    else
        //    {

        //    }
        //}
    }
}

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
    

    private Rigidbody2D m_rigidBody2D;
    private Animator m_animator;
    private Collider2D m_attackCollider;
    private RaycastHit2D groundHit;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_attackCollider = GetComponent<EdgeCollider2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
        _LookAhead();


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
            m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            m_animator.SetInteger("AnimState", 1);
        }
        else if (joystick.Horizontal < -joystickHorizontalSensitivity || Input.GetKey("a"))
        {
            // move left
            m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            m_animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetKey("w") && !isJumping)
        {
            if(isGround)
            {
                m_rigidBody2D.AddForce(Vector2.up * verticalForce * Time.deltaTime);
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                m_animator.SetInteger("AnimState", 2);
                isJumping = true;
            }
            else
            {
            }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            transform.position = spawnPoint.position;
            playerHealth -= 1;
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

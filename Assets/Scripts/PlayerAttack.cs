/*
    File Name: PlayerAttack.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Make player attack with the enemy.
    Revision History:
    2020/12/11 Add attack animator.
    2020/12/11 Add attack point and set the attack range.
    2020/12/11 Player can kill the enemy.
    2020/12/11 Add attack sound effect.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public AudioSource swordSound;
    // Start is called before the first frame update
    void Start()
    {
        //sword = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("j"))
        {
            _Attack();
        }
    }

    public void _Attack()
    {
        animator.SetInteger("AnimState", 3);
        swordSound.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviourScript>()._Death();
            //Debug.Log("attack");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

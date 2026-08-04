using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPos;
    public Transform player;

    public float patrolSpeed = 2f;
    public float chasingSpeed = 4f;
    public float chaseRange = 8f;
    public float attackRange = 1.5f;
    public float attackCoolDown = 1f;

    public enum State { Patrol, Chase, Attack }
    public State currentState = State.Patrol;

    private Renderer rend;
    private int patrolIndex = 0;
    private float attackTimer = 0f;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (currentState == State.Patrol)
        {
            Patrol();
        }
        else if (currentState == State.Chase)
        {
            Chase();
        }
        else if (currentState == State.Attack)
        {
            Attack();
        }

        attackTimer -= Time.deltaTime;
    }

    void Patrol()
    {
        Transform point = patrolPos[patrolIndex];
        MoveTowards(point.position, patrolSpeed);

        if (Vector3.Distance(transform.position, point.position) < 0.3f)
            patrolIndex = (patrolIndex + 1) % patrolPos.Length;

        if (Vector3.Distance(transform.position, player.position) < chaseRange)
            currentState = State.Chase;
    }

    void Chase()
    {
        MoveTowards(player.position, chasingSpeed);
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > chaseRange + 2f)
            currentState = State.Patrol;

        if (dist < attackRange)
            currentState = State.Chase; 
    }

    void Attack()
    {
        transform.LookAt(player);
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > attackRange)
        {
            currentState = State.Chase;
        }
        if (attackTimer <= 0f)
        {
            Debug.Log(" Enemy attacked the player");
            attackTimer = attackCoolDown;
        } 
    }

    void MoveTowards(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target);
    }
    private void OnDrawGizmosSelected()
    {
        // Chase range (yellow)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        // Attack range (red)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

       
     


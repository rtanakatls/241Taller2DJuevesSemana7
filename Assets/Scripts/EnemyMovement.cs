using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Following,
    Retreating
}

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float followDistance;
    [SerializeField] private float stopDistance;
    private Transform targetTransform;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private EnemyState enemyState;
    [SerializeField] private float retreatTime;

    private void Awake()
    {
        enemyState=EnemyState.Following;
        if (GameObject.Find("Player") != null)
        {
            targetTransform = GameObject.Find("Player").transform;
        }
        rb2d=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch(enemyState)
        {
            case EnemyState.Following:
                Move();
                break;
            case EnemyState.Retreating:
                break;
        }
    }


    public void Retreat()
    {
        if (enemyState == EnemyState.Following)
        {
            StartCoroutine(Retreating());
        }
    }

    IEnumerator Retreating()
    {
        enemyState = EnemyState.Retreating;
        float timer = 0;
        while (timer <= retreatTime)
        {
            if (targetTransform != null)
            {
                Vector2 direction = targetTransform.position - transform.position;
                direction = direction.normalized;
                rb2d.velocity = -direction * speed;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        enemyState = EnemyState.Following;
    }

    void Move()
    {
        if (targetTransform == null)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }
        if (Vector2.Distance(targetTransform.position, transform.position) < followDistance && Vector2.Distance(targetTransform.position, transform.position)>stopDistance)
        {
            Vector2 direction = targetTransform.position - transform.position;
            direction = direction.normalized;
            rb2d.velocity = direction * speed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}

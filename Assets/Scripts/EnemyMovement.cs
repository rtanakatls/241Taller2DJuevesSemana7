using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float followDistance;
    [SerializeField] private float stopDistance;
    private Transform targetTransform;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        targetTransform = GameObject.Find("Player").transform;
        rb2d=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}

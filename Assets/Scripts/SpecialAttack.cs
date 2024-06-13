using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, range, enemyLayerMask);

            foreach(Collider2D collider in colliders)
            {
                if (collider.gameObject.GetComponent<EnemyMovement>() != null)
                {
                    collider.gameObject.GetComponent<EnemyMovement>().Retreat();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

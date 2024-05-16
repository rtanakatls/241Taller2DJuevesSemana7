using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float shootDistance;
    private Transform targetTransform;
    private float shootTimer;

    private void Awake()
    {
        if (GameObject.Find("Player") != null)
        {
            targetTransform = GameObject.Find("Player").transform;
        }
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (targetTransform == null)
        {
            return;
        }
        if (Vector2.Distance(targetTransform.position, transform.position) < shootDistance)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= 0.2f)
            {
                Vector2 direction = targetTransform.position - transform.position;
                direction = direction.normalized;
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(direction);
                shootTimer = 0;

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}

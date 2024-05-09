using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private PlayerMovement playerMovement;
    private float shootTimer;
    private Camera cam;
    private void Awake()
    {
        cam=GameObject.Find("Main Camera").GetComponent<Camera>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= 0.2f)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 playerPosition = transform.position;
                Vector2 direction = mousePosition - playerPosition;
                direction=direction.normalized;
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(direction);
                shootTimer = 0;
            }
        }
    }
}

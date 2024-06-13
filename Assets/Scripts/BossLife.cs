using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    private void ChangeLife(int value)
    {
        life -= value;
        UIController.Instance.UpdateEnemyLifeBar(life, maxLife);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            ChangeLife(1);
        }
    }
}

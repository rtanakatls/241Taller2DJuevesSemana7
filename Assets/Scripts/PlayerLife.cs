using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    private void Start()
    {
        UIController.Instance.UpdateLifeText(life);
        UIController.Instance.UpdateLifeBar(life, maxLife);
    }

    public void ChangeLife(int value)
    {
        life += value;

        if (life < 0)
        {
            life = 0;
        }
        else if (life > maxLife) 
        {
            life = maxLife;
        }

        UIController.Instance.UpdateLifeText(life);
        UIController.Instance.UpdateLifeBar(life, maxLife);

        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageWall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            ChangeLife(-1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    private int score = 100;
    public GameObject DieEffect;
    private void Start()
    {
        health = EnemyStats.Healt;
    }

    void Update()
    {
        if (health <= 0)
        {
            Died();
        }
    }
    public void TakeDamage(float Damage)
    {
        health -= Damage;
    }
    public void Died()
    {
        Destroy(gameObject);
        GameManager.UpdateScore(score);
        GameObject BUM = Instantiate(DieEffect, transform.position, transform.rotation);
        Destroy(BUM, 1f);
    }
}

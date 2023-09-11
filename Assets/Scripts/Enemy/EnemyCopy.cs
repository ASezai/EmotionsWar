// Enemy Script Copy
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCopy : MonoBehaviour
{
    private float currentHealth;
    private int score;

    public Slider slider;

    public GameObject DieEffect;

    private void Start()
    {
        currentHealth = EnemyStats.Healt;
        score = EnemyStats.ScoreValue;
        SetMaxHealth(EnemyStats.Healt);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Died();
        }
    }
    public void Died()
    {
        Destroy(gameObject);
        GameManager.UpdateScore(score);
        EnemyStats.UpdateScore(score);
        GameObject BUM = Instantiate(DieEffect, transform.position, transform.rotation);
        Destroy(BUM, 1f);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        SetHealth(currentHealth);
    }
}
*/
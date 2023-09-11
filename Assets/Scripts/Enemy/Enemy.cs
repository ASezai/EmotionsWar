using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private int ScoreValue;
    [SerializeField] private Slider slider;

    //private static int score = 0;

    private float currentHealth;
    private GameManager gameManager;

    public GameObject DieEffect;

    protected virtual void Start()
    {
        currentHealth = Health;
        SetMaxHealth(currentHealth);
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        Move();
        if (currentHealth <= 0)
        {
            Died();
        }
    }
    public void Died()
    {
        Destroy(gameObject);
        GameManager.UpdateScore(ScoreValue);
        //EnemyStats.UpdateScore(ScoreValue);
        GameObject BUM = Instantiate(DieEffect, transform.position, transform.rotation);
        Destroy(BUM, 1f);
    }
    protected virtual void Move() // virtual
    {
        Vector3 moveDirection = (gameManager.PlayerLocation.position - transform.position).normalized;
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
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
    /*public void UpdateScore(int s)
    {
        score += s;
        Debug.Log("Stats:" + score);
        if(score % 300 == 0)
        {
            Health += 100f;
            Debug.Log("hh:" + Health);
        }
        Debug.Log("out:" + Health);
        if(score % 4000 == 0 && MoveSpeed < 17)
        {
            MoveSpeed += 1f;
        }
    }*/
}

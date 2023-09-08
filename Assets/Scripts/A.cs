using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class A : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private int ScoreValue;
    [SerializeField] private Slider slider;

    private float currentHealth;
    private GameManager gameManager;

    // Start is called before the first frame update

    private void Start()
    {
        SetMaxHealth(Health);
        currentHealth = Health;
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
        EnemyStats.UpdateScore(ScoreValue);
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

    protected void Move()
    {
        Vector3 moveDirection = (gameManager.PlayerLocation.position - transform.position).normalized;
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class A : MonoBehaviour
{
    public float Health;
    public float MoveSpeed;
    public int ScoreValue;
    protected Slider slider;
    // Start is called before the first frame update
    
    private void Start()
    {
        SetMaxHealth(Health);
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
}

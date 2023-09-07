using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B : A
{
    public Slider sslider;
    public GameObject DieEffect;
    // Start is called before the first frame update

    void Start()
    {
        Health = 100f;
        MoveSpeed = 3f;
        ScoreValue = 100;
        slider = sslider;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Died();
            GameObject BUM = Instantiate(DieEffect, transform.position, transform.rotation);
            Destroy(BUM, 1f);
        }
    }
    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        SetHealth(Health);
    }
}

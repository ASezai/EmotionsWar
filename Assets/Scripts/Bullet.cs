using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float Damage = 20f;

    private void Update()
    {
        if(transform.position.x < -30 || transform.position.y < -30)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 30 || transform.position.y > 30)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<B>().TakeDamage(Damage);
        }
    }
}

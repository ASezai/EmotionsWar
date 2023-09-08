using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B : A
{
    //public Transform player; // Oyuncu transformu
    //public float moveSpeed = 2f; // Düþmanýn hareket hýzý
    public float changeDirectionDistance = 10f; // Yön deðiþtirme mesafesi
    public float randomDirectionChangeDelay = 4f; // Rasgele yön deðiþtirme gecikmesi

    private Vector3 targetPosition;
    private float distanceTraveled = 0f;
    private float directionChangeTimer = 0f;
    private bool changingDirection = false;
    protected override void Move() //--> A.protected virtual void Move()
    {
        if (!changingDirection)
        {
            base.Move();
            distanceTraveled += MoveSpeed * Time.deltaTime;
            if (distanceTraveled >= changeDirectionDistance)
            {
                ChangeDirection();
            }
            
        }
        if (changingDirection)
        {
            // Eðer yön deðiþiyorsa, rasgele yönde ilerle
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            directionChangeTimer += Time.deltaTime;

            if (directionChangeTimer >= randomDirectionChangeDelay)
            {
                changingDirection = false; // Belirli bir süre sonra tekrar oyuncuyu takip etmeye devam et
                directionChangeTimer = 0f;
            }
        }
    }
    private void ChangeDirection()
    {
        // Rasgele bir yöne dön.
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        targetPosition = transform.position + randomDirection * 2f; // 1f mesafe kadar git

        distanceTraveled = 0f; // Mesafeyi sýfýrla
        changingDirection = true; // Yön deðiþiyor olarak iþaretle
    }
}

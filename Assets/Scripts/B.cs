using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B : A
{
    //public Transform player; // Oyuncu transformu
    //public float moveSpeed = 2f; // D��man�n hareket h�z�
    public float changeDirectionDistance = 10f; // Y�n de�i�tirme mesafesi
    public float randomDirectionChangeDelay = 4f; // Rasgele y�n de�i�tirme gecikmesi

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
            // E�er y�n de�i�iyorsa, rasgele y�nde ilerle
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            directionChangeTimer += Time.deltaTime;

            if (directionChangeTimer >= randomDirectionChangeDelay)
            {
                changingDirection = false; // Belirli bir s�re sonra tekrar oyuncuyu takip etmeye devam et
                directionChangeTimer = 0f;
            }
        }
    }
    private void ChangeDirection()
    {
        // Rasgele bir y�ne d�n.
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        targetPosition = transform.position + randomDirection * 2f; // 1f mesafe kadar git

        distanceTraveled = 0f; // Mesafeyi s�f�rla
        changingDirection = true; // Y�n de�i�iyor olarak i�aretle
    }
}

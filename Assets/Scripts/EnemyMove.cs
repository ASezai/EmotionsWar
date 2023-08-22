using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float MoveSpeed;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        MoveSpeed = EnemyStats.MoveSpeed;
    }
    private void Update()
    {
        Vector3 moveDirection = (gameManager.PlayerLocation.position - transform.position).normalized;
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
    }
}

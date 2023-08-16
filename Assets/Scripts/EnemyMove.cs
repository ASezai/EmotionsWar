using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static float MoveSpeed = 3f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        Vector3 moveDirection = (gameManager.PlayerLoc.position - transform.position).normalized;
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
    }
}

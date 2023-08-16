using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform PlayerTransform;
    public float SpawnInterval = 1f;
    public int MaxEnemyCount = 10000;
    public float MaxDistance = 17f; // Oyuncuya maksimum uzaklýk

    private int currentEnemyCount = 0;

    private void Start()
    {
        // Oluþturma iþlemini baþlat
        InvokeRepeating("SpawnEnemy", 3f, SpawnInterval);
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount >= MaxEnemyCount)
            return;

        Vector3 randomPosition = GetRandomPosition();

        if (Vector3.Distance(randomPosition, PlayerTransform.position) <= MaxDistance)
            return;

        Instantiate(EnemyPrefab, randomPosition, Quaternion.identity);

        currentEnemyCount++;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 minBounds = new Vector3(-30f, -30f, 0f);
        Vector3 maxBounds = new Vector3(30f, 30f, 0f);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        return randomPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Transform PlayerTransform;
    public float SpawnInterval = 1f;
    public float MaxDistance = 17f; // Oyuncuya maksimum uzaklýk

    private void Start()
    {
        // Oluþturma iþlemini baþlat
        InvokeRepeating("SpawnEnemy", 3f, SpawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = GetRandomPosition();

        if (Vector3.Distance(randomPosition, PlayerTransform.position) <= MaxDistance)
            return;

        int randomNumber = Random.Range(1, 101);
        if (randomNumber <= 20)
        {
            Instantiate(EnemyPrefabs[1], randomPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(EnemyPrefabs[0], randomPosition, Quaternion.identity);
        }
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

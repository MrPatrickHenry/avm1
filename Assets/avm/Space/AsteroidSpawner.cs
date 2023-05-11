using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1.0f;
    public Vector2 spawnRangeX = new Vector2(-10.0f, 10.0f);

    private void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.0f, spawnRate);
    }

    private void SpawnAsteroid()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}

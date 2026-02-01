using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public float spawnInterval = 1.0f;
    public Vector2 spawnArea = new Vector2(10, 10);

    void Start()
    {
        InvokeRepeating(nameof(SpawnStar), spawnInterval, spawnInterval);
    }

    void SpawnStar()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(1391, 1431.55f),
            1454,
            0);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }

}
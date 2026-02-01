using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyLevelManager : MonoBehaviour
{
    public GameObject fireglooperPrefab; // Assign your fireglooper prefab in the Inspector
    public float minSpawnTime = 1f; // Minimum time interval between spawns
    public float maxSpawnTime = 5f; // Maximum time interval between spawns

    private void Start()
    {
        StartCoroutine(SpawnFiregloopers());
    }

    private IEnumerator SpawnFiregloopers()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            float spawnPosX = Random.Range(-156.7f, 85.4f);
            float spawnPosY = 12.1f;
            Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);

            Instantiate(fireglooperPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
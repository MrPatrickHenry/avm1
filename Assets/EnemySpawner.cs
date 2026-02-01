using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 15f;
    public int increaseRate = 1;
    private int enemiesPerWave = 1;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                // Generate a random x position between -47 and 0
                float spawnPositionX = Random.Range(-38, -11);

                // Use the specified y position
                float spawnPositionY = 6f;

                Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, transform.position.z);

                // Instantiate the enemy at the spawn position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

            // Increase the number of enemies per wave
            enemiesPerWave += increaseRate;

            // Wait for the specified interval before spawning the next wave
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

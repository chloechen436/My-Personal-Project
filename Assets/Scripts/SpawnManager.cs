using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject[] goodtoppings;

    private float zEnemySpawn = 15.0f;
    private float xSpawnRange = 4.0f;
    private float zPowerupRange = 5.0f;
    private float zGoodToppingSpawn = 5.0f;
    private float ySpawn = 0.75f;

    private float powerupSpawnTime = 12.0f;
    private float enemySpawnTime = 3.0f;
    private float goodtoppingSpawnTime = 5.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        InvokeRepeating("SpawnRandomGoodTopping", startDelay, goodtoppingSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
         float randomX = Random.Range(-xSpawnRange, xSpawnRange);
         int randomIndex = Random.Range(0, enemies.Length);

         Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

         Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
         float randomX = Random.Range(-xSpawnRange, xSpawnRange);
         float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

         Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

         Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

    void SpawnRandomGoodTopping()
    {
        if (goodtoppings != null && goodtoppings.Length > 0)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, goodtoppings.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zGoodToppingSpawn);

            Instantiate(goodtoppings[randomIndex], spawnPos, goodtoppings[randomIndex].gameObject.transform.rotation);

        }
        else
        {
            Debug.LogError("Good toppings is empty");
        }
    }
}

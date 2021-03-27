using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] enemies;
    public float spawnRate = 2f;
    #endregion

    int randomEnemy;
    Vector2 whereToSpawn;
    float randX;
    float posInY = 5f;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-4f, 80f);
                whereToSpawn = new Vector2(randX, posInY);
                Instantiate(enemies[0], whereToSpawn, Quaternion.identity);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-4f, 80f);
                randomEnemy = Random.Range(0, 1);
                whereToSpawn = new Vector2(randX, posInY);
                Instantiate(enemies[randomEnemy], whereToSpawn, Quaternion.identity);
            }
        }
    }
}

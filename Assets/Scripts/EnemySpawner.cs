using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] enemies;
    public float spawnRate = 2f;
    public string activeScene;
    #endregion

    Vector2 whereToSpawn;
    int randomEnemy;
    float randX;
    float posInY = 5f;
    float nextSpawn = 0.0f;

    void Start()
    {
        activeScene = SceneManager.GetActiveScene().name.ToString();
    }

    void Update()
    {
        if (activeScene == "Level01")
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-4f, 80f);
                whereToSpawn = new Vector2(randX, posInY);
                Instantiate(enemies[0], whereToSpawn, Quaternion.identity);
            }
        }
        else if (activeScene == "Level02")
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-43f, 43f);
                randomEnemy = Random.Range(0, 2);
                whereToSpawn = new Vector2(randX, posInY);
                Instantiate(enemies[randomEnemy], whereToSpawn, Quaternion.identity);
            }
        }
        else if (activeScene == "Level03")
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(10f, 19f);
                randomEnemy = Random.Range(0, 2);
                whereToSpawn = new Vector2(randX, posInY);
                Instantiate(enemies[randomEnemy], whereToSpawn, Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    #region  Public Variables
    public int health = 1500;
    public GameObject bossBullet;
    public Transform firePoint;
    public float startTimeBtwShots;
    #endregion

    #region Private variables
    private Transform player;
    private float timeBtwShots;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bossBullet, firePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }   
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossAI : MonoBehaviour
{
    #region  Public Variables
    public int health = 1000;
    public GameObject bossBullet;
    public Transform firePoint;
    public float startTimeBtwShots;
    public Text bossHealth;
    public Image bossColor;
    public GameObject fade;
    #endregion

    #region Private variables
    private Transform player;
    private float timeBtwShots;
    private Timer timer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        health = 1000;
        timeBtwShots = startTimeBtwShots;
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthColor();
        bossHealth.text = health.ToString() + "%";
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
            bossHealth.text = "0%";
            Die();
        }
    }

    public void Die()
    {
        fade.SetActive(true);
        bossHealth.text = "0%";
        timer.finish = true;
        PlayerPrefs.SetFloat("saveActualTime", timer.actualTime);
        PlayerPrefs.SetFloat("bestTime", PlayerPrefs.GetFloat("saveActualTime"));
        Destroy(gameObject);
    }

    private void SetHealthColor()
    {
        if (health >= 301)
        {
            bossColor.color = Color.green;
        }
        
        else if (health >= 101  && health<= 300)
        {
            bossColor.color = Color.yellow;
        }

        else 
        {
            bossColor.color = Color.red;
        }
    }
}

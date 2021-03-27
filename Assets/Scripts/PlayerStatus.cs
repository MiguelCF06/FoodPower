using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int health = 100;
    public SpriteRenderer playerSpriteRend;
    public float amountOfPoints;
    public Manager manager;
    public Text playerHealth;
    public Image healthI;

    void Update() 
    {
        playerHealth.text = health.ToString() + "%";
        ChangeColor();
    }

    void Start()
    {
        amountOfPoints = 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine("changePlayerColor");

        if (health <= 0)
        {
            playerHealth.text = health.ToString() + "%";
            Die();
        }
    }
    
    public void AssignPoints(float points)
    {
        amountOfPoints += points;
    }

    IEnumerator changePlayerColor()
    {
        playerSpriteRend.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(1);
        playerSpriteRend.color = new Color(1, 1, 1, 1);
    }

    void Die()
    {
        playerHealth.text = health.ToString() + "%";
        Destroy(gameObject);
        manager.SetGameOver();
    }

    void ChangeColor()
    {
        if (health >= 71)
        {
            healthI.color = Color.green;
        }
        
        else if (health >= 40  && health<= 70)
        {
            healthI.color = Color.yellow;
        }

        else 
        {
            healthI.color = Color.red;
        }
    }
}

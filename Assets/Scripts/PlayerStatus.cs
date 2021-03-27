using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int health = 100;
    public SpriteRenderer playerSpriteRend;
    public int amountOfPoints;
    public Manager manager;
    public Text playerHealth;
    public Image healthI;

    void Update() 
    {
        manager.dieCounter = amountOfPoints;
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
    

    void Die()
    {
        playerHealth.text = health.ToString() + "%";
        Destroy(gameObject);
        manager.SetGameOver();
    }

    public void AssignPoints(int points)
    {
        if (amountOfPoints == manager.totalOfEnemiesToKill)
        {
            amountOfPoints = manager.totalOfEnemiesToKill;
        }
        else
        {
            amountOfPoints += points;
        }
    }

    IEnumerator changePlayerColor()
    {
        playerSpriteRend.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(1);
        playerSpriteRend.color = new Color(1, 1, 1, 1);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int health = 100;
    public SpriteRenderer playerSpriteRend;
    public float amountOfPoints;

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
        Destroy(gameObject);
    }
}

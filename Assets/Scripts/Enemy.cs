using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemiesType
    {
        Toast,
        Gelatina
    }

    public EnemiesType enemyType;
    public int health = 100;

    private Weapon playerWeaponType;
    private PlayerStatus assignPoints;
    public AudioClip dieEnemy;
    public Sound sound;

    void Awake()
    {
        sound = FindObjectOfType<Sound>();
        playerWeaponType = GameObject.Find("Player").GetComponent<Weapon>();
        assignPoints = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    public void TakeDamage(int damage)
    {
        if (enemyType == EnemiesType.Toast)
        {
            if (playerWeaponType.weaponType == Weapon.WeaponType.Hamburguer)
            {
                health -= damage;

                if (health <= 0)
                {
                    Die();
                }
            }
        }
        else if (enemyType == EnemiesType.Gelatina)
        {
            if (playerWeaponType.weaponType == Weapon.WeaponType.Bread)
            {
                health -= damage;

                if (health <= 0)
                {
                    Die();
                }   
            }
        }
    }

    void Die()
    {
        sound.PlaySound(dieEnemy);
        int pointsToAssign = 1;
        int amountOfHealthToPlayer = 5;
        assignPoints.AssignPoints(pointsToAssign);
        assignPoints.AddHealth(amountOfHealthToPlayer);
        Destroy(gameObject);
    }
}

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

    void Awake()
    {
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
        int pointsToAssign = 1;
        assignPoints.AssignPoints(pointsToAssign);
        Destroy(gameObject);
    }
}

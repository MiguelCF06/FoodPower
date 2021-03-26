using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyWeapons
{
    Bread,
    Hamburguer,
    Soda
}
public class EnemyWeapon : MonoBehaviour
{
    public EnemyWeapons typeOfWeapon;
    public int damage;

    void Start()
    {
        if (typeOfWeapon == EnemyWeapons.Bread)
            damage = 10;
        else if (typeOfWeapon == EnemyWeapons.Hamburguer)
            damage = 13;
        else
            damage = 15;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerStatus player = collider.GetComponent<PlayerStatus>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}

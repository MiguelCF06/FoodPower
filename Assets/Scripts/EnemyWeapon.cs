using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyWeapons
{
    Bread,
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
        else
            damage = 20;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerStatus player = collider.GetComponent<PlayerStatus>();
        Weapon playerWeaponMode = collider.GetComponent<Weapon>();
        if (player != null && !playerWeaponMode.defendingMode)
        {
            player.TakeDamage(damage);
        }
    }
}

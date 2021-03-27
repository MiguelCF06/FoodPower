using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinaAttack : MonoBehaviour
{
    public int damage = 15;
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

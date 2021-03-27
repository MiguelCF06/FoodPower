using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public int damage = 25;

    void OnTriggerEnter2D(Collider2D collider) {
        Enemy enemy = collider.GetComponent<Enemy>();
        BossHitDown bossBottomCollider = collider.GetComponent<BossHitDown>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if (bossBottomCollider != null)
        {
            bossBottomCollider.TakeDamage(damage);
        }
    }
}

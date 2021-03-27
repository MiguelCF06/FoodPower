using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitDown : MonoBehaviour
{
    private BossAI boss;

    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<BossAI>();
    }

    public void TakeDamage(int damage)
    {
        boss.TakeDamage(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rigidBody2D;
    public float btime;
    public Sound sound;
    public AudioClip hamburguesa;

    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<Sound>();
        rigidBody2D.velocity = transform.right * speed;
        StartCoroutine("destroyBullet");
        sound.PlaySound(hamburguesa);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Enemy enemy = collider.GetComponent<Enemy>();
        BossHitTop bossTopCollider = collider.GetComponent<BossHitTop>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if (bossTopCollider != null)
        {
            bossTopCollider.TakeDamage(damage);
        }

        Destroy(gameObject);    
    }

    IEnumerator destroyBullet()
    {
        CheckTime();
        yield return new WaitForSeconds(btime);
        Destroy(gameObject);
    }

    void CheckTime() 
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            btime = 0.9f;
        }
        else
        {
            btime = 0.7f;
        }
    }
}

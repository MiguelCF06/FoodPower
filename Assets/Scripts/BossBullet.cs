using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public int damage;
    #endregion

    #region Private Variables
    private Transform player;
    private Vector2 target;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        PlayerStatus playerHealth = collider.GetComponent<PlayerStatus>();
        Weapon playerWeaponMode = collider.GetComponent<Weapon>();
        if (collider.gameObject.tag == "Player" && playerWeaponMode.defendingMode)
            DestroyBullet();
        if (collider.gameObject.tag == "Player" && playerHealth != null && !playerWeaponMode.defendingMode)
        {
            playerHealth.TakeDamage(damage);
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

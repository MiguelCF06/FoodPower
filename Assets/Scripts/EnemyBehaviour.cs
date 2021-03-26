using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public Transform playerTransform;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance; // Minimum distance for attack
    public float moveSpeed;
    public float timer; // Cooldown between attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator animator;
    private float distance; // For store the distance between the enemy and player
    private bool attackMode;
    private bool inRange; // For check if the player is in range
    private bool cooling; // Check if the enemy is in cooldown for attack
    private bool lookingRight; // Check if the enemy is looking to the right
    private float intTimer;
    private float initialRaycastLength;
    private float invertedRaycastLength;
    #endregion

    void Awake()
    {
        intTimer = timer; // Store the initial timer value
        animator = GetComponent<Animator>();
        initialRaycastLength = raycastLength;
        invertedRaycastLength = initialRaycastLength * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && playerTransform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            lookingRight = true;
            raycastLength = invertedRaycastLength;
        }
        else if (playerTransform != null && playerTransform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            lookingRight = false;
            raycastLength = initialRaycastLength;
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, raycastLength, raycastMask);
            RaycastDebugger();
        }
        else
        {
            StopAttack();
        }

        // When player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player")
        {
            target = collider.gameObject;
            inRange = true;
        }
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance && !lookingRight)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.red);
        }
        else if (distance < attackDistance && !lookingRight)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.green);
        }
        else if (distance > attackDistance && lookingRight)
        {
            Debug.DrawRay(rayCast.position, Vector2.right * raycastLength, Color.green);
        }
        else if (distance < attackDistance && lookingRight)
        {
            Debug.DrawRay(rayCast.position, Vector2.right * raycastLength, Color.green);
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && !cooling)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; // Reset the timer when the player enter to the attack range
        attackMode = true; // To check if the Enemy have to attack or not

        animator.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}

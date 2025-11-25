using System;
using UnityEngine;

public abstract class Enemy : Character
{

    [Header("Enemy Settings")]
    [SerializeField] protected float attackCooldown = 1f;
    [SerializeField] protected int damage = 10;
    public float chaseRange = 5f;
    public float attackRange = 1f;
    private float lastAttackTime = 0f;

    protected Transform player;

    protected override void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        healthBar = GetComponentInChildren<HealthBar>();
    }

    protected virtual void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Attack();
        }
        else if (distance <= chaseRange)
        {
            MoveTowardPlayer();
        }
    }

    protected virtual void MoveTowardPlayer()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
    }

    protected virtual void Attack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        lastAttackTime = Time.time;

        Debug.Log($"{name} Attack to player");

        Slime playerScript = player.GetComponent<Slime>();
        if (playerScript != null)
            playerScript.TakeDamage(damage);
    }


    protected override void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }


    

    
}

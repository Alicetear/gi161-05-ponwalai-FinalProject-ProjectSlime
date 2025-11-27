using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected HealthBar healthBar;

    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected int currentHp;

    public int Health;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void Intialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialed Health : {this.maxHp}");

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(startHealth);
            healthBar.SetHealth(Health);
        }


    }


    protected virtual void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    protected virtual void Start()
    {
        Intialize(maxHp);
    }



    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage} Current Health : {Health} ");

        if (healthBar != null)
        {
            healthBar.SetHealth(Health);
        }

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }


    protected virtual void Die()
    {
    }




}

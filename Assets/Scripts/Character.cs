using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected HealthBar healthBar;

    protected Rigidbody2D rb;
    protected Vector2 movement;
    public int Health { get; private set; }
    





    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Intialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialed Health : {this.Health}");

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




    public void TakeDamage(int damage)
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
            IsDead();
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
    }


    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; }
    }























































}

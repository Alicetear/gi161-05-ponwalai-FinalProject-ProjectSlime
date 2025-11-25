using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    private bool canHit = false;
    public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        Invoke(nameof(EnableHit), 0.1f);
    }

    private void EnableHit()
    {
        canHit = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger HIT : " + other.name);

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Bullet hit ENEMY TRIGGER!");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision HIT : " + collision.collider.name);

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Bullet hit ENEMY");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
    }





}
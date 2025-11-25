using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            Debug.Log("Bullet hit ENEMY TRIGGER!");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Bullet hit ENEMY");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }





}
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [Header("Configura��es do Proj�til")]
    public float bulletSpeed = 20f;
    public int damage = 1;
    public float lifeTime = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.right * bulletSpeed;
        }
        Destroy(gameObject, lifeTime);
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Exemplo: other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

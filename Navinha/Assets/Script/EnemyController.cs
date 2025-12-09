using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 30f;
    public float moveSpeed = 2f;

    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private float nextFireTime;

    // Referência privada para o Rigidbody
    private Rigidbody2D rb;

    void Start()
    {
        nextFireTime = Time.time + 1f / fireRate;

        // NOVO: Obtém o Rigidbody2D e garante que a gravidade é zero
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            // É melhor definir o Body Type como Kinematic no Editor se você for usar transform.Translate
        }
    }

    void Update()
    {
        // Movimento cinemático (sem física):
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        TryShoot();
    }

    // ... (Métodos TryShoot, TakeDamage, Die permanecem os mesmos) ...

    private void TryShoot()
    {
        if (enemyBulletPrefab != null && firePoint != null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.damage);
            }

            // Garante que o tiro do jogador seja destruído IMEDIATAMENTE.
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Parede"))
        {
            Destroy(other.gameObject);
        }

    }
}
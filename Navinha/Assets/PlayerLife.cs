using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string enemyBulletTag = "EnemyBullet";

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterPlayer(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag(enemyTag))
        {
            float damageAmount = 20f;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.TakeDamage(damageAmount);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyBulletTag))
        {
            float damageAmount = 0f;

            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            damageAmount = (damageDealer != null) ? damageDealer.damage : 10f;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.TakeDamage(damageAmount);
            }

            Destroy(other.gameObject);
        }
    }
}
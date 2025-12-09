using UnityEngine;

public class BalaInimigo : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // O dano é aplicado pelo script PlayerLife
            // O projétil é destruído aqui, após atingir o jogador
            Destroy(gameObject);
        }
    }
}

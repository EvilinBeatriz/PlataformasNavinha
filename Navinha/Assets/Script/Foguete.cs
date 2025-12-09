using UnityEngine;

public class Foguete : MonoBehaviour
{
    [Header("Configura��es de Alvo")]
    // O Transform do objeto que o m�ssil deve perseguir (o alvo).
    // Deve ser definido quando o m�ssil � instanciado.
    public Transform target;

    [Header("Comportamento do Foguete")]
    // Velocidade constante do foguete (impulso para frente)
    public float forwardSpeed = 15f;
    // Qu�o rapidamente o foguete consegue virar para seguir o alvo
    public float turnSpeed = 200f;
    // Dano que o m�ssil causa ao alvo
    public int damage = 10;

    // Tempo de vida m�ximo para destrui��o autom�tica
    public float lifeTime = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("HomingMissile requer um Rigidbody2D.");
            enabled = false;
        }
        rb.gravityScale = 0f;
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.linearVelocity = transform.right * forwardSpeed;
            return;
        }
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // Suaviza a rota��o com base no turnSpeed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        rb.linearVelocity = transform.right * forwardSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.transform == target)
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class NaveMovement : MonoBehaviour

{
    [Header("Config de Movimento")]
    public float moveSpeed = 7f;

    public float scrollSpeed = 3f;

    private Rigidbody2D rb;
    private Vector2 userMovementInput;

    private Armas arma; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arma = GetComponent<Armas>();
    }

    void Update()
    {
        userMovementInput.x = Input.GetAxisRaw("Horizontal"); 
        userMovementInput.y = Input.GetAxisRaw("Vertical");  

        if (Input.GetButton("Fire1")) 
        {
            arma.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
          arma.ChangeWeaponType();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Exemplo: Tecla 'E' para Habilidade Especial
        {
            arma.UseSpecialAbility();
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = userMovementInput.normalized * moveSpeed;
        Vector2 scrollingMovement = Vector2.right * scrollSpeed;
        rb.linearVelocity = velocity + scrollingMovement;
    }
}
        


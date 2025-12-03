using UnityEngine;

public class NaveMovement : MonoBehaviour

{
    [Header("Configura��es de Movimento")]
    // Velocidade m�xima de movimento da nave, controlada pelo jogador
    public float moveSpeed = 7f;

    // Velocidade de rolagem constante para simular o cen�rio movendo-se da esquerda para a direita
    public float scrollSpeed = 3f;

    private Rigidbody2D rb;
    private Vector2 userMovementInput;

    void Start()
    {
        // Obt�m o componente Rigidbody2D no objeto
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("PlayerMovement requer um Rigidbody2D. Por favor, adicione um � nave.");
            enabled = false;
        }
    }

    // Usado para capturar entradas do teclado ou controle
    void Update()
    {
        // ------------------ 1. Captura de Movimento do Jogador ------------------

        // Pega o input dos eixos (Horizontal/Vertical)
        // Isso permite mover-se para cima, baixo, esquerda e direita.
        userMovementInput.x = Input.GetAxisRaw("Horizontal"); // Geralmente A/D ou setas Esquerda/Direita
        userMovementInput.y = Input.GetAxisRaw("Vertical");   // Geralmente W/S ou setas Cima/Baixo

        // ------------------ 2. Detec��o dos Bot�es de A��o ------------------

        // Bot�es de a��o s�o usados para atirar (A��o 1)
        if (Input.GetButton("Fire1")) // Exemplo: Ctrl/Cmd ou Bot�o Esquerdo do Mouse
        {
            // O jogador apertou o bot�o de ATIRAR (A��o 1).
            // (Log�stica de tiro removida, mantendo a detec��o do input).
        }

        // Bot�es de a��o s�o usados para mudar o tipo de tiro (A��o 2)
        if (Input.GetKeyDown(KeyCode.C)) // Exemplo: Tecla 'C' para Ciclar Arma
        {
            // O jogador apertou o bot�o para MUDAR TIPO DE TIRO (A��o 2).
        }

        // Bot�es de a��o s�o usados para usar habilidades especiais (A��o 3)
        if (Input.GetKeyDown(KeyCode.E)) // Exemplo: Tecla 'E' para Habilidade Especial
        {
            // O jogador apertou o bot�o para HABILIDADE ESPECIAL (A��o 3).
        }
    }

    // Usado para aplicar movimento f�sico
    void FixedUpdate()
    {
        // 1. Calcula a velocidade baseada no input do usu�rio
        Vector2 velocity = userMovementInput.normalized * moveSpeed;

        // 2. Adiciona a velocidade de rolagem constante (cen�rio se move da esquerda para a direita)
        // Isso garante que a nave esteja sempre a avan�ar no n�vel.
        Vector2 scrollingMovement = Vector2.right * scrollSpeed;

        // 3. Aplica o movimento total ao Rigidbody2D
        rb.linearVelocity = velocity + scrollingMovement;
    }
}
        


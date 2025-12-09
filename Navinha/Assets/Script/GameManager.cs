using UnityEngine;

public class GameManager : MonoBehaviour
{
    // A instância estática da classe, acessível globalmente.
    public static GameManager Instance { get; private set; }

    [Header("Variaveis")]
    public int currentLevel = 1;
    public float playerHealth = 100f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
}
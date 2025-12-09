using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject playerObject;

    public int currentLevel = 1;
    public float playerHealth = 100f;
    public float maxPlayerHealth = 100f;

    private bool isGameOver = false;

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

    public void RegisterPlayer(GameObject player)
    {
        playerObject = player;
    }

    public void TakeDamage(float amount)
    {
        if (isGameOver)
        {
            return;
        }

        playerHealth -= amount;
        playerHealth = Mathf.Max(playerHealth, 0);

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;
        if (playerObject != null)
        {
            Destroy(playerObject);
        }
    }
}
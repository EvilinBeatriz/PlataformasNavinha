using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider healthSlider;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();

        if (healthSlider == null)
        {
            enabled = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            UpdateHealthBar(GameManager.Instance.playerHealth, GameManager.Instance.maxPlayerHealth);
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        float healthPercentage = currentHealth / maxHealth;
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public EventChannelSO hudEventChannel;

    public Image hpBar;
    public TMP_Text ammoText;
    public TMP_Text scoreText;

    public float maxHP = 100f;

    private void OnEnable()
    {
        hudEventChannel.OnEventRaised += UpdateHUD;
    }

    private void OnDisable()
    {
        hudEventChannel.OnEventRaised -= UpdateHUD;
    }

    void UpdateHUD(HUDData data)
    {
        if (hpBar != null)
            hpBar.fillAmount = data.hp / maxHP;

        if (ammoText != null)
            ammoText.text = "Ammo: " + data.ammo;

        if (scoreText != null)
            scoreText.text = "Score: " + data.score;
    }
}




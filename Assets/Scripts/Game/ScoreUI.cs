
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text moneyText;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = ScoreManager.Instance;

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
            return;
        }

        scoreManager.OnScoreChanged += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text =
                "SCORE: " + scoreManager.CurrentScore;
        }

        if (moneyText != null)
        {
            moneyText.text =
                "MONEY: " + scoreManager.TotalMoney;
        }
    }

    private void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.OnScoreChanged -= UpdateUI;
        }
    }
}

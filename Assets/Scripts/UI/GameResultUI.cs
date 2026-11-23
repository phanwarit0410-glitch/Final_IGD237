
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultUI : MonoBehaviour
{
    [Header("Result Panel")]
    [SerializeField] private GameObject resultPanel;

    [Header("Result Text")]
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text finalMoneyText;
    [SerializeField] private TMP_Text successfulOrdersText;

    private void Start()
    {
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }
    }

    public void ShowResult()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogWarning("ScoreManager not found!");
            return;
        }

        ScoreManager score = ScoreManager.Instance;

        finalScoreText.text = "FINAL SCORE: " + score.CurrentScore;
        finalMoneyText.text = "TOTAL MONEY: " + score.TotalMoney;
        successfulOrdersText.text = "SUCCESSFUL ORDERS: " + score.CorrectOrders;

        resultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

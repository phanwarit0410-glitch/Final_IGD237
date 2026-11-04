
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void MainMenu()
    {
        GameManager.Instance.ReturnToMainMenu();
    }
}

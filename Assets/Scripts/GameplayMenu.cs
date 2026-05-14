using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pausebutton;
    [SerializeField]
    private GameObject resumebutton;
    [SerializeField]
    private GameObject toMainMenubutton;
    [SerializeField]
    private GameObject quitbutton;

    [SerializeField]
    private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

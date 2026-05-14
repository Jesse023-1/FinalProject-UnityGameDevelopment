using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject startbutton;
    [SerializeField]
    private GameObject resumebutton;
    [SerializeField]
    private GameObject quitbutton;

    public void NewGame()
    {
        Debug.Log("New Game clicked");

        

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetPlayerHealth();

            ResourcesManager resources = GameManager.Instance.GetComponent<ResourcesManager>();
            if (resources != null)
            {
                resources.ResetResources();
            }
        }
        SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1.0f;
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textResult;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject creditsPanel;

    private void Start()
    {
        

        textResult.text = "Score: " + GameManager.Instance.Score;
    }

    public void PlayAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        MenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void GoBackToMenu()
    {
        creditsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void YoutubeLink()
    {
        Application.OpenURL("https://www.youtube.com/@bruxter1677");
    }

    public void GithubLink()
    {
        Application.OpenURL("https://github.com/MAARBruxter");
    }

    public void LinkedinLink()
    {
        Application.OpenURL("https://www.linkedin.com/in/miguel-%C3%A1ngel-%C3%A1vila-rosas-3b1371238/");
    }
}

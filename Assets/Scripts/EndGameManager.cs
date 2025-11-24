using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textResult;

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
}

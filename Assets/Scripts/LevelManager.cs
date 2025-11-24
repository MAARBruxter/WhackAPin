using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the level state, including timing, pausing, and game over conditions.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float levelTime;
    private float internalLevelTime;

    [Header("Score Pins")]
    [SerializeField] private int scoreValueGood = 500;
    [SerializeField] private int scoreValueBad = 250;

    public GameObject pausePanel;
    public GameObject pauseButton;
    public Image pauseButtonImage;
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite unpauseButtonSprite;
    private bool isPaused = false;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    private bool isGameOver = false;

    public int GetGoodScore() => scoreValueGood;
    public int GetBadScore() => scoreValueBad;


    public float LevelTime => internalLevelTime;

    public bool IsGameOver { get => isGameOver; }

    private void Awake()
    {
        Instance = this;
        internalLevelTime = levelTime;
    }

    private void Update()
    {
        if (internalLevelTime > 0f) internalLevelTime -= Time.deltaTime;

        if (internalLevelTime <= 0f)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Pauses or unpauses the game.
    /// </summary>
    public void PauseOption()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pausePanel) pausePanel.SetActive(true);
            pauseButtonImage.sprite = unpauseButtonSprite;
        }
        else
        {
            Time.timeScale = 1f;
            if (pausePanel) pausePanel.SetActive(false);
            pauseButtonImage.sprite = pauseButtonSprite;
        }
    }

    /// <summary>
    /// Returns to the Main Menu scene.
    /// </summary>
    [ContextMenu("MainMenuScene")]
    public void GoBackToMenu()
    {
        GameManager.Instance.SetScore(0);
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndGame");
    }

    /// <summary>
    /// Displays the Game Over panel and transitions to the end scene.
    /// </summary>
    private void GameOver()
    {
        Debug.Log("Game Over!");
        pauseButton.SetActive(false);
        gameOverPanel.SetActive(true);
        isGameOver = true;
        Invoke(nameof(GoToEndScene), 1f);
    }

    /// <summary>
    /// Sends the player to the End Game scene.
    /// </summary>
    private void GoToEndScene()
    {
        SceneManager.LoadScene("EndGame");
    }
}

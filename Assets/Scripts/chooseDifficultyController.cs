using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Choose the difficulty level and loads the corresponding scene.
/// </summary>
public class chooseDifficultyController : MonoBehaviour
{
    /// <summary>
    /// Load the scene with LevelIndex + 1 to get the actual level name.
    /// </summary>
    /// <param name="levelIndex"></param>
    public void LoadLevelSelection(int levelIndex)
    {
        //Hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Load the selected level
        UnityEngine.SceneManagement.SceneManager.LoadScene("BowlingAlley" + levelIndex);
    }

    /// <summary>
    /// Returns to the Main Menu scene.
    /// </summary>
    [ContextMenu("MainMenuScene")]
    public void MainMenuScene()
    {
        SceneManager.LoadScene("EndGame");
    }
}
